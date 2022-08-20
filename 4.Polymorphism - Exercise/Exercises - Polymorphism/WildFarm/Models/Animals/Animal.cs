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
        private int foodEaten = 0;


        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name
        {
            get
            {
                return name;
            }
            protected set
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
