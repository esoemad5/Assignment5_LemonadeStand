using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Recipe
    {
        private string[] ingredients;
        private int[] quantities;
        
        public Recipe()
        {            
            ingredients = new string[3];
            ingredients[0] = "LEMONS";
            ingredients[1] = "SUGAR";
            ingredients[2] = "ICE";

            quantities = new int[3];
            for (int i = 0; i < quantities.Length; i++)
            {
                quantities[i] = 4;
            }

        }
        public void Add(string ingredient)
        {
            for(int i = 0; i < ingredients.Length; i++)
            {
                if(ingredients[i] == ingredient)
                {
                    quantities[i]++;
                    return;
                }
            }
        }
        public void Remove(string ingredient)
        {
            for (int i = 0; i < ingredients.Length; i++)
            {
                if (ingredients[i] == ingredient)
                {
                    if(quantities[i] != 0)
                    {
                        quantities[i]--;
                        return;
                    }
                }
            }
        }
    }
}
