using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        private readonly List<Type> eadibleFoods = new List<Type>()
        {
            typeof(Meat)
        };
        public Dog(string name, double weight, int foodEaten, string livingRegion) : base(name, weight, foodEaten, livingRegion)
        {

        }

        public override void FeedAnimal(Food food)
        {
            throw new NotImplementedException();
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
