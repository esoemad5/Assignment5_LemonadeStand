using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Player
    {
        private Inventory inventory;
        private Recipe recipe;
        private double money;

        public Player()
        {
            inventory = new Inventory();
            recipe = new Recipe();
            money = 20.00;
        }
        public void AddToRecipe(string ingredient)
        {
            recipe.Add(ingredient);
        }
        public void RemoveFromRecipe(string ingredient)
        {
            recipe.Remove(ingredient);
        }
        public void Buy(string item, Store store)
        {
            foreach(Item thing in store.Stock)
            {
                if (thing.Name == item)
                {
                    money -= thing.Price;
                    if(money < 0)
                    {
                        Console.WriteLine("You dont have enough money to buy that!");
                    }
                    else
                    {
                        inventory.Add(thing);
                    }
                    
                }
            }
            

        }
    }
}
