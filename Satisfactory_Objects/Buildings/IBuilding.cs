using Satisfactory_Objects.Enums;
using Satisfactory_Objects.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satisfactory_Objects.Buildings
{
    public interface IBuilding
    {
        public (Dictionary<Items, decimal>, int, int) Build(Recipe recipe, decimal targetOutput, bool usingPowerShards)
        {
            int numberOfPowerShardsNeeded;
            decimal overclockSpeed;
            int numberOfMachinesNeeded;
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

                return ProcessRecipe(recipe, numberOfPowerShardsNeeded, overclockSpeed, numberOfMachinesNeeded, input);
            }
            else
            {
                numberOfPowerShardsNeeded = 0;
                overclockSpeed = 1m;
                numberOfMachinesNeeded = (int)Math.Ceiling(targetOutput / recipe.ItemProduced.Value);

                return ProcessRecipe(recipe, numberOfPowerShardsNeeded, overclockSpeed, numberOfMachinesNeeded, input);
            }
        }

        (Dictionary<Items, decimal>, int, int) ProcessRecipe(Recipe recipe, int numberOfPowerShardsNeeded, decimal overclockSpeed, int numberOfMachinesNeeded, Dictionary<Items, decimal> input)
        {
            foreach (KeyValuePair<Items, decimal> resource in recipe.Resources)
            {
                input.Add(resource.Key, resource.Value * overclockSpeed);
            }
            return (input, numberOfMachinesNeeded, numberOfPowerShardsNeeded);
        }
    }
}
