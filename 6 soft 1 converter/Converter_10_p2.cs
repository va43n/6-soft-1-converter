namespace _6_soft_1_converter
{
	public static class Converter_10_p2
	{
		public static string ConvertValue(double number, int p2, int c)
		{
			if (number == Math.Floor(number))
				return TenToInt(Convert.ToInt32(number), p2);
			else
				return TenToInt(Convert.ToInt32(Math.Floor(number)), p2) + "." + TenToDouble(number - Math.Floor(number), p2, c);
		}

		private static string TenToInt(int number, int p2)
		{
			string s = "", temp;

			if (number == 0)
				return "0";

			while (number >= 1)
			{
				temp = Editor.alphabet[number % p2].ToString();

                s = s.Insert(0, temp);
				number /= p2;
			}

			return s;
		}

		private static string TenToDouble(double number, int p2, int c)
		{
			string s = "";

			for (int i = 0; i < c && number != 0.0; i++)
			{
				number *= p2;
				s += Editor.alphabet[Convert.ToInt32(Math.Floor(number))];
				number -= Math.Floor(number);
			}

			return s;
		}
	}
}