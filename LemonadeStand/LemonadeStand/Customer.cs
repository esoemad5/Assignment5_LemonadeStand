using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        private int chanceToBuyLemonade;
        public int ChanceToBuyLemonade
        {
            get => chanceToBuyLemonade;
        }
        public Customer(Player player, Weather weather)
        {
            chanceToBuyLemonade = 0;
            // Chance is number 1-100, if game rolls lower than the chance, Customer buys lemonade.
            // Sunny, Cloudy, Rainy adds 20, 30, 40
            switch (weather.Conditions)
            {
                case "Sunny":
                    chanceToBuyLemonade += 40;
                    break;
                case "Cloudy":
                    chanceToBuyLemonade += 30;
                    break;
                case "Rainy":
                    chanceToBuyLemonade += 20;
                    break;
            }
            // Temperature ranges from 60-100, every 2 degrees adds 1% to the chance
            chanceToBuyLemonade += (weather.Temperature-60) / 2;
            // Price: each $0.01 over $0.30 removes 1% from the chance, each $0.01 lower increaces chance, up to a 10% increase
            double price = player.Recipe.Price - 0.30;
            if(price < -0.10)
            {
                price = -0.10;
            }
            chanceToBuyLemonade += (int)(-100 * price);
            // Random number 30 - rand(60) to make chances different for each customer.  
            Random rand = new Random();
            chanceToBuyLemonade += 30 - rand.Next(60);
        }
        // Lemonade recipe doesn't have to affect customers. In the future, use customer satisfaction to influence player's popularity, which would influence how many customers would visit the stand.
        // Customers could make feedback(new object)?



    }
}
