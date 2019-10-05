using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Cryptology6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string dir = "";
            int n, i, sw;
            int sign;
            int[] a = new int[10];
            Console.Write("Введите число : ");
            n = int.Parse(Console.ReadLine());
            if (n < 0) { sign = 1; }
            else sign = 0;
            n = Math.Abs(n);
            for (i = 0; n > 0; i++)
            {
                a[i] = n % 2;
                n = n / 2;
            }

         //
            Console.Write("В прямом коде : {0}|", sign);
            for (int j = i - 1; j >= 0; j--)
            {

                dir+=(a[j]);
            }
            Console.WriteLine(dir);
            //
        
            if (sign == 1)
            {
               
                for (int k = i - 1; k >= 0; k--)
                {
                    if (a[k] == 1)
                    {
                        a[k] = 0;
                    }
                    else
                    {
                        a[k] = 1;
                    }
                }
            }
            
            
                Console.Write("В обратном коде : {0}|", sign);
             string rev = "";
                for (i = i - 1; i >= 0; i--)
                {
                    rev += (a[i]);
                    
                }
            Console.WriteLine(rev);
            char[] ch = rev.ToCharArray();
            int[] b = new int[ch.Length];
            for (int j = 0; j < ch.Length; j++)
            {
                b[j] = Convert.ToInt32(ch[j])-48;
              //  Console.WriteLine(b[j]);

            }

            //
            if (sign == 1)
            {
                int signt = sign;
                /*  char[] dop =  rev.ToArray();


                  Console.WriteLine("зворот"+rev);

                  for (n = dop.Length - 1; n >= 0; n--)
                  {
                      if (signt == 1)
                      {
                          if (dop[n] == '1')
                          {
                              Console.WriteLine("f"+dop[n]);
                              dop[n] = '8';
                          }
                           else 

                           {
                              Console.WriteLine("s"+dop[n]);
                              dop[n] = '7';
                              signt = 0;
                           }
                      }
                  }
                  Console.WriteLine(dop);
                  */

                for (int m = rev.Length - 1; m >= 0; m--)
                {
                    if (signt == 1)
                    {
                        if (ch[m] == '0')
                        {
                            ch[m] = '1';
                            signt = 0;
                        }
                        else
                        {
                            ch[m] = '0';
                            signt = 1;
                        }
                    }
                }
                
                Console.Write("В доп коде : {0}|", sign);
                for (int j = 0; j < ch.Length; j++)
                {
                    Console.Write(ch[j]);
                }
            }
            else
            {
                Console.Write("В доп коде : {0}|", sign);
                for (int j = 0; j < ch.Length; j++)
                {
                    Console.Write(ch[j]);
                }
            }
            Console.ReadKey();

        }
        
    }
}

