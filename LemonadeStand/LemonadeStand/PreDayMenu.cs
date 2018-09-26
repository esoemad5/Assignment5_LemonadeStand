using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class PreDayMenu
    {
        private Player player;
        private Store store;
        private Weather weather;

        private ValidInput[] actionsThatDontRequireAnItem;
        private ValidInput[] actionsThatRequireAnItem;
        private ValidInput[] items;

        private bool playerWantsToQuit;
        public bool PlayerWantsToQuit
        {
            get => playerWantsToQuit;
        }
        bool playerIsReady;

        private string message;


        public PreDayMenu(Player player, Store store, Weather weather)
        {
            this.player = player;
            this.store = store;
            this.weather = weather;

            actionsThatDontRequireAnItem = new ValidInput[]
            {
                
                new ValidInput("Help"),
                new ValidInput("Quit"),
                new ValidInput("Start"),
                new ValidInput("ChangePrice")
            };
            actionsThatRequireAnItem = new ValidInput[]
            {
                new ValidInput("Buy"),
                new ValidInput("Add"),
                new ValidInput("Remove"),
            };
            items = new ValidInput[] {
                new ValidInput("Cup"),
                new ValidInput("Lemon"),
                new ValidInput("Sugar"),
                new ValidInput("Ice"),
                new ValidInput("Price")
            };

            message = "Good Luck!";
            bool playerIsReady = false;
        }
        public void MainLoop()
        {
            while (!playerIsReady)
            {
                Display();
                string[] command = GetPlayerInput();
                ProcessInput(command);
            }
        }
        private void Display()
        {
            Console.Clear(); // Comment this line out when debugging

            Console.WriteLine("Recipe:");
            for (int i = 0; i < player.Recipe.Ingredients.Length; i++)
            {
                Console.WriteLine("{0}: {1}", player.Recipe.Ingredients[i], player.Recipe.Quantities[i]);
            }
            Console.WriteLine("Price: ${0} per cup", player.Recipe.Price); //price
            Console.WriteLine();
            Console.WriteLine("Inventory:");
            for (int i = 0; i < player.Inventory.Items.Length; i++)
            {
                Console.WriteLine("{0}: {1}", player.Inventory.ItemNames[i], player.Inventory.Items[i].Count);
            }

            Console.WriteLine();
            Console.WriteLine("Store:");
            for(int i = 0; i < store.Stock.Length; i++)
            {
                Console.WriteLine("{1} per {0}", store.Stock[i].Name, store.Stock[i].Price);
            }

            Console.WriteLine();
            Console.WriteLine("You have: ${0}", player.Money);
            Console.WriteLine();
            Console.WriteLine("Weather forecast: {0}F and {1}.", weather.Temperature, weather.Conditions);

            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine();
            Console.WriteLine("What would you like to do? (type Help for options)");
        }
        private void ProcessInput(string[] command)
        {
            switch (command[0])
            {
                case "BUY":
                    player.Buy(command[1], store);
                    message = "You bought: " + command[1] + "!";
                    break;
                case "ADD":
                    player.AddToRecipe(command[1]);
                    message = "You added a " + command[1] + " to the recipe!"; 
                    break;
                case "REMOVE":
                    player.RemoveFromRecipe(command[1]);
                    message = "You removed a " + command[1] + " from the recipe!";
                    break;
                case "CHANGEPRICE":
                    Console.WriteLine("What would you like to change the price per cup to?");
                    string newPrice = Console.ReadLine();
                    try
                    {
                        player.Recipe.ChangePrice(Math.Round(Convert.ToDouble(newPrice), 2));
                    }
                    catch (FormatException)
                    {
                        message = "Price must be a number!";
                    }
                    
                    
                    break;
                case "START":
                    playerIsReady = !playerIsReady;
                    break;
                case "QUIT":
                    playerWantsToQuit = !PlayerWantsToQuit;
                    playerIsReady = !playerIsReady;
                    return;
                case "HELP":
                    // Console.write ValidInput descriptions. Kinda post-MVP, but the player does need to learn the commands at some point
                    break;
                case "BAD":
                    message = "That command is not recognized. Enter 'Help' to see a list of commands.";
                    break;
                default:
                    break;
            }
        }
        private string[] GetPlayerInput() 
        {
            string input = Console.ReadLine();
            string[] splitInput = input.ToUpper().Split(' ');
            string[] output = new string[splitInput.Length];
            output[0] = "BAD";
            if (splitInput.Length > 2)
            {
                return output;
            }

            if (splitInput.Length == 1)
            {
                foreach (ValidInput action in actionsThatDontRequireAnItem)
                {
                    if (splitInput[0] == action.Input.ToUpper())
                    {
                        output[0] = splitInput[0];
                        return output;
                    }
                }
                return output;
            }
            else
            {
                foreach (ValidInput action in actionsThatRequireAnItem)
                {
                    if (splitInput[0] == action.Input.ToUpper())
                    {
                        output[0] = splitInput[0];
                    }
                }

                foreach (ValidInput item in items)
                {
                    if (splitInput[1].ToUpper() == item.Input.ToUpper())
                    {
                        output[1] = splitInput[1].ToUpper();
                        return output;
                    }
                }
                output[0] = "BAD";
                return output;
            }            
        }
    }
}
