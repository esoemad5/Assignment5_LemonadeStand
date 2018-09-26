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

        public void Add(Item item) // TODO
        {

        }
        public void Remove(Item item) // TODO
        {

        }

    }
}
