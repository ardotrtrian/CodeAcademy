using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6._0._1.Extension_Methods
{
    static class StringHelper
    {
        public static string FirstToUpper(this string Input)
        {
            if (Input.Length > 0)
            {
                char[] charArray = Input.ToCharArray();
                if (char.IsLower(charArray[0]))
                {
                    charArray[0] = char.ToUpper(charArray[0]);
                    return new string(charArray);
                }
            }
            return Input;
        }
    }
}
