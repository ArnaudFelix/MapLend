using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MapLend.Mvc.Infrastructure
{
    public static class EnumGetName
    {
        public static string GetName(this Enum enumValue)
        {
            return enumValue.GetType().GetMember(enumValue.ToString()).First().GetCustomAttribute<DisplayAttribute>().Name;
        }
    }
}