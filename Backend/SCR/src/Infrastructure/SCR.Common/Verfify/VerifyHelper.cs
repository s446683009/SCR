﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace SCR.Common
{
    public static class VerifyHelper
    {

        public static bool VerifyMobile(string mobile) {
           return Regex.IsMatch(mobile, @"^1[3456789]\d{9}$");
        }
    }
}
