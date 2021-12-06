using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6
{  
    abstract class Food
    {
        protected int _quantity;

        public Food(int quantity)
        {
            _quantity = quantity;
        }

        public int GetQuantity()
        {
            return _quantity;
        }
    }

    class Vegetable : Food
    {
        public Vegetable(int quantity) : base (quantity)
        {
        }
    }

    class Meat : Food
    {
        public Meat(int quantity) : base (quantity)
        {
        }
    }    
}
