﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveSpecialCharacteres(this string str) 
        {
            return str.Trim().Replace(".", string.Empty).Replace("-", string.Empty).Replace("/",string.Empty);
        }
    }
}
