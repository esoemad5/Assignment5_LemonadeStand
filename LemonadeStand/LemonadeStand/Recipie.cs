using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Recipie
    {
        private string[] ingredients;
        private int[] quantity;
        
        public Recipie()
        {
            ingredients = new string[3] { "Lemons", "Sugar", "Ice" };
            quantity = new int[3] { 4, 4, 4 };

        }
    }
}
