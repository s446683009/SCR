﻿using Identity.Domain.Aggregates.Entity;
using Identity.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Aggregates
{
    public interface IUserRepository:IRepository<User>
    {
      Task<User> FindUserByIdAsync(int userId);
      Task<User> FindUserByUserNameAsync(string userName);
      Task<User> FindUserByMobileAsync(string mobile);
      Task AddUserAsync(User user);
    }
}
