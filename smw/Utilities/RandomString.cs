using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMW.Utilities
{
    public static class RandomString
    {
        public static string GenerateRandomString(int length)
        {
            var str_build = new StringBuilder();  
            var random = new Random();  

            char letter;  

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);  
            }  

            return str_build.ToString();
        }
    }
}