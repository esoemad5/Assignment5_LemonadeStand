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
            weather.ChangeConditions();
            weather.ChangeTemperature();
        }
        public void StartDay(int numberOfCustomers)
        {
            int customerCounter = 0;
            CreateListOfCustomers(numberOfCustomers);
            customerCounter = DayEndsOrMakeMoreLemonade(customerCounter); // Make 1st pitcher of lemonade.
            Random rand = new Random();
            for (customerCounter = customerCounter; customerCounter < customers.Count; customerCounter++)
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
        }
        private int SkipToEndOfDay(int customerCounter)
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
                return SkipToEndOfDay(customerCounter);
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
                    return SkipToEndOfDay(customerCounter);
                }
            }
            return customerCounter;
        }
    }
}
