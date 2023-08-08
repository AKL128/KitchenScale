using System.Diagnostics;
using System.Numerics;
using KitchenLibrary;


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

        private List<Ingredient> recipeList;

        bool metricSelected = false;

        bool imperialSelected = false;

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text|*.txt|All|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                filePath = openFileDialog1.FileName;

                recipeList = RecipeParser.inputIngredient(filePath);
                Ingredient[] recipeArray = recipeList.ToArray();

                string measuringSystem = RecipeParser.getMeasuringSystem(recipeArray[0].getUnit());

                if (measuringSystem == "imperial")
                {
                    comboBox1.SelectedIndex = 1;
                }
                else if (measuringSystem == "metric")
                {
                    comboBox1.SelectedIndex = 2;
                }
                else
                {
                    comboBox1.SelectedIndex = 1;
                }
                textBox1.Text = openFileDialog1.FileName;
                /*try
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

                    string standardized = KitchenCalculator.unitStandard(unit);
                    Debug.WriteLine(standardized);
                    if (imperialMetric.ContainsKey(standardized))
                    {
                        comboBox1.SelectedIndex = 1;
                        imperialSelected = true;
                    }
                    else if (imperialMetric.ContainsValue(standardized))
                    {
                        comboBox1.SelectedIndex = 2;
                        metricSelected = true;
                    }
                    else
                    {
                        comboBox1.SelectedIndex = 1;
                        imperialSelected = true;
                    }
                }
                catch
                {
                    MessageBox.Show("Error opening file");
                }*/



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
                RecipeParser.outputRecipe("NewRecipe.txt", recipeList, resizeMultiplier);

                /*StreamReader sr = new StreamReader(filePath);
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

                        *//*if (imperialSelected == true)
                        {

                        }
                        else if (metricSelected == true)
                        {

                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }*//*

                        if (amount.Contains('/'))
                        {
                            scaled = KitchenCalculator.getResized(amount, resizeMultiplier);
                        }
                        else
                        {
                            temp = int.Parse(amount) * resizeMultiplier;
                            scaled = temp.ToString();
                        }

                        sw.WriteLine(scaled + " " + unit + " " + ingredient);
                    }

                }

                sr.Close();*/

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

    
}