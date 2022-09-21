using Satisfactory_Objects.Buildings;
using Satisfactory_Objects.Enums;
using Satisfactory_Objects.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satisfactory_Objects
{
    public class FactoryBuilder
    {
        Recipe_List recipeList { get; set; }     

        public FactoryBuilder(Recipe_List list)
        {
            recipeList = list;            
        }

        

        public void PlanFactory(Dictionary<Items, decimal> keyItem, Output output)
        {
            if (keyItem.Count != 0)
            {
                foreach (KeyValuePair<Items, decimal> item in keyItem)
                {
                    var currentRecipe = GetRecipe(item);
                    
                    var nextItem = BuildFactory(currentRecipe, item.Value, output);

                    PlanFactory(nextItem, output);
                }                
            }            
        }

        public Recipe GetRecipe(KeyValuePair<Items, decimal> item)
        {
            int i = 1;
            Recipe[] arrayTempRecipes = new Recipe[8];
            List<Recipe> tempRecipes = arrayTempRecipes.ToList<Recipe>();
            

            foreach (Recipe recipe in recipeList.fullRecipeList)
            {
                bool recipeAvailable = false;

                if ((recipe.AlternateRecipe.Key == true && recipe.AlternateRecipe.Value == true) || (recipe.AlternateRecipe.Key == false))
                {
                    recipeAvailable = true;
                }

                if (recipe.ItemProduced.Key == item.Key && recipeAvailable)
                {
                    List<Items> tempList = new List<Items>();
                    foreach (KeyValuePair<Items, decimal> resource in recipe.Resources)
                    {
                        tempList.Add(resource.Key);
                    }

                    Console.WriteLine($"{i}.{recipe.ItemProduced.Key} = {string.Join("; ", tempList)}");
                    tempRecipes[i] = recipe;
                    i++;
                }
            }

            if (i == 2) return tempRecipes[1];
            else
            {
                Console.WriteLine($"\nWhich recipe would you like to use?\n");
                var userChoice = Convert.ToInt32(Console.ReadLine());

                switch (userChoice)
                {
                    default:
                    case 1: return tempRecipes[1];
                    case 2: return tempRecipes[2];
                    case 3: return tempRecipes[3];
                    case 4: return tempRecipes[4];
                    case 5: return tempRecipes[5];
                    case 6: return tempRecipes[6];
                    case 7: return tempRecipes[7];
                    case 8: return tempRecipes[8];
                }
            }
        }

        public Dictionary<Items, decimal> BuildFactory(Recipe chosenRecipe, decimal targetOutput, Output output)
        {
            Dictionary<Items, decimal> result = new Dictionary<Items, decimal>();
            Dictionary<Items, decimal> byproducts = new Dictionary<Items, decimal>();
            int numberOfMachinesNeeded = 1;
            int numberOfPowerShardsNeeded = 0;

            switch (chosenRecipe.Machine)
            {
                case Machines.Assembler:
                case Machines.Smelter:
                case Machines.Constructor:
                case Machines.Manufacturer:
                case Machines.Foundry:
                    IBuilding assembler = new Assembler();
                    (result, numberOfMachinesNeeded, numberOfPowerShardsNeeded) = assembler.Build(chosenRecipe, targetOutput);                    
                    break;
                case Machines.Refinery:
                    Refinery refinery = new();
                    (result, byproducts, numberOfMachinesNeeded, numberOfPowerShardsNeeded) = refinery.Process(chosenRecipe, targetOutput);                    
                    break;
                case Machines.Miner:
                    Miner miner = new();
                    (result, numberOfMachinesNeeded, numberOfPowerShardsNeeded) = miner.Mine(chosenRecipe, targetOutput);                    
                    break;
            }

            //Add results to outputList
            Output(chosenRecipe, result, byproducts, numberOfMachinesNeeded, numberOfPowerShardsNeeded, output);

            return result;
        }

        private void Output(Recipe chosenRecipe, Dictionary<Items, decimal> result, Dictionary<Items, decimal> byproducts, int numberOfMachinesNeeded, int numberOfShardsNeeded,Output output)
        {
            if (byproducts.Count != 0)
            {
                foreach (KeyValuePair<Items, decimal> input in result)
                {
                    output.AddToOutput(input, chosenRecipe.Machine, numberOfMachinesNeeded, numberOfShardsNeeded);
                }
                foreach (KeyValuePair<Items, decimal> _byproduct in byproducts)
                {
                    output.AddToOutput(_byproduct, chosenRecipe.Machine, 0, numberOfShardsNeeded);
                }
            }
            else
            {
                foreach (KeyValuePair<Items, decimal> input in result)
                {
                    output.AddToOutput(input, chosenRecipe.Machine, numberOfMachinesNeeded, numberOfShardsNeeded);
                }
            }
        }
    }
}
