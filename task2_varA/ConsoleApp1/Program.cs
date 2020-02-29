using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2a_dividing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the sign divident");
            int divident = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the sign divisor");
            int divisor = int.Parse(Console.ReadLine());
            Divide(divident, divisor);
            Console.ReadKey();

        }

        static void Divide(int divident, int divisor)
        {


            if (divisor == 0)
            {
                throw new DivideByZeroException();
            }

            var def = string.Empty;
            var dividentAbs = Math.Abs(divident);
            var divisorAbs = Math.Abs(divisor);
            int remainder = 0, quotient = 0;

            if (dividentAbs < divisorAbs)
            {
                quotient = divident;
                def += "Divident < Divisor, so Remainder = Divident , Quotient = 0\n";
            }
            else
            {
                int lenA, lenB, k;
                int temporal = dividentAbs;

                def += $"{Convert.ToString(dividentAbs, 2)} mod Divident\n";
                def += $"{Convert.ToString(divisorAbs, 2)} mod Divisor\n\n";

                for (lenA = 0; temporal != 0; temporal >>= 1, lenA++) ;
                temporal = divisorAbs;
                for (lenB = 0; temporal != 0; temporal >>= 1, lenB++) ;
                k = lenA - lenB;
                divisorAbs <<= k;

                def += $"Divisor align\n";
                def += $"{Convert.ToString(dividentAbs, 2)} mod Divident\n";
                def += $"{Convert.ToString(divisorAbs, 2)} mod Divisor\n\n";
                quotient = dividentAbs + -divisorAbs;
                remainder = quotient < 0 ? 0 : 1;
                def += $"Add Divident & Divisor in additional code\n";
                def += $"Quotient = {Convert.ToString(quotient, 2)} \n";
                def += $"Remainder = {Convert.ToString(remainder, 2)} \n\n";
                for (int i = 0; i < k; i++)
                {
                    divisorAbs >>= 1;
                    def += $"{Convert.ToString(divisorAbs, 2)}  Divisor Right Shift\n";
                    if (quotient < 0)
                    {
                        quotient += divisorAbs;
                        def += $"{Convert.ToString(quotient, 2)} Sum Qoutient & Divisor\n";
                    }
                    else
                    {
                        quotient += -divisorAbs;
                        def += $"{Convert.ToString(quotient, 2)} Sub Qoutient & Divisor\n";
                    }
                    remainder <<= 1;
                    if (quotient >= 0)
                    {
                        remainder++;
                    }

                    def += $"{Convert.ToString(remainder, 2)} Remainder Left Shift {(quotient >= 0 ? "& add 1" : "")}\n\n";
                }
                if (quotient < 0)
                {
                    def += "Determine Qoutient\n";
                    quotient += divisorAbs;
                    def += $"{Convert.ToString(quotient, 2)} Qoutient += |Divisor| \n\n";
                }
                def += "Analyze sign bit of Dividend & Divisor and set sign bit to Remainder and Quotient\n";
                if (divident < 0)
                {
                    if (divisor > 0)
                    {
                        remainder = -remainder;
                    }

                    quotient = -quotient;
                }
                if (divident > 0 && divisor < 0)
                {
                    remainder = -remainder;
                }

                def += $"Remainder = {Convert.ToString(remainder, 2)} Quotient = {Convert.ToString(quotient, 2)}\n";
            }

            Console.WriteLine("def = {0}", def);
            Console.WriteLine("Remainder = {0}, Quotient = {1}", remainder, quotient);
        }
    }
}
