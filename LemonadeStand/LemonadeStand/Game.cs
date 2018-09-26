﻿using System;
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
            Console.WriteLine("Welcome Message");
            // Default 7 day game. Asking user for game length is not part of the MVP

            Player player = new Player();
            Store store = new Store();
            Weather weather;
            PreDayMenu menu;
            
            while (true)
            {
                weather = new Weather();
                menu = new PreDayMenu(player, store, weather);
                menu.MainLoop();
                if (menu.PlayerWantsToQuit)
                {
                    break;
                }
                // Start day: Day day = new Day(player, weather);
                // End of day:
                //      Display results:  money made vs money spent that day, and total money left.
                break;
            }
            // End of day 7, quit, or bankrupt: exit. Any post-game fedback/messages/play again options are non-MVP.
        }

        
    }// end of class
}
