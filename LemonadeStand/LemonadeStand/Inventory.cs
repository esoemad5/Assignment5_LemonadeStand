using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Inventory
    {
        private List<Item> lemons;
        public int Lemons
        {
            get { return lemons.Count; }
        }
        private List<Item> sugar;
        public int Sugar
        {
            get { return sugar.Count; }
        }
        private List<Item> ice;
        public int Ice
        {
            get { return ice.Count; }
        }
        private List<Item> cups;
        public int Cups
        {
            get { return cups.Count; }
        }
        private List<Item>[] items;
        public List<Item>[] Items
        {
            get => items;
        }
        private string[] itemNames;
        public string[] ItemNames
        {
            get => itemNames;
        }
        public Inventory()
        {
            lemons = new List<Item>();
            sugar = new List<Item>();
            ice = new List<Item>();
            cups = new List<Item>();

            items = new List<Item>[] { lemons, sugar, ice, cups };
            itemNames = new string[] { "Lemons", "Sugar", "Ice", "Cups" };
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
                    throw new Exception("Exception in Inventory.Add, tried to add an invalid item.");
            }
        }
        public void Remove(string item)
        {
            try
            {
                switch (item)
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
                        throw new Exception("Exception in Inventory.Remove, tried to remove an invalid item.");
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
            
        }

    }
}
