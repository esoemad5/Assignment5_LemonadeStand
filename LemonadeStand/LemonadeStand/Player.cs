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
        private Stats stats;
        public Stats Stats
        {
            get => stats;
        }
        public Player()
        {
            inventory = new Inventory();
            recipe = new Recipe();

            money = 20.0;
            lemonadeLeftInPitcher = 0;
            stats = new Stats();
        }
        public void AddToRecipe(string ingredient)
        {
            recipe.Add(ingredient);
        }
        public void RemoveFromRecipe(string ingredient)
        {
            recipe.Remove(ingredient);
        }
        public void Buy(string itemToPurchase, Store store, int quantity)
        {
            foreach(Item thing in store.Stock)
            {
                if (thing.Name.ToUpper() == itemToPurchase)
                {
                    money -= thing.Price*quantity;
                    if(money < 0)
                    {
                        money += thing.Price*quantity;
                        throw new Exception("You dont have enough money to buy that!");
                    }
                    else
                    {
                        for(int i = 0; i < quantity; i++)
                        {
                            inventory.Add(thing);
                        }
                    }
                    
                }
            }
            

        }
        public void SellLemonade()
        {
            money += Recipe.Price;
            inventory.Remove("Cup");
            for (int i = 0; i < recipe.Quantities[2]; i++)
            {
                inventory.Remove("Ice"); //Ice is per-cup, not per-pitcher. This should be communicated to the user while setting up
            }
            lemonadeLeftInPitcher--; // Pitcher knows how many glasses it can fill, dont have to worry about ice levels in this line.
        }
        public bool HasIngredientsForNewPitcherOfLemonade() // To be used in tandem with MakeMoreLemonade.
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
            // let 4 cubes make 10 glasses and 2 cubes make 14 glasses. Thus, each cube removes 2 glasses from the pitcher
            lemonadeLeftInPitcher = 18 - (2 * recipe.Quantities[2]);
        }
    }
}
