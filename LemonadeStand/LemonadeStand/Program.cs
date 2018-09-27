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
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(a);
            */
            // throws a FormatException
        }
    }

}
