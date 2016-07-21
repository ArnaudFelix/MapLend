using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MapLend.Mvc.Infrastructure
{
    public static class ConvertToByteArray
    {
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}