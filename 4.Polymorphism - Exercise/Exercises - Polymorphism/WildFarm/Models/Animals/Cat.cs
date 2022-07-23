using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private const double GainWeightPerServings = 0.30;
        private readonly List<Type> eadibleFoods = new List<Type>()
        {
            typeof(Vegetable),
            typeof(Meat)
        };
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight,livingRegion, breed)
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
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name!}");
            }
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
