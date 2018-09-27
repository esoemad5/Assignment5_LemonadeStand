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
        public string[] Ingredients
        {
            get => ingredients;
        }
        private int[] quantities;
        public int[] Quantities
        {
            get => quantities;
        }
        private double price;
        public double Price
        {
            get => price;
        }
        
        public Recipe()
        {            
            ingredients = new string[3];
            ingredients[0] = "Lemon";
            ingredients[1] = "Sugar";
            ingredients[2] = "Ice";

            quantities = new int[3];
            for (int i = 0; i < quantities.Length; i++)
            {
                quantities[i] = 4;
            }

            price = 0.25; // Default price of lemonade

        }
        public void Add(string ingredient)
        {
            for(int i = 0; i < ingredients.Length; i++)
            {
                if(ingredients[i].ToLower() == ingredient.ToLower())
                {
                    quantities[i]++;
                    return;
                }
            }
            throw new Exception("Can only remove Lemon, Sugar and Ice from the recipe!");
        }
        public void Remove(string ingredient)
        {
            for (int i = 0; i < ingredients.Length; i++)
            {
                if (ingredients[i].ToLower() == ingredient.ToLower())
                {
                    if(quantities[i] != 0)
                    {
                        quantities[i]--;
                        return;
                    }
                }
            }
            throw new Exception("Can only remove Lemon, Sugar and Ice from the recipe!");
        }
        public void ChangePrice(double newPrice)
        {
            if(newPrice <= 0)
            {
                throw new Exception();
            }
            price = newPrice;
        }
    }
}
