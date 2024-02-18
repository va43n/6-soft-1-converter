namespace _6_soft_1_converter
{
    public class Editor
    {
        public static string alphabet = "0123456789ABCDEF";

        public string firstNumber = "";
        private bool hasDelimeter = false;

        public string EditSomething(int tag)
        {
            if (tag == 0 && firstNumber == "")
                return "0";
            else if (tag < 16)
                firstNumber += alphabet[tag];
            else if (tag == 16 && !hasDelimeter)
            {
                hasDelimeter = true;
                if (firstNumber == "")
                    firstNumber = "0.";
                else
                    firstNumber += ".";
            }
            else if (tag == 17)
            {
                if (firstNumber == "")
                    return "0";
                if (firstNumber[firstNumber.Length - 1] == '.')
                    hasDelimeter = false;
                firstNumber = firstNumber.Remove(firstNumber.Length - 1, 1);
                if (firstNumber == "")
                    return "0";
            }
            else if (tag == 18)
            {
                hasDelimeter = false;
                firstNumber = "";
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
                firstNumber = firstNumber.Remove(i, 1);
            }
            if (firstNumber == "")
                return "0";
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
