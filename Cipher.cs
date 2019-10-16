using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz1._5
{
    class Cipher
    {
        static string alph = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя ";
        public static string convertToBinary(int temp)
        {
            int temp1 = 0;
            if (temp < 0) temp = -temp;
            List<int> s = new List<int>();
            while (temp > 0)
            {
                temp1 = temp % 2;
                temp = temp / 2;
                s.Add(temp1);
            }
            temp = obrat(s);
            string add = "";
            if (Convert.ToString(temp).Length < 8)
            {
                add = new string('0', 8 - Convert.ToString(temp).Length);
            }
            add += Convert.ToString(temp);
            return add;
        }
        //переворачивает число и возвращает прямую запись двоичного числа.
        private static int obrat(List<int> norm)
        {
            int[] s = new int[norm.Count];
            for (int i = norm.Count - 1; i >= 0; i--)
            {
                s[norm.Count - 1 - i] = norm[i];
            }
            return Convert.ToInt32(string.Join<int>("", s));
        }
        public static double[] Knapsack(string message, int[] knapsack)
        {
            double[] cipher = new double[message.Length];
            byte[] res1 = System.Text.Encoding.Default.GetBytes(message);
            for (int i = 0; i < cipher.Length; i++)
            {
                string tmp = convertToBinary(res1[i]);
                int sum = 0;
                for (int k = 0; k < tmp.Length; k++)
                {
                    if (tmp[k] == '1')
                    {
                        sum += knapsack[k];
                    }
                }
                cipher[i] = sum;
                Console.Write(cipher[i]+" ");
            }

            
            return cipher;
        }
        public static List<KeyValuePair<double, double>> ElgamalCipher(int p, string message)
        {
            int[] result = new int[message.Length];
            int[] posArray = new int[message.Length];
            List<KeyValuePair<double, double>> ciph = new List<KeyValuePair<double, double>>();
            message = message.ToLower();
            for (int i = 0; i < posArray.Length; i++)
            {
                posArray[i] = alph.IndexOf(message[i]) + 1;
            }
            int f = p - 1;
            int g = 0;
            int counter = 2;
            while (g == 0)
            {
                System.Numerics.BigInteger t1 = System.Numerics.BigInteger.Pow(counter, f);
                if (t1 % p == 1)
                {
                    g = counter;
                }
                counter++;
            }
            Random rnd = new Random();
            //int x = rnd.Next(1, p);
            int x = 5; // зак. кл.
            int y = Convert.ToInt32(Math.Pow(g, x)) % p;
            for (int i = 0; i < posArray.Length; i++)
            {
                int k = rnd.Next(1, p - 1);
                Console.Write(k+" ");
                //int k = 7;
                ciph.Add(new KeyValuePair<double, double>(Math.Pow(g, k) % p, Math.Pow(y, k) * posArray[i] % p));
            }
            return ciph;
        }
        public static string ElgamalDecipher(List<KeyValuePair<double, double>> ciph, int x, int p)
        {
            string message = "";
            for (int i = 0; i < ciph.Count; i++)
            {
                System.Numerics.BigInteger t1 = System.Numerics.BigInteger.Pow((int)ciph[i].Key, p - 1 - x);
                t1 = t1 *  (System.Numerics.BigInteger)ciph[i].Value;
                message += alph[(int)(t1 % p) - 1];
            }                   
            return message;
        }
        public static int[] RSACipher(int p, int q, int e, string message)
        {
            int[] result = new int[message.Length];
            message = message.ToLower();
            int[] posArray = new int[message.Length];
            //int[] cipherArray = new int[message.Length];
            for (int i = 0; i < posArray.Length; i++)
            {
                posArray[i] = alph.IndexOf(message[i]) + 1;
            }
            for (int i = 0; i < posArray.Length; i++)
            {
                result[i] = Convert.ToInt32(Math.Pow(posArray[i], e) % (p*q));
                Console.Write(result[i]+" ");
            }
            return result;
        }
        public static string RSADecipher(int n, int f, int e, int[] message)
        {
            int d = 0;
            int counter = 1;
            string result = "";
            while (d == 0)
            {
                if (Math.Truncate(Convert.ToDouble((1 + counter * f) / e)) * e % f == 1)
                {
                    d = Convert.ToInt32(Math.Truncate(Convert.ToDouble((1 + counter * f) / e)));
                }
                counter++;
            }
            for (int i = 0; i < message.Length; i++)
            {
                System.Numerics.BigInteger t1 = System.Numerics.BigInteger.Pow(message[i], d);
                result += alph[(int)(t1 % n) - 1];
            }
            return result;
        }
    }
}
