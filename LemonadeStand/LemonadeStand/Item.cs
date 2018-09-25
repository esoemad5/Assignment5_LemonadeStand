using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Item
    {
        private string name;
        public string Name
        {
            get => name;
        }
        private int quantity;
        public int Quantity
        {
            get => quantity;
            set => quantity = value;
        }
        public Item(string name)
        {
            this.name = name;
            quantity = 0;
        }
    }
}
