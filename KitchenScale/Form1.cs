namespace KitchenScale
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text|*.txt|All|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(openFileDialog1.FileName);
            }
        }
    }
}