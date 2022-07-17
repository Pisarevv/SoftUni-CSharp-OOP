using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals
{
    public abstract class Mammal : Animal
    {
        private string livingRegion;
        protected Mammal(string name, double weight, int foodEaten, string livingRegion) : base(name, weight, foodEaten)
        {
            this.livingRegion = livingRegion;           
        }
        public string LivingRegion
        {
            get
            {
                return livingRegion;
            }
            private set
            {
                this.livingRegion = value;
            }
        }
    }
}
