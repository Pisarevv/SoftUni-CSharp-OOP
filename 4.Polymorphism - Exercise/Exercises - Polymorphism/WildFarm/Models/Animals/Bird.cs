using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals
{
    public abstract class Bird : Animal
    {
        private double wingSize;
        protected Bird(string name, double weight, int foodEaten, double wingSize) : base(name, weight, foodEaten)
        {
            this.WingSize = wingSize;
        }
        public double WingSize
        {
            get
            {
                return wingSize;
            }
            private set
            {
                wingSize = value;
            }
        }
        public override string ToString()
        {
            return base.ToString() + $"{this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
