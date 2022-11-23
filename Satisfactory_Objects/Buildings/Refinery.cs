using Satisfactory_Objects.Enums;
using Satisfactory_Objects.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satisfactory_Objects.Buildings
{
    internal class Refinery : IBuilding
    {
        public (Dictionary<Items, decimal>, Dictionary<Items, decimal>, int, int) Process(Recipe recipe, decimal targetOutput, bool usingPowerShards)
        {
            decimal overclockSpeed;
            int numberOfMachinesNeeded;
            int numberOfPowerShardsNeeded;
            Dictionary<Items, decimal> input = new Dictionary<Items, decimal>();

            if (usingPowerShards)
            {
                overclockSpeed = targetOutput / recipe.ItemProduced.Value;
                numberOfMachinesNeeded = 1;
                numberOfPowerShardsNeeded = (int)Math.Ceiling(overclockSpeed);

                if (overclockSpeed > 2.5m)
                {
                    numberOfMachinesNeeded = (int)Math.Ceiling(overclockSpeed / 2.5m);
                    overclockSpeed = 2.5m;
                }

                return ProcessRecipe(recipe, overclockSpeed, numberOfMachinesNeeded, numberOfPowerShardsNeeded, input);
            }
            else
            {
                overclockSpeed = 1;
                numberOfPowerShardsNeeded = 0;
                numberOfMachinesNeeded = (int)Math.Ceiling(targetOutput / recipe.ItemProduced.Value);

                return ProcessRecipe(recipe, overclockSpeed, numberOfMachinesNeeded, numberOfPowerShardsNeeded, input);
            }
        }

        private static (Dictionary<Items, decimal>, Dictionary<Items, decimal>, int, int) ProcessRecipe(Recipe recipe, decimal overclockSpeed, int numberOfMachinesNeeded, int numberOfPowerShardsNeeded, Dictionary<Items, decimal> input)
        {
            foreach (KeyValuePair<Items, decimal> resource in recipe.Resources)
            {
                input.Add(resource.Key, resource.Value * overclockSpeed);
            }

            Dictionary<Items, decimal> byproducts = new Dictionary<Items, decimal>();

            foreach (KeyValuePair<Items, decimal> _byproduct in recipe.Byproducts)
            {
                byproducts.Add(_byproduct.Key, _byproduct.Value * overclockSpeed);
            }

            return (input, byproducts, numberOfMachinesNeeded, numberOfPowerShardsNeeded);
        }
    }
}
