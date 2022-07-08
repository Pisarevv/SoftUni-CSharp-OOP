using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const double BaseCaloriesPerGram = 2;
        private readonly Dictionary<string, double> toppingsDic = new Dictionary<string, double>()
        {         
            ["meat"] = 1.2,
            ["veggies"] = 0.8,
            ["cheese"] = 1.1,
            ["sauce"] = 0.9
        };
        private string toppingType;
        private double grams;
        private double totalCalories;
        public Topping(string toppingType,double grams)
        {
            this.ToppingType = toppingType;
            this.Grams = grams;
            CalculateTotalCalories();
        }
        public string ToppingType
        {
            get
            {
                return toppingType;
            }
            private set
            {
                if (!toppingsDic.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                toppingType = value;
            }
        }
        public double Grams
        {
            get
            {
                return grams;
            }
            private set
            {
                if(value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
                }
                grams = value;
            }
        }
        public double TotalCalories
        {
            get
            {
                return totalCalories;
            }
        }
        private void CalculateTotalCalories()
        {
            double toppingTypeCalories = toppingsDic[ToppingType.ToLower()];
            this.totalCalories = toppingTypeCalories * grams * BaseCaloriesPerGram;
        }
    }
}
