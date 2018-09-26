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
            Lemon lemon = new Lemon();
            Cup cup = new Cup();
            if(lemon is Lemon)
            {
                Console.WriteLine("Hello");
            }
            
            if(cup is Lemon)
            {
                Console.WriteLine("World!");
            }
        }
    }
}
