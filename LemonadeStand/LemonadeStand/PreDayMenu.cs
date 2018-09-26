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

            bool playerIsReady = false;
        }
        public void MainLoop()
        {
            while (!playerIsReady)
            {
                Display();
                string[] command = GetPlayerInput(); // Command will be null, or an array of strings (all caps) of length 1 or 2
                LogStringArray(command); //delete this
                //ProcessInput(command);
            }
        }
        private void Display() // TODO
        {
            Console.Clear();

            Console.WriteLine("Recipie:");
            for (int i = 0; i < player.Recipe.Ingredients.Length; i++)
            {
                Console.WriteLine("{0}: {1}", player.Recipe.Ingredients[i], player.Recipe.Quantities[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Inventory:");
            for (int i = 0; ; i++)
            {

            }

            Console.WriteLine();
            Console.WriteLine("Store:");


            Console.WriteLine("Please enter input");
            return;
        }
        private void ProcessInput(string[] command)
        {
            switch (command[0])
            {
                case "BUY":
                    player.Buy(command[1], store);
                    break;
                case "ADD":
                    player.AddToRecipe(command[1]);
                    break;
                case "REMOVE":
                    player.RemoveFromRecipe(command[1]);
                    break;
                case "CHANGEPRICE":
                    // Change the price/cup of lemonade
                    break;
                case "START":
                    playerIsReady = !playerIsReady;
                    break;
                case "QUIT":
                    playerWantsToQuit = true;
                    return;
                case "HELP":
                    // Console.write ValidInput descriptions. Kinda post-MVP, but the player does need to learn the commands at some point
                    break;
                default:
                    break;
            }
        }
        private void LogStringArray(string[] words) // test function. delete this
        {
            foreach(string word in words)
            {
                Console.WriteLine(word);
            }
        }
        private string[] GetPlayerInput() 
        {
            string input = Console.ReadLine();
            string[] splitInput = input.ToUpper().Split(' ');
            string[] output = new string[splitInput.Length];
            output[0] = "HELP";
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
                output[0] = "HELP";
                return output;
            }            
        }
    }
}
