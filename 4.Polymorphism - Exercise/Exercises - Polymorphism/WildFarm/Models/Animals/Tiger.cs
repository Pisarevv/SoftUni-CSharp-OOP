using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        private readonly List<Type> eadibleFoods = new List<Type>()
        {
            typeof(Meat)
        };
        public Tiger(string name, double weight, int foodEaten, string livingRegion, string breed) : base(name, weight, foodEaten, livingRegion,breed)
        {
        }

        public override void FeedAnimal(Food food)
        {
            throw new NotImplementedException();
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
