using Basic_UI;
using Satisfactory_Objects;
using Satisfactory_Objects.Enums;
using Satisfactory_Objects.Recipes;

// An app to act as companion for the videogame Satisfactory, a game about building factories consisting of crafting machines and processing various materials and items to construct other items

internal class Program
{
    private static void Main(string[] args)
    {
        Recipe_List recipes = new();
        MainMenu menu = new();

        while (true)
        {
            string userChoice = menu.MenuInterface();

            switch (userChoice)
            {
                // Build a factory
                case "1":
                    FactoryBuilder factory = new(recipes);
                    Output output = new();

                    (Items item, decimal targetRate) = menu.FactoryRequirements();

                    factory.usePowerShards = menu.PowerShards();

                    Dictionary<Items, decimal> keyItem = new();
                    keyItem.Add(item, targetRate);

                    factory.PlanFactory(keyItem, output);

                    output.PrintOutput();

                    break;

                // Unlock a new recipe
                case "2":
                    Items chosenItem = menu.GetHardDriveInfo();

                    Alt_Recipe_Manager recipeManager = new();
                    recipeManager.UnlockAltRecipe(chosenItem, recipes);

                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;
            }
        }
    }
}