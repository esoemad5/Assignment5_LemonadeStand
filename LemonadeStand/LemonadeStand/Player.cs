using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Player
    {
        private string name;
        public string Name
        {
            get => name;
        }
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
        public bool hasQuit;

        public Player()
        {
            Console.WriteLine("Please enter your name: ");
            name = Console.ReadLine();
            inventory = new Inventory();
            recipe = new Recipe();

            money = 5.00;
            lemonadeLeftInPitcher = 0;
            stats = new Stats(name);

            hasQuit = false;
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
                    double cost = thing.Price * quantity;
                    money -= cost;
                    if(money < 0)
                    {
                        money += cost;
                        throw new Exception("You dont have enough money to buy that!");
                    }
                    else
                    {
                        for(int i = 0; i < quantity; i++)
                        {
                            inventory.Add(thing);
                        }
                        stats.UpdateMoneySpent(cost);
                    }
                    
                }
            }
        }
        public void SellLemonade()
        {
            money += Recipe.Price;
            stats.UpdateMoneyEarned(Recipe.Price);
            inventory.Remove("Cup");
            for (int i = 0; i < recipe.Quantities[2]; i++)
            {
                inventory.Remove("Ice"); //Ice is per-cup, not per-pitcher.
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
            for(int i = 0; i < recipe.Quantities.Length - 1; i++) // Dont use ice when making anew pitcher (hence the -1)
            {
                for(int j = 0; j < recipe.Quantities[i]; j++)
                {
                    inventory.Remove(recipe.Ingredients[i]);
                }
            }
            // Pitcher has 10 glasses + 2 for each ice cube used.
            lemonadeLeftInPitcher = 10 + (2 * recipe.Quantities[2]);
        }
    }
}
