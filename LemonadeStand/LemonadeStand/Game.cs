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
        public Game()
        {
            gameLength = 7;

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
            
            while (true)
            {
                weather.NewDay();
                menu = new PreDayMenu(player, store, weather);
                menu.MainLoop();
                if (menu.PlayerWantsToQuit)
                {
                    break;
                }
                // Start day: Day day = new Day(weather);
                //      Use player's popularity and the weather to create Customers
                //      Each one decides to buy or not buy lemonade, customers can buy more than 1 lemonade
                // End of day:
                //      Display results:  money made vs money spent that day, and total money left.
                break;
            }
            // End of day 7, quit, or bankrupt: exit. Any post-game fedback/messages/play again options are non-MVP.
        }

        
    }// end of class
}
