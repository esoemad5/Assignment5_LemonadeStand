using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class PreDayMenu // The menu will get info from Player, Store, and Weather
    {
        private Player player;
        private Store store;
        private Weather weather;

        private ValidInput[] actionsThatDontRequireAnItem;
        private ValidInput[] actionsThatRequireAnItem;
        private ValidInput[] items;


        public PreDayMenu(Player player, Store store, Weather weather) // TODO
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
                new ValidInput("Cups"),
                new ValidInput("Lemons"),
                new ValidInput("Sugar"),
                new ValidInput("Ice"),
                new ValidInput("Price")
            };

            GetInputLoop();
        }
        private void Display() // TODO
        {

        }
        private void GetInputLoop()
        {
            bool playerIsReady = false;
            while (!playerIsReady)
            {
                PreDayMenu menu = new PreDayMenu(player, store, weather);
                //      Display player's inventory, recipie, money, weather, and store prices
                menu.Display();
                string[] command = GetPlayerInput();
                switch (command[0])
                {
                    //      Purchase supplies player.inventory.purchase(Object thing);
                    //          Commands: Buy (Cups, Lemons, Sugar, Ice)
                    case "BUY":
                        // player.Buy(command[1]);
                        break;
                    case "ADD":
                        player.AddToRecipe(command[1]);
                        break;
                    case "REMOVE":
                        player.RemoveFromRecipe(command[1]);
                        break;
                    //      Help, continue, and end game options
                    //          Commands: Help, Quit, Start
                    case "CHANGEPRICE":
                        // Change the price/cup of lemonade
                        break;
                    case "START":
                        playerIsReady = !playerIsReady;
                        break;
                    case "QUIT":
                        // Break out of loop and go to end of game
                        break;
                    case "HELP":
                        // Console.write ValidInput descriptions (kinda post-MVP, but the player does need to learn the commands at some point
                        break;
                    case null:
                    // Display help message. Do a fall-through??
                    default:
                        break;
                }
            }
        }


        private string[] GetPlayerInput() 
        {
            string input = Console.ReadLine();
            string[] splitInput = input.ToUpper().Split(' ');
            string[] output = new string[splitInput.Length];

            if (splitInput.Length == 0 || splitInput.Length > 2)
            {
                return null;
            }

            if (splitInput.Length == 1)
            {
                foreach (ValidInput action in actionsThatDontRequireAnItem)
                {
                    if (splitInput[0] == action.Input.ToUpper())
                    {
                        output[0] = splitInput[0];
                    }
                    else
                    {
                        return null;
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
                    else
                    {
                        return null;
                    }
                }

                foreach (ValidInput item in items)
                {
                    if (splitInput[1].ToUpper() == item.Input.ToUpper())
                    {
                        output[1] = splitInput[1].ToUpper();
                    }
                    else
                    {
                        return null;
                    }
                }
                return output;
            }            
        }
        // Done. Should return a string[] of length 1 or 2 (all caps) which will be used to interact with the menu.
    }
}
