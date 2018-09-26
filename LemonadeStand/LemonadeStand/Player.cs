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
        private int lemonadeLeftInPitcher;
        public int LemonadeLeftInPitcher
        {
            get => lemonadeLeftInPitcher;
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
        public void SellLemonade(Customer customer)
        {
            money += Recipe.Price;
            inventory.Remove(new Cup());
            for (int i = 0; i < recipe.Quantities[2]; i++)
            {
                inventory.Remove(new Ice()); //Ice is per-cup, not per-pitcher. This should be communicated to the user while setting up
            }
            lemonadeLeftInPitcher--; // Pitcher knows how many glasses it can fill, dont have to worry about ice levels in this line.
        }
        public bool HasIngredientsForNewPitcherOfLemonade() // TO be used in tandem with MakeMoreLemonade.
        {
            if(inventory.Lemons >= recipe.Quantities[0] && inventory.Sugar >= recipe.Quantities[1])
            {
                return true;
            }
            return false;

            
        }
        public void MakeMoreLemonade()
        {
            // take stuff out of inventory and fill pitcher to an int bassed on the Ice used in the recipe
            for(int i = 0; i < recipe.Quantities.Length-1; i++) // Dont put ice in the pitcher (hence the -1)
            {
                for(int j = 0; j < recipe.Quantities[i]; j++)
                {
                    inventory.Remove(recipe.Ingredients[i]);
                }
            }
            
            //lemonadeLeftInPitcher = ???
        }
    }
}
