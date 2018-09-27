using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        private int gameLength;
        private int currentDay;
        private int customersPerDay;
        public Game()
        {
            gameLength = 7;
            currentDay = 1;
            customersPerDay = 20;

        }
        public void StartGame()
        {
            Player player = new Player();
            Store store = new Store();
            Weather weather;
            PreDayMenu menu;
            
            while (currentDay <= gameLength)
            {
                weather = new Weather();
                menu = new PreDayMenu(player, store, weather);
                menu.MainLoop();
                if (menu.PlayerWantsToQuit)
                {
                    break;
                }

                Day day = new Day(player, weather);
                day.StartDay(customersPerDay);

                player.Stats.Display(currentDay);

                player.Stats.ResetMoneyEarnedToday();
                player.Stats.ResetMoneySpentToday();
                Console.WriteLine();
                Console.WriteLine("Press c to continue.");
                char cont = 'a';
                while(cont != 'c')
                {
                    cont = Console.ReadKey().KeyChar;
                }
                currentDay++;
            }
            Console.WriteLine();
            Console.WriteLine("Summer is over, nobody will buy lemonade until next year. Thank you for playing!!!");
        }
    }
}
