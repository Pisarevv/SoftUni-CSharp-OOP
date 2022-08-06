using AquaShop.Models.Aquariums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {      
        private const int InitFishSize = 3;
        public FreshwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
            this.Size = InitFishSize;
        }

        public override void Eat()
        {
            this.Size += 3;
        }
    }
}
