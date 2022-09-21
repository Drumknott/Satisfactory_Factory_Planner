using Satisfactory_Objects.Buildings;
using Satisfactory_Objects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Satisfactory_Objects.Recipes
{
    public class Recipe
    {
        public KeyValuePair<Items, decimal> ItemProduced { get;}
        public Dictionary<Items, decimal> Resources { get;}
        public Dictionary<Items, decimal> Byproducts { get;}
        public KeyValuePair<bool, bool> AlternateRecipe { get; set; } // <Is alt recipe, alt recipe unlocked>
        public Machines Machine { get; }
    }
}
