using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class StartMenu
    {
        private string welcomeMessage;

        public int Display()
        {
            welcomeMessage = "Welcome to Lemonade Stand! You can play alone or with your friends, but lets be honest, you don't have any of those do you?";
            Console.WriteLine(welcomeMessage);
            Console.WriteLine();
            return GetNumberOfPlayers();
            
        }
        private int GetNumberOfPlayers()
        {
            Console.WriteLine("How many players will be playing today?");
            try
            {
                int numberOfPlayers = Convert.ToInt32(Console.ReadLine());
                if (numberOfPlayers < 1)
                {
                    throw new FormatException();
                }
                return numberOfPlayers;
            }
            catch (FormatException)
            {
                Console.WriteLine("You must enter a positive integer!");
                return GetNumberOfPlayers();
            }
        }
    }
}
