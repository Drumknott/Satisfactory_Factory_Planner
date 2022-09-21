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
        public (Dictionary<Items, decimal>, int, int) Build(Recipe recipe, decimal targetOutput)
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
                input.Add(resource.Key, resource.Value * overclockSpeed);
            }
            return (input, numberOfMachinesNeeded, numberOfPowerShardsNeeded);
        }
    }
}
