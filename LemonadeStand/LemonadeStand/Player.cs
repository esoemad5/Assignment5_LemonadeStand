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
        public Inventory Inventory
        {
            get => inventory;
        }
        private Recipe recipe;
        public Recipe Recipe
        {
            get => recipe;
        }
        private double money;
        public double Money
        {
            get => money;
        }

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
        public void Buy(string itemToPurchase, Store store)
        {
            foreach(Item thing in store.Stock)
            {
                if (thing.Name.ToUpper() == itemToPurchase)
                {
                    money -= thing.Price;
                    if(money < 0)
                    {
                        Console.WriteLine("You dont have enough money to buy that!");
                        money += thing.Price;
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
