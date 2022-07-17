using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private readonly List<Type> eadibleFoods = new List<Type>()
        {
            typeof(Meat)
        };
        public Owl(string name, double weight, int foodEaten, double wingSize) : base(name, weight, foodEaten, wingSize)
        {
        }

        public override void FeedAnimal(Food food)
        {
            throw new NotImplementedException();
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
