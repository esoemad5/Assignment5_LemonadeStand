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
            // Player makes a pitcher of lemonade
            // each pitcher makes X number of cups, depending on how much ice per cup (need to come up with an equation for this)
            // Each one decides to buy or not buy lemonade, customers can buy more than 1 cup of lemonade
            //      If customer buys lemonade, Player.pitcherOfLemonade--, Player.Inventory.Cups--
            //      if Player.Inventory.Cups == 0 , end day
            //      If Player.pitcherOfLemonade == 0, Player.RefilPitcher
            //              check if have ingredients. if so, remove from inventory and fill pitcher
            //                  if not, day ends. Store how many customers wanted to buy after stock-out?
        }
    }
}
