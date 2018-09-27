using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Stats
    {
        // Money spent: each day and total
        private double moneySpentToday;
        public double MoneySpentToday { get => moneySpentToday; }
        private double moneySpentTotal;
        public double MoneySpentTotal { get => moneySpentTotal; }
        private double moneyEarnedToday;
        public double MoneyEarnedToday { get => moneyEarnedToday; }
        private double moneyEarnedTotal;
        public double MoneyEarnedTotal { get => moneyEarnedTotal; }
        
        public Stats()
        {
            moneySpentToday = 0;
            moneySpentTotal = 0;
            moneyEarnedToday = 0;
            moneyEarnedTotal = 0;
        }
        // update each time a player buys something and at end of each day
        public void UpdateMoneySpent(double moneySpent)
        {

        }
        public void UpdateMoneyEarned(double moneyEarned)
        {

        }
        // Display
        public void Display()
        {

        }

    }
}
