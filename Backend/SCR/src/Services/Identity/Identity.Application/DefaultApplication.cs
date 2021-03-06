using Identity.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCR.Common;
using Identity.Domain.Aggregates.Entity;
using Identity.Domain.SeedWork;
using Identity.Domain.Aggregates;
using Identity.Domain.Encrypt;
using Identity.Application.Queries;

namespace Identity.Application
{
    public class DefaultApplication : IdentityApplication
    {

        private IUserRepository _userRepository;
        private ICompanyRepository _companyRepository;
        private IRoleRepository _roleRepository;
        private IUserQuery _userQuery;
        public DefaultApplication(IUserRepository userRepository,
            ICompanyRepository companyRepository,
            IRoleRepository roleRepository,
            IUserQuery userQuery
            ) {
            _userRepository = userRepository;
            _companyRepository = companyRepository;
            _roleRepository = roleRepository;
            _userQuery = userQuery;
        }
        public async Task CreateUserAsync(RegisterRequest registerRquest)
        {
            await CheckRegisterUserAsync(registerRquest);
            var encryptPsw = Guid.NewGuid().ToString();

            var psw = User.EncrypyPsw(registerRquest.Password, encryptPsw);
            var user = new User(0, registerRquest.Account, psw, encryptPsw, registerRquest.DefaultCompanyId, registerRquest.Mobile);
            var companies = await _companyRepository.GetCompaniesByIdsAsync(registerRquest.CompanyIds);
            if (companies.Count() == 0)
            {
                throw new Exception("user relation company can not find");
            }
            user.ChangeCompanies(companies.Select(t=>t.CompanyId).ToList());
            if (registerRquest.RoleIds.Count() > 0) {
                var roles = await _roleRepository.GetRolesByIdsAsync(registerRquest.RoleIds);
                user.ChangeRoles(roles.Select(t => t.RoleId).ToList());
            }
            await _userRepository.AddUserAsync(user);
            await _userRepository.UnitOfWork.SaveEntitiesAsync();


            
        }

        private async Task<bool> CheckRegisterUserAsync(RegisterRequest registerRquest) {
            if (string.IsNullOrWhiteSpace(registerRquest.Mobile))
            {
                throw new ArgumentNullException("user mobile can't empty");
            }
            if (!VerifyHelper.VerifyMobile(registerRquest.Mobile))
            {
                throw new FormatException("user mobile wrong format");
            }
            if (string.IsNullOrWhiteSpace(registerRquest.Account))
            {
                throw new ArgumentNullException("user name can't empty");
            }
            if (string.IsNullOrWhiteSpace(registerRquest.Password))
            {
                throw new ArgumentNullException("user password can't empty");
            }
            if (registerRquest.Password.Length<6) {
                throw new ArgumentNullException("user password length less 6");
            }

            if (registerRquest.CompanyIds == null || registerRquest.CompanyIds.Count() == 0)
            {
                throw new ArgumentNullException("user company can't empty");
            }
         


            var user=await _userRepository.FindUserByUserNameAsync(registerRquest.Account);
            if (user!=null) {
                throw new Exception("user name exist");
            }
            user = await _userRepository.FindUserByMobileAsync(registerRquest.Mobile);
            if (user != null)
            {
                throw new Exception("user mobile exist");
            }
            return true;
        }

        public async Task<UserDto> UserLoginAsync(string userName, string password)
        {
            var user = await _userRepository.FindUserByUserNameAsync(userName);
            if (user == null) {
                throw new Exception("can not find user");
            }
            user.LoginByPassword(password);
            await _userRepository.UnitOfWork.SaveEntitiesAsync();
            //发布用户登录事件
            return ConvertUserDto(user);

        }

        public async Task<UserProfileDto> GetProfileAsync(int userId) {
          return await  _userQuery.GetProfileAsync(userId);
        }

        private static UserDto ConvertUserDto(User user)
        {
            if (user == null)
                return null;
            return new UserDto
            {
                Account = user.Account,
                Avatar=user.Avatar,
                Description=user.Descrption,
                UserId=user.UserId,
                Email = user.Email,
 
            };
        }

    }
}
