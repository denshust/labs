using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz1._5
{
    class Program
    {
        public static int NOD(int a, int b)
        {
            if (a == b)
                return a;
            else
                if (a > b)
                return NOD(a - b, b);
            else
                return NOD(b - a, a);
        }
        static void Main(string[] args)
        {
            int p = 23;
            int q = 41;
            int modulus = p * q;
            int f = (p - 1) * (q - 1);
            int e = 0;
            for (int i = 2; i < f; i++)
            {
                if (NOD(i , f) == 1)
                {
                    e = i;
                    break;
                }
            }
            string word = "все працює";
            Console.Write("\nRSA: ");
            Cipher.RSACipher(5, 21, e, word);
            Console.Write("\nElgamal: ");
            Cipher.ElgamalCipher(37, "пари");
            Console.Write("\nKnapsack: ");
            Cipher.Knapsack("захист даних", new int[] { 2, 7, 11, 21, 42, 89, 180, 354 });

            Console.ReadKey();
        }
    }
}
