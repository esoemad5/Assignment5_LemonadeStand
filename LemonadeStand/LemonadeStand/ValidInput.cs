using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class ValidInput
    {
        private string input;
        public string Input
        {
            get => input;
        }
        private string description;
        public string Description
        {
            get => description;
            set => description = value;
        }
        public ValidInput(string input)
        {
            this.input = input;
            description = "No description has been written for this command/item";
        }
    }
}
