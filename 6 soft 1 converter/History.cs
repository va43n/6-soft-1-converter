namespace _6_soft_1_converter
{
    public struct Record
    {
        public int p1, p2;
        public string firstNumber, secondNumber;

        public Record(int p01, int p02, string num1, string num2)
        {
            p1 = p01;
            p2 = p02;
            firstNumber = num1;
            secondNumber = num2;
        }
        public override string ToString()
        {
            return firstNumber + " (" + p1.ToString() + ") = " + secondNumber + " (" + p2.ToString() + ")";
        }
    }

    public class History
    {
        public List<Record> records = new List<Record>();
        
        public void AddRecord(int p01, int p02, string num1, string num2)
        {
            Record record = new Record(p01, p02, num1, num2);
            records.Add(record);
        }

        public void Clear()
        {
            records.Clear();
        }
    }
}
