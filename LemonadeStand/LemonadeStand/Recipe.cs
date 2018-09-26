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
            ingredients[0] = new Lemon();
            ingredients[1] = new Sugar();
            ingredients[2] = new Ice();
            foreach(Item item in ingredients)
            {
                item.Quantity = 4;
            }

        }
        public void Add(string ingredient)
        {
            for(int i = 0; i < ingredients.Length; i++)
            {
                if(ingredients[i].Name == ingredient)
                {
                    ingredients[i].Quantity++;
                }
            }
        }
        public void Remove(string ingredient)
        {
            for (int i = 0; i < ingredients.Length; i++)
            {
                if (ingredients[i].Name == ingredient)
                {
                    ingredients[i].Quantity--;
                }
            }
        }
    }
}
