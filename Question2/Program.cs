using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    class Program
    {
        static void Main(string[] args)
        {
            var Total = Calculations(31, 79); //;

            Console.ReadLine();
        }

        public static long Calculations(int a, int b)
        {
            var carry = 0;

            int count = 0;
            int valA = a.ToString().Length;
            int valB = b.ToString().Length;

            while (valA != 0 || valB != 0)
            {
                int x = 0, y = 0;
                if (valA > 0)
                {
                    x = a.ToString()[valA - 1] - '0';
                    valA--;
                }
                if (valB > 0)
                {
                    y = b.ToString()[valB - 1] - '0';
                    valB--;
                }

                var sum = x + y + carry;


                if (sum >= 10)
                {
                    carry = 1;
                    count++;
                }

                else
                    carry = 0;
            }

            return count;

        }
    }
}
