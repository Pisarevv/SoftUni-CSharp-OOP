using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        private const double GainWeightPerServings = 1.00;
        private readonly List<Type> eadibleFoods = new List<Type>()
        {
            typeof(Meat)
        };
        public Tiger(string name, double weight, int foodEaten, string livingRegion, string breed) : base(name, weight, foodEaten, livingRegion,breed)
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
            return "ROAR!!!";
        }
    }
}
