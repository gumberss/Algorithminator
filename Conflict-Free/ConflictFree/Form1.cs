namespace ConflictFree
{
    delegate void SetTextCallback(TextBox box, List<Character> text);

    // An extremely simple version of Conflict Resolution for Eventual Consistency • Martin Kleppmann • GOTO 2016
    // in video: https://www.youtube.com/watch?v=yCcWpzY8dIA
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SetText(TextBox box, List<Character> chars)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (box.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { box, chars });
            }
            else
            {
                box.Text = String.Join("",
                    chars
                    .Where(c => !c.Deleted)
                    .Select(x => x.Val));
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        List<Character> text1 = new List<Character>();
        List<Character> text2 = new List<Character>();

        int globalValText1 = 0;
        int globalValText2 = 0;

        public Character NearActive(List<Character> chars, int index)
        {
            if (index - 1 < 0) return null;

            return !chars[index - 1].Deleted ? chars[index - 1] : NearActive(chars, index - 1);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            var point = textBox1.SelectionStart;

            if (e.KeyData == Keys.Back)
            {
                if (point == 0) return;

                Task.Run(() =>
                {
                    var removed = text1[point - 1];
                    Conflict.ProcessDeletion(text1, removed);
                    Thread.Sleep(2000);
                    Conflict.ProcessDeletion(text2, removed);
                    SetText(textBox2, text2);
                });
            }
            else
            {

                Task.Run(() =>
                {

                    var near = NearActive(text1.Where(x=> !x.Deleted).ToList(), point);
                    var key = $"{globalValText1++}_node1";
                    var c = new Character(key, ((char)e.KeyValue).ToString(), near?.Key);
                    Conflict.ProcessConflict(text1, c);
                    Thread.Sleep(2000);
                    Conflict.ProcessConflict(text2, c);
                    SetText(textBox2, text2);
                });
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            var point = textBox2.SelectionStart;

            if (e.KeyData == Keys.Back)
            {
                Task.Run(() =>
                {
                    var removed = text2[point - 1];
                    Conflict.ProcessDeletion(text2, removed);
                    Thread.Sleep(2000);
                    Conflict.ProcessDeletion(text1, removed);
                    SetText(textBox2, text1);
                });
            }
            else
            {
                Task.Run(() =>
                {
                    var near = NearActive(text1, point);
                    var key = $"{globalValText2++}_node2";
                    var c = new Character(key, ((char)e.KeyValue).ToString(), near?.Key);
                    Conflict.ProcessConflict(text2, c);
                    Thread.Sleep(2000);
                    Conflict.ProcessConflict(text1, c);
                    SetText(textBox1, text1);
                });
            }
        }
    }
}