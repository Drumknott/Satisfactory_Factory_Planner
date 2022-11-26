using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Satisfactory_Objects.Enums;


namespace Basic_UI
{
    public class MainMenu
    {
        public string MenuInterface()
        {
            while (true)
            {
                //MAIN MENU
                Console.WriteLine("\n1 > Plan a Factory");
                Console.WriteLine("2 > Use a Harddrive to unlock a recipe");
                Console.WriteLine("0 > Quit");

                string user_input = Console.ReadLine();
                string[] valid_input = { "1", "2", "0" };

                if (valid_input.Contains(user_input))
                {
                    return user_input;
                }
                else
                {
                    Console.WriteLine("Invalid Selection. Please try again");
                }
            }
        }

        public (Items, decimal) FactoryRequirements()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\nWhat would you like to build?");
                    var userInput = Console.ReadLine();

                    Console.WriteLine("\nHow many per minute?");
                    var targetRate = Convert.ToDecimal(Console.ReadLine());

                    var isTrue = Enum.TryParse(userInput, out Items item);
                    if (!isTrue)
                    {
                        Console.WriteLine("I'm sorry I don't recognise that item. Try again");
                        continue;
                    }

                    return (item, targetRate);
                }

                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }                
            }
        }
                
        public Items GetHardDriveInfo()
        {
            while (true)
            {
                Console.WriteLine("What resource do you want to unlock a recipe for?");
                var chosenResource = Console.ReadLine();
                var success = Enum.TryParse(chosenResource, out Items result);
                if (success)
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Item not recognised. Please try again");
                }
            }
        }   
        
        public bool PowerShards()
        {
            Console.WriteLine($"\nDo you want to use Power Shards? Y/N");
            var userChoice = Console.ReadLine().ToLower();
            
            if (userChoice == "y") return true;
            else return false;            
        }
    }
}
