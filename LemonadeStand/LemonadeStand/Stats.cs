using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Stats
    {
        private string nameOfPlayer;
        private double moneySpentToday;
        public double MoneySpentToday { get => moneySpentToday; }
        private double moneySpentTotal;
        public double MoneySpentTotal { get => moneySpentTotal; }
        private double moneyEarnedToday;
        public double MoneyEarnedToday { get => moneyEarnedToday; }
        private double moneyEarnedTotal;
        public double MoneyEarnedTotal { get => moneyEarnedTotal; }
        
        public Stats(string nameOfPlayer)
        {
            this.nameOfPlayer = nameOfPlayer;
            moneySpentToday = 0;
            moneySpentTotal = 0;
            moneyEarnedToday = 0;
            moneyEarnedTotal = 0;
        }
        public void UpdateMoneySpent(double moneySpent)
        {
            moneySpentToday += moneySpent;
            moneySpentTotal += moneySpent;
        }
        public void UpdateMoneyEarned(double moneyEarned)
        {
            moneyEarnedToday += moneyEarned;
            moneyEarnedTotal += moneyEarned;
        }
        public void ResetMoneySpentToday()
        {
            moneySpentToday = 0;
        }
        public void ResetMoneyEarnedToday()
        {
            moneyEarnedToday = 0;
        }
        public void Display()
        {
            Console.WriteLine("{0}'s stats:", nameOfPlayer);
            Console.WriteLine();
            Console.WriteLine("Money earned today: ${0}", moneyEarnedToday);
            Console.WriteLine("Money spent today: ${0}", moneySpentToday);
            Console.WriteLine("Today's profit: ${0}", moneyEarnedToday - moneySpentToday);
            Console.WriteLine();
            Console.WriteLine("Total money earned: ${0}", moneyEarnedTotal);
            Console.WriteLine("Total money spent: ${0}", moneySpentTotal);
            Console.WriteLine("Total profit: ${0}", moneyEarnedTotal - moneySpentTotal);
        }

    }
}
