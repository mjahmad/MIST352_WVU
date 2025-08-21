using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsArray
{
    class Utils
    {
        public static int Sum(params int[] paramList)
        {
            Console.WriteLine("Using parameter list");

            if (paramList is null)
            {
                throw new ArgumentException("Utils.Sum: null parameter list");
            }

            if (paramList.Length == 0)
            {
                throw new ArgumentException("Utils.Sum: empty parameter list");
            }

            int sumTotal = 0;
            foreach (int i in paramList)
            {
                sumTotal += i;
            }
            return sumTotal;
        }

        public static int Sum(int param1 = 0, int param2 = 0, int param3 = 0, int param4 = 0)
        {
            Console.WriteLine("Using optional parameters");
            int sumTotal = param1 + param2 + param3 + param4;
            return sumTotal;
        }
    }
}
