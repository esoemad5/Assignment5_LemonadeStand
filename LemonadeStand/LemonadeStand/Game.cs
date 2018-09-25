using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        public void StartGame()
        {
            // Display intro/welcome message
            // Default 7 day game. Asking user for game length is not part of the MVP
            //
            // Loop the following:
            //
            // Preperation menu:
            //      Purchase supplies player.inventory.purchase(Object thing);
            //      Display player's inventory and money
            //      Define recipie
            //      Display weather (forecast and actual may be different)
            //      Help, continue, and end game options
            //      Use commands like pesants quest? (throw baby)
            // Start day: Day day = new Day(player.popularity, weather);
            //      Use player's popularity and the weather to create Customers
            //      Each one decides to buy or not buy lemonade, customers can buy more than 1 lemonade
            //      Those who do buy give feedback
            // End of day:
            //      Display results:  money made vs money spent that day, and total money left.
            //      Non-MVP: # of lemonades sold, customer satisfaction rate, customer feedback table
            // End of loop
            //
            // End of day 7, quit, or bankrupt: quit. Any post-game fedback/messages/play again options are non-MVP.
            // Ideas for end of game stuff (non-MVP): How much money is left, how much lemonade sold, customer satisfaction, etc...
        }
    }
}
