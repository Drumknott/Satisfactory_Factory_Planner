using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Satisfactory_Objects.Recipes;
using Satisfactory_Objects.Enums;
using System.Text.Json;
using Satisfactory_Objects.Buildings;

namespace Satisfactory_Objects
{
    public class Test_JSON
    {
        public void TestJSON()
        {
            var recipe = new TestRecipe()
            {
                ItemProduced = new KeyValuePair<Items, decimal>(Items.AILimiter, 6m),
                Resources = new Dictionary<Items, decimal>
                {
                    [Items.plastic] = 33m,
                    [Items.quickwire] = 7m
                },
                Byproducts = new Dictionary<Items, decimal>(),
                AlternateRecipe = new KeyValuePair<bool, bool>(false, false), //1st bool Recipe is Alt T/F, 2nd bool Alt recipe has been unlocked T/F
                Machine = Machines.Assembler
            };

            var jsonOutput = JsonSerializer.Serialize(recipe);
            Console.WriteLine(jsonOutput);
            
        }

        public class TestRecipe
        {            
            public KeyValuePair<Items, decimal> ItemProduced { get; set; }
            public Dictionary<Items, decimal> Resources { get; set; }
            public Dictionary<Items, decimal> Byproducts { get; set; }
            public KeyValuePair<bool, bool> AlternateRecipe { get; set; }       
            public Machines Machine{ get; set; }
        }        
    }
}
