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

        private Store store;
        private List<Player> players;
        private Weather weather;

        StartMenu startMenu;
        PreDayMenu menu;
        public Game()
        {
            gameLength = 7;
            currentDay = 0;
            customersPerDay = 20;
            store = new Store();
            players = new List<Player>();
            startMenu = new StartMenu();
        }
        public void StartGame()
        {
            int numberOfPlayers = startMenu.Display();
            MakePlayers(numberOfPlayers);
            while (currentDay <= gameLength)
            {
                currentDay++;
                weather = new Weather();
                foreach(Player player in players)
                {
                    if (player.hasQuit)
                    {
                        continue;
                    }
                    menu = new PreDayMenu(player, store, weather);
                    menu.MainLoop();
                }
                if (AllPlayersHaveQuit())
                {
                    break;
                }
                weather.ForecastToActual();
                foreach (Player player in players)
                {
                    if (player.hasQuit)
                    {
                        continue;
                    }
                    Day day = new Day(player, weather);
                    day.StartDay(customersPerDay);
                }
                
                foreach(Player player in players)
                {
                    DisplayEndOfDayScreen(player);
                }  
            }
            foreach(Player player in players)
            {
                DisplayEndOfGameScreen(player);
            }
            
        }
        private void DisplayEndOfGameScreen(Player player)
        {
            Console.Clear();
            player.Stats.Display();
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.WriteLine();
            Console.WriteLine("Summer is over, nobody will buy lemonade until next year. Thank you for playing!!!");
            Console.ReadKey();
        }
        private void DisplayEndOfDayScreen(Player player)
        {
            Console.Clear();
            Console.WriteLine("End of Day {0}", currentDay);
            Console.WriteLine();
            Console.WriteLine("The weather today was: {0}F and {1}", weather.Temperature, weather.Conditions);
            Console.WriteLine();
            player.Stats.Display();
            player.Stats.ResetMoneyEarnedToday();
            player.Stats.ResetMoneySpentToday();
            Console.WriteLine();
            Console.WriteLine("Press c to continue.");
            char cont = 'a';
            while (cont != 'c')
            {
                cont = Console.ReadKey().KeyChar;
            }
        }
        private void MakePlayers(int numberOfPlayers)
        {
            for(int i = 0; i < numberOfPlayers; i++)
            {
                players.Add(new Player());
            }
        }
        private bool AllPlayersHaveQuit()
        {
            foreach(Player player in players)
            {
                if(player.hasQuit == false)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
