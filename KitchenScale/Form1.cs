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