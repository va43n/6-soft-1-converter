namespace _6_soft_1_converter
{
    public class Editor
    {
        public static string alphabet = "0123456789ABCDEF";
        public static int maxLength = 36;

        public string firstNumber = "0";
        private bool hasDelimeter = false;

        public string EditSomething(int tag)
        {
            if (tag < 16)
                firstNumber = firstNumber == "0" ? alphabet[tag].ToString() : firstNumber + alphabet[tag];
                
            else if (tag == 16 && !hasDelimeter)
            {
                hasDelimeter = true;
                firstNumber += ".";
            }
            else if (tag == 17)
            {
                if (firstNumber.Length == 1)
                {
                    firstNumber = "0";
                    return firstNumber;
                }
                else if (firstNumber[firstNumber.Length - 1] == '.')
                    hasDelimeter = false;
                firstNumber = firstNumber.Remove(firstNumber.Length - 1, 1);
            }
            else if (tag == 18)
            {
                hasDelimeter = false;
                firstNumber = "0";
                return "0";
            }

            return firstNumber;
        }
        public string DeleteUnnecessarySymbols()
        {
            for (int i = firstNumber.Length - 1; i >= 0; i--)
            {
                if (firstNumber[i] != '0' && firstNumber[i] != '.' || !hasDelimeter)
                    break;
                if (firstNumber[i] == '.')
                    hasDelimeter = false;
                firstNumber = firstNumber.Remove(i, 1);
            }
                
            return firstNumber;
        }

        public void CheckDelimeter()
        {
            if (firstNumber.IndexOf(".") == -1)
                hasDelimeter = false;
            else hasDelimeter = true;
        }

        public int GetAccuracy()
        {
            if (!hasDelimeter)
                return 0;

            return firstNumber.Length - firstNumber.IndexOf(".") - 1;
        }
    }
}
