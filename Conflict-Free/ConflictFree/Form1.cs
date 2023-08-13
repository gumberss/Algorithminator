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
                box.Text = String.Join("", chars.Select(x => x.Val));
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        List<Character> text1 = new List<Character>();
        List<Character> text2 = new List<Character>();

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            var point = textBox1.SelectionStart;

            Task.Run(() =>
            {
                
                var near = point - 1 >= 0 ? text1[point - 1] : null;
                var key = $"{point}_node1";
                var c = new Character(key, ((char)e.KeyValue).ToString(), near?.Key);
                Conflict.ProcessConflict(text1, c);
                Thread.Sleep(2000);
                Conflict.ProcessConflict(text2, c);
                SetText(textBox2, text2);
            });
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            var point = textBox2.SelectionStart;

            Task.Run(() =>
            {
                var near = point - 1 >= 0 ? text2[point - 1] : null;
                var key = $"{point}_node2";
                var c = new Character(key, ((char)e.KeyValue).ToString(), near?.Key);
                Conflict.ProcessConflict(text2, c);
                Thread.Sleep(2000);
                Conflict.ProcessConflict(text1, c);
                SetText(textBox1, text1);
            });
        }
    }
}