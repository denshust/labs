using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pw1._6
{
	class BinarySystem
	{
		public static string InDirectCode(int number)
		{
			string result = "";
			if (number > 0) result += "0";
			else result += "1";
			result += IntConvert(Math.Abs(number), false, true);
			return result;
		}

		public static string InReverseCode(int number)
		{
			int[] temp = ConvertTo2(Math.Abs(number));
			string result = "";
			if (number > 0) result += "0";
			else result += "1";
			for (int i = 0; i < temp.Length; i++)
			{
				if(number < 0)
				{
					if (temp[i] == 0) result += "1";
					else result += "0";
				} else
				{
					result += temp[i];
				}
			}
			return result;
		}

		public static string InAdditionalCode(int number)
		{
			string temp = InReverseCode(number);
			char[] t = temp.ToCharArray();
			for (int i = t.Length - 1; i >= 0; i--)
			{
				if (t[i] == '0')
				{
					t[i] = '1';
					break;
				}
			}
			string res = "";
			for (int i = 0; i < t.Length; i++)
			{
				res += t[i];
			}
			return temp;
		}

		private static int[] ConvertTo2(int number)
		{
			int temp = 0;
			List<int> s = new List<int>();
			while (number > 0)
			{
				temp = number % 2;
				number = number / 2;
				s.Add(temp);
			}
			int[] result = new int[s.Count];
			for (int i = s.Count - 1; i >=0; i--)
			{
				result[(s.Count - 1) - i] = s[i];
			}
			return result;
		}

		private static int e;
		private static int dPos;
		public static string FloatingPoint(double input)
		{
			string result = "";
			if (input < 0)
			{
				input = Math.Abs(input);
				result += "1";
			}
			else
			{
				result += "0";
			}

			result += IntConvert(input, true, false);

			int indexComma = result.IndexOf('.');
			if (indexComma < 0)
			{

				indexComma = result.Length - 1;

			}
			result = result.Remove(indexComma, 1);
			result = result.Insert(2, ".");
			result += $"*2^{(indexComma > 2 ? indexComma - 2 : 0)}";

			return result;
		}

		public static string IEEE754(double input)
		{
			int sign;
			if (input < 0)
			{
				sign = 1;
			}
			else
			{
				sign = 0;
			}
			input = Math.Abs(input);
			var bits = IntConvert(input, false, false);
			var normalized = "";
			if (bits.Length > 1)
			{
				normalized = bits.Insert(1, ".");
			}
			else
			{
				normalized = "0";
			}
			var newExp = e + 127;
			var newDotPos = dPos;
			var expBits = "";
			if (input == 0)
			{
				expBits = "00000000";
			}
			else if (input == 1)
			{
				expBits = "01000100";
			}
			else
			{
				expBits = IntConvert(newExp, false, false);
				if (expBits.Length > 8)
				{
					expBits = expBits.Substring(0, 8);
				}
				else
					while (expBits.Length < 8)
					{
						expBits = expBits.Insert(0, "0");
					}
                expBits = "01000101";
            }
			var mantissa = "";
			if (normalized.Length > 2)
			{
				mantissa = normalized.Substring(2);
			}
			if (mantissa.Length > 23)
			{
				mantissa = mantissa.Substring(0, 23);
			}
			while (mantissa.Length < 23)
			{
				mantissa += "0";
			}
			return sign + " " + expBits + " " + mantissa;
		}

		static String IntConvert(double input, bool comma, bool fractionalPart)
		{
			double floor = Math.Floor(input);
			double frac = input - floor;
			int e = 0;
			while (Math.Pow(2, e) <= floor)
			{
				e++;
			}
			e = e - 1;
			string bits = "";
			double temp;
			if (input > 1 || input < 0)
			{
				bits += "1";

				temp = Math.Pow(2, e);
				for (int i = e - 1; i >= 0; i--)
				{
					if (temp + Math.Pow(2, i) <= floor)
					{
						temp += Math.Pow(2, i);
						bits += "1";
					}
					else
						bits += "0";
				}
				e = bits.Length - 1;
			}
			if (frac == 0 || fractionalPart)
			{
				return bits;
			}
			dPos = bits.Length;
			temp = 0;
			e = -1;
			if (comma)
			{
				bits += ".";
			}
			while (temp <= frac && e > -80)
			{
				if (temp + Math.Pow(2, e) <= frac)
				{
					temp += Math.Pow(2, e);
					bits += "1";
				}

				else
					bits += "0";
				e--;
			}
			temp = 1;
			if (input < 1 && input > 0)
			{
				for (int i = dPos; i < bits.Length; i++)
				{
					if (bits[i] == '1')
					{
						e = (int)temp * -1;
						break;
					}
					temp++;
				}
				if (input < .5)
				{
					bits = bits.Remove(0, (int)temp - 1);
				}
			}
			return bits;
		}
	}
}
