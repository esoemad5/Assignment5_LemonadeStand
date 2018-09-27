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
        public void StartDay(int numberOfCustomers)
        {
            CreateListOfCustomers(numberOfCustomers);
            DayEndsOrMakeMoreLemonade(); // Make 1st pitcher of lemonade. Make sure user cant start day if there are not enough ingredients?
            Random rand = new Random();
            for (int counter = 0; counter < customers.Count; counter++)
            {
                int customerBuysLemonade = customers[counter].ChanceToBuyLemonade - rand.Next(100);
                if(customerBuysLemonade > 60)
                {
                    player.SellLemonade();
                    //counter = DayEndsOrMakeMoreLemonade();
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
            //classWideCounter = customers.Count;
        }
        private void CreateListOfCustomers(int numberOfCustomers)
        {
            customers = new List<Customer>();
            while(customers.Count < numberOfCustomers)
            {
                customers.Add(new Customer(player, weather));
            }
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
