using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        private int gameLength;
        private ValidInput[] actions;
        private ValidInput[] items;
        public Game()
        {
            gameLength = 7;
            actions = new ValidInput[]
            {
                new ValidInput("Buy"),
                new ValidInput("Add"),
                new ValidInput("Remove"),
                new ValidInput("Help"),
                new ValidInput("Quit"),
                new ValidInput("Start"),
                new ValidInput("Change")
            };
            items = new ValidInput[] {
                new ValidInput("Cups"),
                new ValidInput("Lemons"),
                new ValidInput("Sugar"),
                new ValidInput("Ice"),
                new ValidInput("Price")
            };

        }
        public void StartGame()
        {
            // Display intro/welcome message
            Console.WriteLine();
            // Default 7 day game. Asking user for game length is not part of the MVP

            Player player = new Player();
            Store store = new Store();
            Weather weather = new Weather();
            PreDayMenu menu;
            
            
            // Loop the following:
            while (true)
            {
                weather.NewDay();
                menu = new PreDayMenu(player, store, weather);

                
                
                // Start day: Day day = new Day(weather);
                //      Use player's popularity and the weather to create Customers
                //      Each one decides to buy or not buy lemonade, customers can buy more than 1 lemonade
                // End of day:
                //      Display results:  money made vs money spent that day, and total money left.
                break;
            }
            // End of day 7, quit, or bankrupt: exit. Any post-game fedback/messages/play again options are non-MVP.
        }

        private string[] GetPlayerInput() // Done. Should return a string[] of length 1 or 2 (all caps) which will be used to interact with the menu.
        {
            string input = Console.ReadLine();
            string[] splitInput = input.ToUpper().Split(' ');

            if(splitInput.Length == 0 || splitInput.Length > 2)
            {
                return null;
            }

            string[] output = new string[splitInput.Length];
            foreach(ValidInput action in actions)
            {
                if(splitInput[0].ToUpper() == action.Input.ToUpper())
                {
                    output[0] = splitInput[0].ToUpper();
                }
                else
                {
                    return null;
                }
            }

            if(splitInput.Length == 1)
            {
                return output;
            }

            foreach(ValidInput item in items)
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


    }// end of class
}
