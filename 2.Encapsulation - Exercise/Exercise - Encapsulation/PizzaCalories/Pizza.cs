using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private readonly List<Topping> toppings;
        private Dough doughtType;

        public Pizza()
        {
            toppings = new List<Topping>();
        }
        public Pizza(string name) : this()
        {
            this.Name = name;
        }
        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || (value.Length < 1 || value.Length > 15))
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        public void AddDough(Dough dough)
        {
            doughtType = dough;
        }
        public void AddTopping(Topping topping)
        {
            if(toppings.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }

        public override string ToString()
        {
            double totalCalories = 0;
            foreach (Topping topping in toppings)
            {
                totalCalories += topping.TotalCalories;
            }
            totalCalories += this.doughtType.TotalCalories;
            return $"{this.Name} - {totalCalories:F2} Calories.";
        }
    }
}
