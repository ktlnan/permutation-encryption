namespace инфбез2
{
    public partial class Form1 : Form
    {
        transport t;
        public Form1()
        {
            InitializeComponent();
            t= new transport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            t.SetKey(keytextBox.Text);
            if(radioButton1.Checked )
            {
                outputtextBox.Text=t.Encrypt(inputtextBox.Text);
            }
            else
            {
                outputtextBox.Text = t.Decrypt(inputtextBox.Text);
            }
        }
    }
}