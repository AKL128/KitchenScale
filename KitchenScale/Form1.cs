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

        private int resizeMultiplier = 1;

        Dictionary<string, string> imperialMetric = new Dictionary<string, string>()
        {
            {"tsp", "ml"},
            {"Tbsp", "ml"},
            {"cup", "cup"},
            {"cups", "cups"},
            {"oz", "gram"},
            {"stick", "stick"},
            {"sticks", "sticks"},
        };



        private static string fractionScale(string input, int scale)
        {
            int wholeNumber = 0;
            string fraction;
            int numerator;
            int denominator;
            string? result = "";

            bool hasWholeNumber = false;

            hasWholeNumber = input.Split(" ").Length > 1;

            fraction = input;

            if (hasWholeNumber == true)
            {
                wholeNumber = int.Parse(input.Split(" ")[0]);
                wholeNumber = wholeNumber * scale;
                fraction = input.Split(" ")[1];
            }

            numerator = int.Parse(fraction.Split("/")[0]);

            denominator = int.Parse(fraction.Split("/")[1]);


            numerator = numerator * scale;

            Fraction fraction1 = new Fraction(numerator, denominator);
            if (numerator >= denominator)
            {
                wholeNumber += numerator / denominator;
            }

            int quotient = fraction1.getNumerator / fraction1.getDenominator;
            Debug.WriteLine("Q: " + quotient);
            int remainder = fraction1.getNumerator - fraction1.getDenominator * quotient;
            Debug.WriteLine(fraction1.getNumerator + "-" + fraction1.getDenominator + "*" + quotient);
            fraction1 = new Fraction(remainder, denominator);

            fraction1 = fraction1.reduce();

            Debug.WriteLine($"{fraction1.getNumerator} / {fraction1.getDenominator}");
            if (wholeNumber == 0)
            {
                return result = fraction1.getString();
            }
            else
            {
                result = wholeNumber.ToString();
                result += " " + fraction1.getString();
                return result;
            }
            


            return result;
        }

        private static string unitStandard(string input)
        {
            string unit = input.Trim().ToLower();
            if (unit == "teaspoon" || unit == "teaspoons" || unit == "tsp")
            {
                return "tsp";
            }

            if (unit == "tablespoon" || unit == "tablespoons" || unit == "tbsp")
            {
                return "Tbsp";
            }

            if (unit == "cup" || unit == "cups")
            {
                return "cup";
            }

            if (unit == "ounce" || unit == "ounces" || unit == "oz")
            {
                return "oz";
            }

            if (unit == "stick" || unit == "sticks")
            {
                return unit.Trim().ToLower();
            }

            return "ERROR";
        }

        private static string roundUnit(string unit)
        {

            return unit;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text|*.txt|All|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                filePath = openFileDialog1.FileName;
                try
                {
                    StreamReader sr = new StreamReader(filePath);

                    string firstLine = sr.ReadLine();

                    int count = 0;

                    string amount;
                    string unit;
                    string ingredient;

                    string leftOver;

                    foreach (char c in firstLine)
                    {
                        if (Char.IsLetter(c))
                        {
                            break;
                        }
                        count++;
                    }

                    amount = firstLine.Substring(0, count).TrimEnd();
                    leftOver = firstLine.Substring(count).TrimEnd();

                    unit = leftOver.Split(" ", 2)[0];
                    ingredient = leftOver.Split(" ", 2)[1];

                    string standardized = unitStandard(unit);
                    Debug.WriteLine(standardized);
                    if (imperialMetric.ContainsKey(standardized))
                    {
                        comboBox1.SelectedIndex = 1;
                    }
                    else if (imperialMetric.ContainsValue(standardized))
                    {
                        comboBox1.SelectedIndex = 2;
                    }
                    else
                    {
                        comboBox1.SelectedIndex = 1;
                    }
                }
                catch
                {
                    MessageBox.Show("Error opening file");
                }
                textBox1.Text = openFileDialog1.FileName;


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
                using (StreamWriter sw = new StreamWriter("NewRecipe.txt"))
                {

                    string line;



                    while ((line = sr.ReadLine()) != null)
                    {
                        int count = 0;
                        string amount;
                        string leftOver;

                        string unit;
                        string ingredient;

                        int temp;
                        string scaled;

                        foreach (char c in line)
                        {
                            if (Char.IsLetter(c))
                            {
                                break;
                            }
                            count++;
                        }

                        amount = line.Substring(0, count).TrimEnd();
                        Debug.WriteLine(amount);
                        leftOver = line.Substring(count).TrimEnd();
                        Debug.WriteLine(leftOver);

                        unit = leftOver.Split(" ", 2)[0];
                        ingredient = leftOver.Split(" ", 2)[1];

                        if (amount.Contains('/'))
                        {
                            scaled = fractionScale(amount, resizeMultiplier);
                        }
                        else
                        {
                            temp = int.Parse(amount) * resizeMultiplier;
                            scaled = temp.ToString();
                        }

                        sw.WriteLine(scaled + " " + unit + " " + ingredient);
                    }

                }

                sr.Close();

            }
            catch (Exception err)
            {
                MessageBox.Show("No File selected. Please select a file to run program.");
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox2.SelectedIndex)
            {
                case 0:
                    resizeMultiplier = 2;
                    break;
                case 1: 
                    resizeMultiplier = 3;
                    break;
                case 2: 
                    resizeMultiplier = 4;
                    break;
                case 3: 
                    resizeMultiplier = 5;
                    break;
                default: 
                    resizeMultiplier = 1; 
                    break;
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
            if (numerator == 0)
            {
                return "";
            }
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