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
    }
}
