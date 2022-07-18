using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private const double GainWeightPerServings = 0.25;
        private readonly List<Type> eadibleFoods = new List<Type>()
        {
            typeof(Meat)
        };
        public Owl(string name, double weight, int foodEaten, double wingSize) : base(name, weight, foodEaten, wingSize)
        {
        }

        public override void FeedAnimal(Food food)
        {
            if (eadibleFoods.Contains(food.GetType()))
            {
                this.Weight += GainWeightPerServings * food.Quantity;
                this.FoodEaten = +food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}");
            }
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
