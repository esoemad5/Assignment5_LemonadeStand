using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Store
    {
        private Item[] stock;
        public Item[] Stock
        {
            get => stock;
        }
        public Store()
        {

            stock = new Item[4];
            stock[0] = new Lemon();
            stock[1] = new Sugar();
            stock[2] = new Ice(); ;
            stock[3] = new Cup();

            stock[0].Price = 0.07;
            stock[0].Price = 0.06;
            stock[0].Price = 0.01;
            stock[0].Price = 0.04;


        }
    }
}
