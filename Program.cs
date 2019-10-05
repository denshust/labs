using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pw1._6
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] numbers = { -127, -112, -102 };

			
				  
			Console.WriteLine("Число: {0}, Формат плавающей точки: {1}",
				numbers[0],
                BinarySystem.FloatingPoint(numbers[0])
            );
            Console.WriteLine("Число: {0}, Формат плавающей точки: {1}",
                numbers[1],
                BinarySystem.FloatingPoint(numbers[1])
            );
            Console.WriteLine("Число: {0}, Формат плавающей точки: {1}",
                numbers[2],
                BinarySystem.FloatingPoint(numbers[2])
            );

            Console.WriteLine("Число: {0}, IEEE754: {1}",
				numbers[0],
                BinarySystem.IEEE754(numbers[0])
            ); Console.WriteLine("Число: {0}, IEEE754: {1}",
                numbers[1],
                BinarySystem.IEEE754(numbers[1])
            ); Console.WriteLine("Число: {0}, IEEE754: {1}",
                numbers[2],
                BinarySystem.IEEE754(numbers[2])
            );

           

            Console.ReadKey();
		}
	}
}
