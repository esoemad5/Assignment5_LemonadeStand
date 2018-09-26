﻿using System;
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
        public PreDayMenu(Player player, Store store, Weather weather) // TODO
        {
            this.player = player;
            this.store = store;
            this.weather = weather;
            GetInputLoop();
        }
        private void Display() // TODO
        {

        }
        private void GetInputLoop()
        {
            // Preperation menu:
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
                    //      Define recipie
                    //          Commands: Add/Remove (Lemons, Sugar, Ice)
                    case "ADD":
                        player.AddToRecipe(command[1]); // This is fine, even though AddToRecipie only has 1 line of code.
                        break;
                    case "REMOVE":
                        player.RemoveFromRecipe(command[1]); // ibid
                        break;
                    //      Help, continue, and end game options
                    //          Commands: Help, Quit, Start
                    case "CHANGE":
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
    }
}
