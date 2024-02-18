namespace _6_soft_1_converter
{
    public partial class Interface : Form
    {
        List<Button> buttons = new List<Button>();
        Controller controller;

        public Interface()
        {
            InitializeComponent();

            buttons.AddRange([
                button_0, button_1, button_2, button_3,
                button_4, button_5, button_6, button_7,
                button_8, button_9, button_a, button_b,
                button_c, button_d, button_e, button_f,
                button_delim, button_bs, button_ce, button_eq
            ]);

            foreach (Button button in buttons)
                button.Click += Keyboard_Click;

            TBOfFirstNumber.Scroll += CheckCurrentValueOfFirstNumber;
            TBOfSecondNumber.Scroll += CheckCurrentValueOfSecondNumber;

            CurrentNotationOfFirstNumber.Text = TBOfFirstNumber.Value.ToString();
            EnableUnneñessaryButtons(TBOfFirstNumber.Value);
            CurrentNotationOfSecondNumber.Text = TBOfSecondNumber.Value.ToString();

            controller = new Controller(TBOfFirstNumber.Value, TBOfSecondNumber.Value);

            AllHistory.SelectedIndexChanged += AllHistory_SelectedIndexChanged;
            ClearHistoryButton.Click += ClearHistoryButton_Click;
        }

        private void ClearHistoryButton_Click(object? sender, EventArgs e)
        {
            controller.history.Clear();
            AllHistory.Items.Clear();
            ClearHistoryButton.Enabled = false;
            ClearHistoryButton.Text = "Èñòîðèÿ ïóñòà";
        }

        private void AllHistory_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (AllHistory.SelectedItem == null)
                return;

            Record record = controller.history.records[controller.history.records.Count - AllHistory.SelectedIndex - 1];

            FirstNumber.Text = record.firstNumber;
            SecondNumber.Text = record.secondNumber;
            CurrentNotationOfFirstNumber.Text = record.p1.ToString();
            CurrentNotationOfSecondNumber.Text = record.p2.ToString();
            TBOfFirstNumber.Value = record.p1;
            TBOfSecondNumber.Value = record.p2;
            EnableUnneñessaryButtons(record.p1);

            controller.p1 = record.p1;
            controller.p2 = record.p2;

            controller.editor.firstNumber = record.firstNumber;
            controller.editor.CheckDelimeter();
        }

        private void Keyboard_Click(object? sender, EventArgs e)
        {
            Button button = (Button)sender;
            DoCommand(Convert.ToInt32(button.Tag.ToString()));
        }

        private void DoCommand(int tag)
        {
            string result;

            if (tag == 19)
                FirstNumber.Text = controller.editor.DeleteUnnecessarySymbols();

            try
            {
                result = controller.ButtonClicked(tag);
            }
            catch
            {
                MessageBox.Show("Ââåäåííîå äëÿ ïðåîáðàçîâàíèÿ ÷èñëî ñëèøêîì áîëüøîå");
                return;
            }

            if (controller.St == Controller.State.Editing)
            {
                FirstNumber.Text = result;
                SecondNumber.Text = "0";
            }
            else
                SecondNumber.Text = result;
        }

        private void CheckCurrentValueOfFirstNumber(object? sender, EventArgs e)
        {
            int number = TBOfFirstNumber.Value;

            CurrentNotationOfFirstNumber.Text = TBOfFirstNumber.Value.ToString();
            controller.St = Controller.State.Editing;
            controller.p1 = number;
            FirstNumber.Text = controller.ButtonClicked(18);
            SecondNumber.Text = "0";
            EnableUnneñessaryButtons(number);
        }

        private void EnableUnneñessaryButtons(int notation)
        {
            for (int i = 2; i < notation; i++)
                buttons[i].Enabled = true;

            for (int i = notation; i < 16; i++)
                buttons[i].Enabled = false;
        }

        private void CheckCurrentValueOfSecondNumber(object? sender, EventArgs e)
        {
            int number = TBOfSecondNumber.Value;

            CurrentNotationOfSecondNumber.Text = number.ToString();
            controller.p2 = number;
            if (controller.St == Controller.State.Converted)
            {
                try
                {
                    SecondNumber.Text = controller.ButtonClicked(19);
                }
                catch
                {
                    MessageBox.Show("Ââåäåííîå äëÿ ïðåîáðàçîâàíèÿ ÷èñëî ñëèøêîì áîëüøîå");
                }
            }
        }

        private void Interface_KeyPress(object sender, KeyPressEventArgs e)
        {
            int i = -1;

            if (e.KeyChar >= 'A' && e.KeyChar <= 'F') i = e.KeyChar - 'A' + 10;
            else if (e.KeyChar >= 'a' && e.KeyChar <= 'f') i = e.KeyChar - 'a' + 10;
            else if (e.KeyChar >= '0' && e.KeyChar <= '9') i = e.KeyChar - '0';
            else if (e.KeyChar == '.') i = 16;
            else if (e.KeyChar == 8) i = 17;
            else if (e.KeyChar == 27) i = 18;
            else if (e.KeyChar == 13) i = 19;
            if (i != -1 && (i < controller.p1) || (i >= 16)) DoCommand(i);
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                if (controller.history.records.Count != 0)
                {
                    ClearHistoryButton.Enabled = true;
                    ClearHistoryButton.Text = "Î÷èñòèòü èñòîðèþ";
                    
                    for (int i = controller.history.records.Count - 1; i >= 0; i--)
                        AllHistory.Items.Add(controller.history.records[i].ToString());
                }
            }
            else AllHistory.Items.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
