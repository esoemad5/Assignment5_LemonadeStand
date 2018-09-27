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
        private bool playerIsReady;

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
            Display();
            while (!playerIsReady)
            {
                
                try
                {
                    string[] command = GetPlayerInput();
                    ProcessInput(command);
                }
                catch(Exception e)
                {
                    message = (e.Message);
                }
                finally
                {
                    Display();
                    message = "";
                }
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
            Console.WriteLine("What would you like to do? Type Help for options.");
        }
        private int GetQuantity()
        {
            Console.WriteLine("How many would you like to buy?");
            return Convert.ToInt32(Console.ReadLine());
        }
        private void ProcessInput(string[] command)
        {
            switch (command[0])
            {
                case "BUY":
                    try
                    {
                        player.Buy(command[1], store, GetQuantity());
                        message = "You bought: " + command[1] + "!";
                    }
                    catch (FormatException)
                    {
                        message = "You must enter an integer!";
                    }
                    catch (OverflowException)
                    {
                        message = "You can't buy that many!";
                    }
                    catch(Exception e)
                    {
                        message = e.Message;
                    }
                    
                    break;
                case "ADD":
                    try
                    {
                        player.AddToRecipe(command[1]);
                        message = "You added a " + command[1] + " to the recipe!";
                    }
                    catch (Exception e)
                    {
                        message = e.Message;
                    }
                    break;
                case "REMOVE":
                    try
                    {
                        player.RemoveFromRecipe(command[1]);
                        message = "You removed a " + command[1] + " from the recipe!";
                    }
                    catch(Exception e)
                    {
                        message = e.Message;
                    }
                    break;
                case "CHANGEPRICE":
                    Console.WriteLine("What would you like to change the price per cup to?");
                    string newPrice = Console.ReadLine();
                    try
                    {
                        player.Recipe.ChangePrice(Math.Round(Convert.ToDouble(newPrice), 2));
                    }
                    catch (Exception)
                    {
                        message = "Price must be a positive number!";
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
                default:
                    // If the user inputs 'exit' code reaches here. Why????
                    message = "This message should never be shown. The game probably still works though.";
                    break;
            }
        }
        private string[] GetPlayerInput() 
        {
            string input = Console.ReadLine();
            string[] splitInput = input.ToUpper().Split(' ');
            string[] output = new string[splitInput.Length];
            if (splitInput.Length > 2)
            {
                throw new Exception("That command is not recognized. Enter 'Help' to see a list of commands.");
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
                throw new Exception("That command is not recognized. Enter 'Help' to see a list of commands.");
            }            
        }
    }
}
