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
            int customerCounter = 0;
            CreateListOfCustomers(numberOfCustomers);
            DayEndsOrMakeMoreLemonade(customerCounter); // Make 1st pitcher of lemonade. Make sure user cant start day if there are not enough ingredients?
            Random rand = new Random();
#pragma warning disable CS1717 // Assignment made to same variable
            for (customerCounter = customerCounter; customerCounter < customers.Count; customerCounter++)
#pragma warning restore CS1717 // Assignment made to same variable
            {
                int customerBuysLemonade = customers[customerCounter].ChanceToBuyLemonade - rand.Next(100);
                if(customerBuysLemonade > 60)
                {
                    player.SellLemonade();
                    customerCounter = DayEndsOrMakeMoreLemonade(customerCounter);
                    player.SellLemonade();
                    DayEndsOrMakeMoreLemonade(customerCounter);
                }
                if (customerBuysLemonade > 0)
                {
                    player.SellLemonade();
                    DayEndsOrMakeMoreLemonade(customerCounter);  
                }
            }
            EndDay(customerCounter);  
        }
        private int EndDay(int customerCounter)
        {
            return customers.Count;
        }
        private void CreateListOfCustomers(int numberOfCustomers)
        {
            customers = new List<Customer>();
            while(customers.Count < numberOfCustomers)
            {
                customers.Add(new Customer(player, weather));
            }
        }
        private int DayEndsOrMakeMoreLemonade(int customerCounter)
        {
            if (player.Inventory.Cups == 0 || player.Inventory.Ice < player.Recipe.Quantities[2])
            {
                return EndDay(customerCounter);
            }
            if (player.LemonadeLeftInPitcher <= 0)
            {
                if (player.HasIngredientsForNewPitcherOfLemonade())
                {
                    player.MakeMoreLemonade();
                    return customerCounter;
                }
                else
                {
                    return EndDay(customerCounter);
                }
            }
            return customerCounter;
        }
    }
}
