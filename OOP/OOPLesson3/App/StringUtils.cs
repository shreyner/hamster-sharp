using System;
using System.Linq;

namespace App
{
    public class StringUtils
    {
        public static string Reverse(string sourceString)
        {
            return string.Join("", sourceString.ToArray().Reverse());
        }
    }
}