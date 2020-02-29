using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1a_multiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the first signed number");
            int multiplicand = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the second signed number");
            int multiplier = int.Parse(Console.ReadLine());
            Evaluate(multiplicand, multiplier);
            Console.ReadKey();
        }

        public static void Evaluate(int multiplicand, int multiplier)
        {
            Int64 P = 0;
            bool same_signs = true;
            string A_bits = ToBinary(multiplicand), B_bits = ToBinary(multiplier);
            Console.WriteLine("\tMultiplicand: {0}", A_bits);
            Console.WriteLine("\tMultiplier: {0}", B_bits);

            if (multiplicand * multiplier < 0)
            {
                same_signs = false;
            }

            if (multiplicand < 0)
            {
                multiplicand = ~multiplicand + 1;
                Console.WriteLine("\nMultiplicand is negative number: we'll work with complement code");
                A_bits = ToBinary(multiplicand);
                Console.WriteLine("Multiplicand:\t" + A_bits);
            }

            if (multiplier < 0)
            {
                multiplier = ~multiplier + 1;
                Console.WriteLine("\nMultiplicand is negative number: we'll work with complement code");
                B_bits = ToBinary(multiplier);
                Console.WriteLine("Multiplier:\t" + B_bits);
            }

            Console.WriteLine("Multiply as is:");
            for (int i = 1; i < 17; ++i)
            {
                Console.WriteLine("  Step " + i + ":");
                if ((multiplier & 1) == 1)
                {
                    Console.WriteLine("  \tAdd Multiplicand:\t{0}\n\tTo Product:\t\t{1}", A_bits, ToBinary(P));
                    P += multiplicand;
                }
                Console.WriteLine("  \tProduct :\t\t{0}", ToBinary(P));

                Console.WriteLine("  \tShift Multiplicand left:" + ToBinary(multiplicand));
                multiplicand <<= 1;
                Console.WriteLine("  \t\t\t\t" + ToBinary(multiplicand));

                Console.WriteLine("  \tShift Multiplier right:\t" + ToBinary(multiplier));
                multiplier >>= 1;
                Console.WriteLine("  \t\t\t " + ToBinary(multiplier));
            }
            if (!same_signs)
            {
                P = ~P + 1;
                Console.WriteLine("\n  Result is complement code, because our multiplicands have different sign");
            }
            Console.WriteLine("  Answer is:\n\tIn decemal: {0}\n\tIn binary: {1}", P, ToBinary(P));






        }

        public static string ToBinary(Int64 num)
        {
            string binary = string.Empty;
            for (int i = 1; i < 33; ++i)
            {
                binary = (i % 4 == 0 ? " " : "") + (num & 1) + binary;
                num >>= 1;
            }
            return binary;
        }
    }
}
