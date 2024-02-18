namespace _6_soft_1_converter
{
    public static class Converter_p1_10
    {
        public static double ConvertValue(string number, int p1)
        {
            int weightPower;
            string numberWithoutDelimeter = number;
            int delimeterPosition = number.IndexOf('.');

            if (delimeterPosition != -1)
            {
                weightPower = delimeterPosition - 1;
                numberWithoutDelimeter = numberWithoutDelimeter.Remove(delimeterPosition, 1);
            }
            else
                weightPower = number.Length - 1;
            weightPower = Convert.ToInt32(Math.Pow(p1, weightPower));

            return P1ToTen(numberWithoutDelimeter, p1, weightPower);
        }

        private static double P1ToTen (string number, int p1, int weight)
        {
            double result = 0;

            for (int i = 0; i < number.Length; i++)
                result += weight * Editor.alphabet.IndexOf(number[i]) / Math.Pow(p1, i);

            return result;
        }
    }
}
