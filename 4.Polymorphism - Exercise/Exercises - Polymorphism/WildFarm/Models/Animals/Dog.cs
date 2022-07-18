using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        private const double GainWeightPerServings = 0.40;
        private readonly List<Type> eadibleFoods = new List<Type>()
        {
            typeof(Meat)
        };
        public Dog(string name, double weight, int foodEaten, string livingRegion) : base(name, weight, foodEaten, livingRegion)
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
            return "Woof!";
        }
    }
}
