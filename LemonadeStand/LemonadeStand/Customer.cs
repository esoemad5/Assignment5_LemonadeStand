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

        private int WeatherConditionsFactor(Weather weather)
        {
            // Sunny, Cloudy, Rainy adds 40, 30, 20
            int sunnyChanceToBuyLemonade = 40;
            int cloudyChanceToBuyLemonade = 30;
            int rainyChanceToBuyLemonade = 20;
            switch (weather.Conditions)
            {
                case "Sunny":
                    return sunnyChanceToBuyLemonade;
                case "Cloudy":
                    return cloudyChanceToBuyLemonade;
                case "Rainy":
                    return rainyChanceToBuyLemonade;
                default:
                    return 0;
            }
        }
        private int TemperatureFactor(Weather weather)
        {
            // Temperature ranges from 60-100, every 2 degrees adds 1% to the chance
            return (weather.Temperature - 60) / 2;
        }
        private int PriceFactor(Player player)
        {
            // Price: each $0.01 over $0.30 removes 1% from the chance, each $0.01 lower increaces chance, up to a 10% increase
            double price = player.Recipe.Price - 0.30;
            if (price < -0.10)
            {
                price = -0.10;
            }
            return (int)(-100 * price);
        }
        private int RandomFactor()
        {
            // Random number [-30, 60) to make chances different for each customer.  
            Random rand = new Random();
            return 30 - rand.Next(60);
        }
        public Customer(Player player, Weather weather)
        {
            // Chance is number 1-100, if game rolls lower than the chance, Customer buys lemonade.
            chanceToBuyLemonade = 0;
            chanceToBuyLemonade += WeatherConditionsFactor(weather);
            chanceToBuyLemonade += TemperatureFactor(weather);
            chanceToBuyLemonade += PriceFactor(player);
            chanceToBuyLemonade += RandomFactor();
        }
    }
}
