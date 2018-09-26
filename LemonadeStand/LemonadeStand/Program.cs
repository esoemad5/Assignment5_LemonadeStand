using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.StartGame();

            /*
            Cup cup = new Cup();
            if(cup is Lemon)
            {
                Console.WriteLine("Hello");
            }
            if(cup is Cup)
            {
                Console.WriteLine("World!");
            }
            */
        }
    }
}
