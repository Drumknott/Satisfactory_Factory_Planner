// See https://aka.ms/new-console-template for more information
using Satisfactory_Objects;
using Satisfactory_Objects.Buildings;
using Satisfactory_Objects.Enums;
using Satisfactory_Objects.Recipes;

//Test_JSON test = new();
//test.TestJSON();
//Console.ReadKey();

Recipe_List recipes = new();

while (true)
{
    Console.WriteLine("\n1 > Plan a Factory");
    Console.WriteLine("2 > Use a Harddrive to unlock a recipe");
    Console.WriteLine("3 > Unlock recipe (test method)");
    Console.WriteLine("0 > Quit");

    switch (Console.ReadLine())
    {
        case "1":
            Output output = new Output();

            Console.WriteLine("\nWhat would you like to build?");
            var userInput = Console.ReadLine();

            Console.WriteLine("\nHow many per minute?");
            var targetRate = Convert.ToDecimal(Console.ReadLine());

            if (userInput != null)
            {
                var isTrue = Enum.TryParse(userInput, out Items item);
                if (!isTrue)
                {
                    Console.WriteLine("I'm sorry I don't recognise that item. Try again");
                    break;
                }

                Dictionary<Items, decimal> keyItem = new Dictionary<Items, decimal>();
                keyItem.Add(item, targetRate);

                FactoryBuilder factory = new(recipes);
                factory.PlanFactory(keyItem, output);

                output.PrintOutput();
            }
            else Console.WriteLine("Error. Try again");
            break;
        case "2":
            Console.WriteLine("Which recipe do you want to unlock?\n");

            Alternative_Recipes altRecipes = new();
            for (int i = 0; i < altRecipes.altRecipes.Count; i++)
            {
                Console.WriteLine($"{i}: {altRecipes.altRecipes[i]}");
            }
            int input = Convert.ToInt32(Console.ReadLine());
            var unlocked = UnlockRecipe(input, altRecipes.altRecipes);

            Console.WriteLine($"Recipe Unlocked: {unlocked}");
            break;
        case "3":
            Console.WriteLine("What resource do you want to unlock a recipe for?");
            var chosenResource = Console.ReadLine();
            var success = Enum.TryParse(chosenResource, out Items result);
            if (success)
            {
                int i = 1;
                List<int> tempList = new List<int>();

                foreach (Recipe recipe in recipes.fullRecipeList)
                {
                    if (recipe.ItemProduced.Key == result)
                    {
                        Console.WriteLine($"{i}. {recipe.ItemProduced.Key} = {recipe.Resources.Keys}");
                        tempList[i] = recipes.fullRecipeList.IndexOf(recipe);
                    }
                }

                Console.WriteLine("Which recipe do you want to unlock?");
                int userchoice = Convert.ToInt32(Console.ReadLine());

                recipes.fullRecipeList[tempList[userchoice]].AlternateRecipe.Value = true;
                
                
            }
            break;
        case "0": return;
        default:
            Console.WriteLine("\nError. Try again\n");
            break;
    }
}

string UnlockRecipe(int input, List<bool> altRecipes)
{

    if (altRecipes[input] == false)
    {
        altRecipes[input] = true;
    }
    return $"{altRecipes[input]}";


}

