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

        public Day(Player player, Weather weather)
        {
            this.player = player;
            this.weather = weather;
        }
        public void StartDay()
        {
            customers = CreateListOfCustomers();
            DayEndsOrMakeMoreLemonade(); // Make 1st pitcher of lemonade. Make sure user cant start day if there are not enough ingredients?
            Random rand = new Random();
            for (int i = 0; i < customers.Count; i++)
            {
                int customerBuysLemonade = customers[i].ChanceToBuyLemonade - rand.Next(100);
                if(customerBuysLemonade > 60)
                {
                    player.SellLemonade();
                    DayEndsOrMakeMoreLemonade();
                    player.SellLemonade();
                    DayEndsOrMakeMoreLemonade();
                }
                if (customerBuysLemonade > 0)
                {
                    player.SellLemonade();
                    DayEndsOrMakeMoreLemonade();  
                }
            }
            EndDay();  
        }
        private void EndDay()
        {
            // Generate everything needed for end of day display.
        }
        private List<Customer> CreateListOfCustomers()
        {
            List<Customer> listOfCustomers = new List<Customer>();
            while(listOfCustomers.Count < 100)
            {
                listOfCustomers.Add(new Customer(player, weather));
            }
            return listOfCustomers;
        }
        private void DayEndsOrMakeMoreLemonade()
        {
            if (player.Inventory.Cups == 0 || player.Inventory.Ice < player.Recipe.Quantities[2])
            {
                EndDay();
            }
            if (player.LemonadeLeftInPitcher <= 0)
            {
                if (player.HasIngredientsForNewPitcherOfLemonade())
                {
                    player.MakeMoreLemonade();
                }
                else
                {
                    EndDay();
                }
            }
        }
    }
}
