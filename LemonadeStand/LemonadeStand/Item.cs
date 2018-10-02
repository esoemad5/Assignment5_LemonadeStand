using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public abstract class Item
    {
        protected string name;
        public string Name
        {
            get => name;
        }
        protected double price;
        public double Price
        {
            get => price;
            set => price = value;
        }
    }
}
