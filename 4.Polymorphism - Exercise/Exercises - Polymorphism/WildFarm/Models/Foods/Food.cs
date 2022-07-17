using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Foods
{
    public abstract class Food : IFood
    {
        private int quantity;

        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }
            private set
            {
                quantity = value;
            }
        }
    }
}
