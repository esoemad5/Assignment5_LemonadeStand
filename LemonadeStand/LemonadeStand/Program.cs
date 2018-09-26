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
            //game.StartGame();
            Player player = new Player();
            Console.WriteLine("{0}: {1}", player.Recipe.Ingredients[0], player.Recipe.Quantities[0]);
            player.RemoveFromRecipe("LEMONS");
            Console.WriteLine("{0}: {1}", player.Recipe.Ingredients[0], player.Recipe.Quantities[0]);
            player.RemoveFromRecipe("LEMONS");
            Console.WriteLine("{0}: {1}", player.Recipe.Ingredients[0], player.Recipe.Quantities[0]);
            player.RemoveFromRecipe("LEMONS");
            Console.WriteLine("{0}: {1}", player.Recipe.Ingredients[0], player.Recipe.Quantities[0]);
            player.RemoveFromRecipe("LEMONS");
            Console.WriteLine("{0}: {1}", player.Recipe.Ingredients[0], player.Recipe.Quantities[0]);
            player.RemoveFromRecipe("LEMONS");
            Console.WriteLine("{0}: {1}", player.Recipe.Ingredients[0], player.Recipe.Quantities[0]);

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
