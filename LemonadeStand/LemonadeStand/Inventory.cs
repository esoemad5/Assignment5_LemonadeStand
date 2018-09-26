using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Inventory
    {
        private List<Lemon> lemons;
        public int Lemons
        {
            get { return lemons.Count; }
        }
        private List<Sugar> sugar;
        public int Sugar
        {
            get { return sugar.Count; }
        }
        private List<Ice> ice;
        public int Ice
        {
            get { return ice.Count; }
        }
        private List<Cup> cups;
        public int Cups
        {
            get { return cups.Count; }
        }


        public Inventory()
        {
            lemons = new List<Lemon>();
            sugar = new List<Sugar>();
            ice = new List<Ice>();
            cups = new List<Cup>();
        }
        public void Add(Item item)
        {
            switch (item.Name)
            {
                case "Lemon":
                    lemons.Add(new Lemon());
                    break;
                case "Sugar":
                    sugar.Add(new Sugar());
                    break;
                case "Ice":
                    ice.Add(new Ice());
                    break;
                case "Cup":
                    cups.Add(new Cup());
                    break;
                default:
                    Console.WriteLine("Error in Inventory.Add. Tried to add an invalid item.");
                    break;
            }
        }
        public void Remove(Item item)
        {
            switch (item.Name)
            {
                case "Lemon":
                    lemons.RemoveAt(0);
                    break;
                case "Sugar":
                    sugar.RemoveAt(0);
                    break;
                case "Ice":
                    ice.RemoveAt(0);
                    break;
                case "Cup":
                    cups.RemoveAt(0);
                    break;
                default:
                    Console.WriteLine("Error in Inventory.Add. Tried to remove an invalid item.");
                    break;
            }
        }

    }
}
