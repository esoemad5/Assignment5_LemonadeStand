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
        public Customer(Weather weather)
        {
            //Chance to buy lemonade, or multiple lemonade.
            // Chance is number 1-100, if game rolls lowwer than the chance, Customer buys lemonade.
            // If roll 60 under, buy 2 lemonade
            // Sunny, Cloudy, Rainy adds 20, 30, 40
            // Temperature ranges from 60-100, every 2 degrees adds 1% to the chance
            // Price: each $0.01 over $0.30 removes 1% from the chance
            // Lemonade recipe doesn't have to affect customers. In the future, use customer satisfaction to influence player's popularity, which would influence how many customers would visit the stand.
            //Thats it???
        }


    }
}
