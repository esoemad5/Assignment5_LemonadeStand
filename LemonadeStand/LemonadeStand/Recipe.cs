using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Recipe
    {
        private Item[] ingredients;
        
        public Recipe()
        {
            ingredients = new Item[3];
            ingredients[0] = new Item("Lemons");
            ingredients[1] = new Item("Sugar");
            ingredients[2] = new Item("Ice");
            foreach(Item item in ingredients)
            {
                item.Quantity = 4;
            }

        }
        public void Add(string ingredient)
        {
            for(int i = 0; i < ingredients.Length; i++)
            {
                if(ingredients[i] == ingredient)
                {
                    quantity[i]++;
                }
            }
        }
        public void Remove(string ingredient)
        {
            for (int i = 0; i < ingredients.Length; i++)
            {
                if (ingredients[i] == ingredient)
                {
                    quantity[i]--;
                }
            }
        }
    }
}
