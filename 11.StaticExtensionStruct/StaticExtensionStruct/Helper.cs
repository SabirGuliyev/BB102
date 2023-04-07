using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticExtensionStruct
{
    internal static class Example
    {
    }
    internal static class Helper
    {

        public static string WifiPass = "salam123";

        public static string Capitalize(string word)
        {
            return word.ToUpper();
        }
        public static string ExCapitalize(this string word)
        {
            return word.ToUpper();
        }


        public static int CustomPow(this int num){

            return num * num;
        }

    }
}
