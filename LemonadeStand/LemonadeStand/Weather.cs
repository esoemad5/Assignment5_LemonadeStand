using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Weather
    {
        private int temperature;
        public int Temperature
        {
            get => temperature;
        }
        private string conditions;
        public string Conditions
        {
            get => conditions;
        }
        private string[] possibleConditions;
        
        public Weather()
        {
            possibleConditions = new string[] { "Sunny", "Cloudy", "Rainy" };
            Random rand = new Random();
            temperature = 60 + rand.Next(40);
            conditions = possibleConditions[rand.Next(3)];
        }
        public void ChangeTemperature()
        {
            Random rand = new Random();
            temperature += 5 - rand.Next(10);
        }
        public void ChangeConditions()
        {
            Random rand = new Random();
            int chance = rand.Next(100);
            if (chance > 20)
            {
                if (chance < 5)
                {
                    conditions = "Rainy";
                }
                else if (chance < 15)
                {
                    conditions = "Cloudy";
                }
                else
                {
                    conditions = "Sunny";
                }
            }
        }
    }
}
