using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Day
    {
        private Player player;
        private List<Customer> customers;
        private Weather weather;
        // weather.Temperature/Conditions

        public Day(Player player, Weather weather)
        {
            this.player = player;
            this.weather = weather;
        }
        public void StartDay()
        {
            // Use the weather to create Customers

            if (player.HasIngredientsForNewPitcherOfLemonade() && player.Inventory.Cups > 0 && player.Inventory.Ice > player.Recipe.Quantities[2]) // Make 1st pitcher of lemonade for the day
            {
                player.MakeMoreLemonade();
            }
            else
            {
                //Day ends
            }
            // Each Customer decides to buy or not buy lemonade, customers can buy more than 1 cup of lemonade
            for (int i = 0; i < customers.Count; i++)
            {
                if(true/*some condition*/)
                {
                    player.SellLemonade(customers[i]);
                    if(player.Inventory.Cups == 0 || player.Inventory.Ice < player.Recipe.Quantities[2])
                    {
                        //Day ends
                    }
                    if (player.LemonadeLeftInPitcher <= 0)
                    {
                        if (player.HasIngredientsForNewPitcherOfLemonade())
                        {
                            player.MakeMoreLemonade();
                        }
                        else
                        {
                            //Day ends
                        }
                    } 
                }
            }
            //Day ends
        }
    }
}
