using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private string name;
        private double weight;
        private int foodEaten;


        public Animal(string name, double weight, int foodEaten)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = foodEaten;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                name = value;
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }
            protected set
            {
                weight = value;
            }
        }

        public int FoodEaten
        {
            get
            {
                return foodEaten;
            }
            protected set
            {
                foodEaten = value;
            }
        }

        public abstract string ProduceSound();
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
        public abstract void FeedAnimal(Food food);
        
    }
}
