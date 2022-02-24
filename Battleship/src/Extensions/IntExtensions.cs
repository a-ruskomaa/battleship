using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;

namespace PelilautaPahkina.Extensions
{
    public static class IntExtensions
    {
        public static int GetLinearrayNumber(this int i)
        {
            int retval;
            try
            {
                retval = i / 10;
            }
            catch (Exception e)
            {
                Console.WriteLine("POKS :" + e);
                retval = 0;
            }
            return retval;
        }

        public static char ToBoardCharacter(this int i)
        {
            switch (i)
            {
                case 1:
                    return '*';
                case 4:
                    return 'o';
                case 9:
                    return 'X';
                default:
                    return ' ';
            }
        }

    }
}