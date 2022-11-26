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
        Recipe_List recipes { get; set; }
        public bool usePowerShards { get; set; } = false;

        public FactoryBuilder(Recipe_List _recipes)
        {
            recipes = _recipes;            
        }

        // Given an item and rate of production, return everything needed to produce that item
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


        // Get recipe for key item from full recipe list. Allows user to choose alt recipes
        public Recipe GetRecipe(KeyValuePair<Items, decimal> item)
        {
            List<Recipe> tempRecipes = new();   

            foreach (Recipe recipe in recipes.fullRecipeList)
            {
                if (recipe.ItemProduced.Key == item.Key)
                {
                    bool recipeAvailable = false;

                    if ((recipe.AlternateRecipe.Key == true && recipe.AlternateRecipe.Value == true) || (recipe.AlternateRecipe.Key == false))
                    {
                        recipeAvailable = true;
                    }

                    if (recipeAvailable)
                    {                        
                        tempRecipes.Add(recipe);  
                    }
                }
            }

            if (tempRecipes.Count == 0) Console.WriteLine("Error - No recipe");
            if (tempRecipes.Count() == 1) return tempRecipes[0];
            else
            {
                foreach(Recipe recipe in tempRecipes)
                {
                    string recipeResources = "";
                    foreach(KeyValuePair<Items, decimal> resource in recipe.Resources)
                    {
                        recipeResources += $"{resource.Key}, ";
                    }

                    Console.WriteLine($"{tempRecipes.IndexOf(recipe) + 1}. {recipe.ItemProduced.Key}: {recipeResources}");
                }

                Console.WriteLine($"\nWhich recipe would you like to use?\n");
                var userChoice = Convert.ToInt32(Console.ReadLine()) - 1;
                return tempRecipes[userChoice];             
            }
        }


        // Calculate what and how much is needed to create the current item, add to output list
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
                    (result, numberOfMachinesNeeded, numberOfPowerShardsNeeded) = assembler.Build(chosenRecipe, targetOutput, usePowerShards);                    
                    break;
                case Machines.Refinery:
                    Refinery refinery = new();
                    (result, byproducts, numberOfMachinesNeeded, numberOfPowerShardsNeeded) = refinery.Process(chosenRecipe, targetOutput, usePowerShards);                    
                    break;
                case Machines.Miner:
                case Machines.OilExtractor:
                case Machines.WaterExtractor:
                    Miner miner = new();
                    (result, numberOfMachinesNeeded, numberOfPowerShardsNeeded) = miner.Mine(chosenRecipe, targetOutput, usePowerShards);                    
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
