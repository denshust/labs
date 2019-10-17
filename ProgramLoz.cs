using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1_Лозунговый
{
    class Program
    {
        static void Main()
        {
            Console.Write("Лозунг: ");
            var slogan = Console.ReadLine();

            var cipher = new SloganCipher(slogan);

            Console.Write("Текст для шифрования: ");
            var text = Console.ReadLine();

            var cipheredText = cipher.Cipher(text);
            Console.WriteLine("Зашифрованный текст: {0}", cipheredText);

            var decipheredText = cipher.Decipher(cipheredText);
            Console.WriteLine("Расшифрованный текст: {0}", decipheredText);

            Console.ReadKey();
        }
    }
}
