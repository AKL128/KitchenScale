using System;
using System.Collections;
using CommandLine;
using KitchenLibrary;

using System.IO;
using System.Runtime.InteropServices;

namespace KitchenScaleConsoleApp
{
    class Program
    {
        
        public static void Main(string[] args)
        {

            CommandLine.Parser.Default.ParseArguments<Options>(args)
                .WithParsed(RunApp)
                .WithNotParsed(HandleParseError);


        }

        public static void RunApp(Options o)
        {
            List<Ingredient> recipeList;
            int resizeMultiplier;

            if (File.Exists(o.FilePath))
            {
                recipeList = RecipeParser.inputIngredient(o.FilePath);
                RecipeParser.outputRecipe(o.Output, recipeList, o.Scaled);


            }
        }

        public static void HandleParseError(IEnumerable<Error> errs)
        {
            Console.WriteLine("errors {0}", errs.Count());
            var result = -1;
            Console.WriteLine("Exit code {0}", result);
        }

        public class Options
        {
            [Value(0, HelpText = "The recipe input file")]
            public string FilePath { get; set; }

            [Option('s', "scaled", Required = true, HelpText = "Recipe resize multiplier (integer only)")]
            public int Scaled { get; set; }


            // TODO: metric system conversion
            [Option('m', "measure", Required = false, HelpText = "Set measuring system <imperial> or <metric>")]
            public int Measure { get; set; }

            [Option('o', "output", Required = true, HelpText = "Set output path for generated recipe file")]
            public string Output { get; set; }         

            [Option('h', "help", Required = false, HelpText = "Usage: KitchenScaleConsoleApp <file input> -s <resize scale> -o <output file>")]
            public string Help { get; set; }

        }
    }
}




