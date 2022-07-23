using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double GainWeightPerServings = 0.35;
        private readonly List<Type> eadibleFoods = new List<Type>()
        {
            typeof(Food)
        };
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void FeedAnimal(Food food)
        {
            if (eadibleFoods.Contains(food.GetType()))
            {
                this.Weight += GainWeightPerServings * food.Quantity;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
