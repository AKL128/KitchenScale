using System.Diagnostics;
using System.Numerics;

namespace KitchenScale
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string filePath = "";

        Dictionary<string, string> metricImperial = new Dictionary<string, string>()
        {
            {"gram", "oz"},
            {"g", "oz"},
            {"liter", "qt"},
            {"l", "qt"},
            {"milliliter", "tsp"},
            {"ml", "tsp"},
        };

        private static string fractionScale(string input, int scale)
        {
            int wholeNumber;
            string fraction;
            int numerator;
            int denominator;
            string? result = "";
            
            if (input.Split(" ").Length >= 1)
            {
                
                wholeNumber = int.Parse(input.Split(" ")[0]);
                
                fraction = input.Split(" ")[1];

                numerator = int.Parse(fraction.Split("/")[0]);

                denominator = int.Parse(fraction.Split("/")[1]);

                wholeNumber = wholeNumber * scale;
                numerator = numerator * scale;
                denominator = numerator * scale;

                Fraction fraction1 = new Fraction(numerator, denominator);

                fraction1 = fraction1.reduce();

                result = wholeNumber.ToString();
                result += " " + fraction1.getString();
                return result;
            }
            else
            {
                numerator = int.Parse(input.Split("/")[0]);
                denominator = int.Parse(input.Split("/")[1]);

                numerator = numerator * scale;
                denominator = numerator * scale;

                Fraction fraction1 = new Fraction(numerator, denominator);

                fraction1 = fraction1.reduce();
                result = fraction1.ToString();
                return result;
            }

            return result;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text|*.txt|All|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                MessageBox.Show(openFileDialog1.FileName);
                filePath = openFileDialog1.FileName;
                try
                {
                    StreamReader sr = new StreamReader(filePath);

                    string firstLine = sr.ReadLine();

                    //if (firstLine)
                }
                catch
                {
                    MessageBox.Show("Error opening file");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader(filePath);

                //string contents = sr.ReadToEnd();

                string line;

                /*while ((line = sr.ReadLine()) != null)
                {

                    
                }*/

                line = sr.ReadLine();
                string scaled = fractionScale(line, 2);

                using (StreamWriter sw = new StreamWriter("NewRecipe.txt"))
                {
                    sw.WriteLine(scaled);
                }




                //sr.Close();

            }
            catch (Exception err)
            {
                MessageBox.Show("No File selected. Please select a file to run program.");
            }

        }
    }

    internal class Fraction
    {
        private int numerator;
        private int denominator;
        public Fraction(int n, int d)
        {
            this.numerator = n;
            this.denominator = d;
        }
        public int getNumerator
        {
            get { return this.numerator; }
            set { this.numerator = value; }
        }

        public int getDenominator
        {
            get { return this.denominator; }
            set
            {
                if (value == 0)
                {
                    throw new Exception("0 denominator");
                }

                this.denominator = value;
            }
        }

        public string getString()
        {
            if (denominator == 1)
            {
                return numerator.ToString();
            }
            else
            {
                return numerator.ToString() + "/" + denominator.ToString();
            }
        }

        public static int getGCD(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            else
            {
                return getGCD(b, a % b);
            }
        }

        public Fraction reduce()
        {
            int gcd = getGCD(numerator, denominator);
            return new Fraction(numerator / gcd, denominator / gcd);
        }

        public Fraction multiply(int constant)
        {
            return new Fraction(this.numerator * constant, this.denominator);
        }
    }
}