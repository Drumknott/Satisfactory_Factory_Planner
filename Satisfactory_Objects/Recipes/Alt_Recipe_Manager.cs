using Satisfactory_Objects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satisfactory_Objects.Recipes
{
    public class Alt_Recipe_Manager
    {
        public void UnlockAltRecipe(Items item, Recipe_List recipes)
        {
            List<int> tempList = new();
            int i = 1;

            foreach (Recipe recipe in recipes.fullRecipeList)
            {
                if (recipe.ItemProduced.Key == item && recipe.AlternateRecipe.Key == true)
                {
                    Console.WriteLine($"{i}. {recipe.ItemProduced.Key};");
                    PrintResources(recipe);
                    tempList.Add(recipes.fullRecipeList.IndexOf(recipe));
                    i++;

                    void PrintResources(Recipe recipe)
                    {
                        foreach (KeyValuePair<Items, decimal> resource in recipe.Resources)
                        {
                            Console.WriteLine($"\t{resource.Key}");
                        }
                    }
                }
            }

            Console.WriteLine("Which recipe do you want to unlock?");
            int userchoice = Convert.ToInt32(Console.ReadLine());

            recipes.fullRecipeList[tempList[userchoice - 1]].AlternateRecipe.Value = true;

            Console.WriteLine($"\nAlternate Recipe Unlocked\n");
        }        
    }
}
