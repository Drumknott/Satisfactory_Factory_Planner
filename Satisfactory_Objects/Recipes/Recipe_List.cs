using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Satisfactory_Objects.Enums;

namespace Satisfactory_Objects.Recipes
{
    public class Recipe_List
    {
        public List<Recipe> fullRecipeList { get; set; }

        public Recipe_List()
        {
            var dataFile = File.ReadAllText("C:\\Users\\drumk\\source\\repos\\Satisfactory_Factory_Planner\\Satisfactory_Objects\\Recipes\\satisfactory_recipes.json");

            fullRecipeList = JsonSerializer.Deserialize<List<Recipe>>(dataFile);
        }
    }
}
