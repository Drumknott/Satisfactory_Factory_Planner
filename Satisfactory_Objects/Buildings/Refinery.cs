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
        public (Dictionary<Items, decimal>, Dictionary<Items, decimal>, int, int) Process(Recipe recipe, decimal targetOutput)
        {
            decimal overclockSpeed = targetOutput / recipe.ItemProduced.Value;
            int numberOfMachinesNeeded = 1;
            int numberOfPowerShardsNeeded = (int)Math.Ceiling(overclockSpeed);

            if (overclockSpeed > 2.5m)
            {
                numberOfMachinesNeeded = (int)Math.Ceiling(overclockSpeed / 2.5m);
                overclockSpeed = 2.5m;
            }

            Dictionary<Items, decimal> input = new Dictionary<Items, decimal>();

            foreach (KeyValuePair<Items, decimal> resource in recipe.Resources)
            {
                input.Add(resource.Key, resource.Value*overclockSpeed);
            }

            Dictionary<Items, decimal> byproducts = new Dictionary<Items, decimal>();

            foreach(KeyValuePair<Items, decimal> _byproduct in recipe.Byproducts)
            {
                byproducts.Add(_byproduct.Key, _byproduct.Value*overclockSpeed);
            }

            return (input, byproducts, numberOfMachinesNeeded, numberOfPowerShardsNeeded);
        }
    }
}
