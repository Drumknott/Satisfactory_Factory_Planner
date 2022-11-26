// See https://aka.ms/new-console-template for more information
using Satisfactory_Objects;
using Satisfactory_Objects.Buildings;
using Satisfactory_Objects.Enums;
using Satisfactory_Objects.Recipes;

/*
* Matt - you had to change your Recipe.AlternateRecipe from a KeyValuePair to a new class you wrote, AltRecipeManager, so you can edit the isAltRecipeUnlocked bool.
* This means you now have to go back and edit your JSON data to reflect this. You need to change the Key and Value to isAltRecipe and isAltRecipeUnlocked. 
* COPY THE JSON FILE FIRST IN CASE THIS DOESN'T WORK AND YOU HAVE TO UNDO IT ALL AGAIN
*/




Recipe_List recipes = new();


void Interface_Menu()
{
    while (true)
    {
        //MAIN MENU
        //Console.WriteLine("\n1 > Plan a Factory");
        //Console.WriteLine("2 > Use a Harddrive to unlock a recipe");
        //Console.WriteLine("0 > Quit");

        //switch (Console.ReadLine())
        //{
        //    case "1":
                //Output output = new Output();

                //Console.WriteLine("\nWhat would you like to build?");
                //var userInput = Console.ReadLine();

                //Console.WriteLine("\nHow many per minute?");
                //var targetRate = Convert.ToDecimal(Console.ReadLine());

                //if (userInput != null)
                //{
                //    var isTrue = Enum.TryParse(userInput, out Items item);
                //    if (!isTrue)
                //    {
                //        Console.WriteLine("I'm sorry I don't recognise that item. Try again");
                //        break;
                //    }
                //    FactoryBuilder factory = new(recipes);

                //    Console.WriteLine($"\nDo you want to use Power Shards? Y/N");
                //    var userChoice = Console.ReadLine();
                //    if (userChoice == "Y") factory.usePowerShards = true;
                //    else factory.usePowerShards = false;

                //    //Implement crafting Methods that work without power shards//

                //    Dictionary<Items, decimal> keyItem = new();
                //    keyItem.Add(item, targetRate);

                //    factory.PlanFactory(keyItem, output);

                //    output.PrintOutput();
                //}
                //else Console.WriteLine("Error. Try again");
                //break;
            //case "2":
            //    Console.WriteLine("What resource do you want to unlock a recipe for?");
            //    var chosenResource = Console.ReadLine();
            //    var success = Enum.TryParse(chosenResource, out Items result);
            //    if (success)
            //    {
            //        int i = 1;
            //        List<int> tempList = new List<int>();

            //        foreach (Recipe recipe in recipes.fullRecipeList)
            //        {
            //            if (recipe.ItemProduced.Key == result && recipe.AlternateRecipe.Key == true)
            //            {
            //                Console.WriteLine($"{i}. {recipe.ItemProduced.Key};");
            //                PrintResources(recipe);
            //                tempList.Add(recipes.fullRecipeList.IndexOf(recipe));
            //                i++;

            //                void PrintResources(Recipe recipe)
            //                {
            //                    foreach (KeyValuePair<Items, decimal> resource in recipe.Resources)
            //                    {
            //                        Console.WriteLine($"\t{resource.Key}");
            //                    }
            //                }
            //            }
            //        }

            //        Console.WriteLine("Which recipe do you want to unlock?");
            //        int userchoice = Convert.ToInt32(Console.ReadLine());

            //        recipes.fullRecipeList[tempList[userchoice - 1]].AlternateRecipe.Value = true;

            //        Console.WriteLine($"\nAlternate Recipe Unlocked\n");
            //    }
            //    else Console.WriteLine("error");
            //    break;
            //case "0": return;
            //default:
            //    Console.WriteLine("\nError. Try again\n");
            //    break;
        }
    }
}





