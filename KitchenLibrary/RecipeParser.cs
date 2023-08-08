using KitchenLibrary;
using System.Diagnostics;

namespace KitchenLibrary
{
    public static class RecipeParser
    {
        private static readonly Dictionary<string, string> imperialMetric = new Dictionary<string, string>()
        {
            {"tsp", "ml"},
            {"Tbsp", "ml"},
            {"cup", "cup"},
            {"cups", "cups"},
            {"oz", "gram"},
            {"stick", "stick"},
            {"sticks", "sticks"},
        };

        public static List<Ingredient> inputIngredient(string filePath)
        {
            List<Ingredient> recipeList = new List<Ingredient>();
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
                        string name;

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
                        leftOver = line.Substring(count).TrimEnd();

                        unit = leftOver.Split(" ", 2)[0];
                        unit = KitchenCalculator.unitStandard(unit);

                        name = leftOver.Split(" ", 2)[1];

                        Ingredient component = new Ingredient(amount, unit, name);

                        recipeList.Add(component);

/*                      
 *                      
                        if (imperialSelected == true)
                        {
                            if (amount.Contains('/'))
                            {
                                scaled = KitchenCalculator.getResized(amount, resizeMultiplier);
                            }
                            else
                            {
                                temp = int.Parse(amount) * resizeMultiplier;
                                scaled = temp.ToString();
                            }
                        }
                        else if (metricSelected == true)
                        {

                        }
                        else
                        {
                            MessageBox.Show("No measuring system selected");
                        }

                        

                        sw.WriteLine(scaled + " " + unit + " " + ingredient);*/
                    }

                }

                sr.Close();

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.ToString());
            }

            return recipeList;
        }

        public static void outputRecipe(string outputPath, List<Ingredient> recipeList, int resizeMultiplier)
        {
            using (StreamWriter sw = new StreamWriter(outputPath))
            {
                Ingredient[] recipeArray = recipeList.ToArray();
                string measuringSystem = getMeasuringSystem(recipeArray[0].getUnit());
                string scaled;
                int temp;
                if (measuringSystem == "imperial")
                {
                    for (int i = 0; i < recipeArray.Length; i++)
                    {
                        string amount = recipeArray[i].getAmount();
                        string unit = recipeArray[i].getUnit();
                        string name = recipeArray[i].getName();

                        if (amount.Contains('/'))
                        {
                            scaled = KitchenCalculator.getResized(amount, resizeMultiplier);
                        }
                        else
                        {
                            temp = int.Parse(amount) * resizeMultiplier;
                            scaled = temp.ToString();
                        }

                        sw.WriteLine(scaled + " " + unit + " " + name);
                    }
                }
                if (measuringSystem == "metric")
                {

                }
            }
        }

        public static string getMeasuringSystem(string standardizedUnit)
        {
            string measuringSystemSelected = "";

            if (imperialMetric.ContainsKey(standardizedUnit))
            {
                //comboBox1.SelectedIndex = 1;
                measuringSystemSelected = "imperial";
            }
            else if (imperialMetric.ContainsValue(standardizedUnit))
            {
                //comboBox1.SelectedIndex = 2;
                measuringSystemSelected = "metric";
            }
            else
            {
                //comboBox1.SelectedIndex = 1;
                measuringSystemSelected = "imperial";
            }
            return measuringSystemSelected;
        }
    }
}