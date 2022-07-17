using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        private readonly List<Type> eadibleFoods = new List<Type>()
        {
            typeof(Vegetable),
            typeof(Fruit)
        };
        public Mouse(string name, double weight, int foodEaten, string livingRegion) : base(name, weight, foodEaten, livingRegion)
        {
        }

        public override void FeedAnimal(Food food)
        {
            throw new NotImplementedException();
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
