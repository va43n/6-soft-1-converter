namespace _6_soft_1_converter
{
    public class Controller
    {
        public enum State { Editing, Converted };
        public State St { get; set; }
        public int p1 { get; set; }
        public int p2 { get; set; }

        public Editor editor = new Editor();

        public History history = new History();

        public Controller(int p01, int p02)
        {
            p1 = p01;
            p2 = p02;
        }

        public string ButtonClicked(int tag)
        {
            if (tag == 19)
            {
                double number_10;
                string number_p2;

                number_10 = Converter_p1_10.ConvertValue(editor.firstNumber, p1);
                number_p2 = Converter_10_p2.ConvertValue(number_10, p2, CalculateAccuracy());
                St = State.Converted;
                if (editor.firstNumber == "")
                    history.AddRecord(p1, p2, "0", "0");
                else
                    history.AddRecord(p1, p2, editor.firstNumber, number_p2);
                return number_p2;
            }
            else
            {
                St = State.Editing;
                return editor.EditSomething(tag);
            }
        }

        private int CalculateAccuracy()
        {
            return (int)Math.Round(editor.GetAccuracy() * Math.Log(p1) / Math.Log(p2) + 0.5);
        }
    }
}
