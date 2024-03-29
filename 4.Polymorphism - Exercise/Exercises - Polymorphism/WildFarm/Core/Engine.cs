﻿using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.IO.Models.Interfaces;
using WildFarm.Models.Animals;
using WildFarm.Models.Foods;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly List<Animal> animals;

        public Engine()
        {
            animals = new List<Animal>();
        }
        public Engine(IReader reader, IWriter writer):this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            string input = string.Empty;
            while((input = reader.ReadLine()) != "End")
            {
                Animal animal;
                Food food;
                string[] cmdArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = cmdArgs[0];
                string name = cmdArgs[1];
                double weight = double.Parse(cmdArgs[2]);

                string[] foodInput = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string foodType = foodInput[0];
                int foodQuantity = int.Parse(foodInput[1]);
                food = CreateFood(foodType, foodQuantity);

                try
                {
                    if (type == "Cat")
                    {
                        string livingRegion = cmdArgs[3];
                        string breed = cmdArgs[4];
                        animal = new Cat(name, weight, livingRegion,breed);
                        writer.WriteLine(animal.ProduceSound());
                        animals.Add(animal);
                        animal.FeedAnimal(food);
                        


                    }
                    else if(type == "Tiger")
                    {
                        string livingRegion = cmdArgs[3];
                        string breed = cmdArgs[4];
                        animal = new Tiger(name, weight, livingRegion, breed);
                        writer.WriteLine(animal.ProduceSound());
                        animals.Add(animal);
                        animal.FeedAnimal(food);
                        
                    }
                    else if (type == "Owl")
                    {
                        double wingsSize = double.Parse(cmdArgs[3]);
                        animal = new Owl(name, weight, wingsSize);
                        writer.WriteLine(animal.ProduceSound());
                        animals.Add(animal);
                        animal.FeedAnimal(food);
                        
                    }
                    else if (type == "Hen")
                    {
                        double wingsSize = double.Parse(cmdArgs[3]);
                        animal = new Hen(name, weight, wingsSize);
                        writer.WriteLine(animal.ProduceSound());
                        animals.Add(animal);
                        animal.FeedAnimal(food);
                        
                    }
                    else if (type == "Dog")
                    {
                        string livingRegion = cmdArgs[3];                        
                        animal = new Dog(name, weight, livingRegion);
                        writer.WriteLine(animal.ProduceSound());
                        animals.Add(animal);
                        animal.FeedAnimal(food);
                        
                    }
                    else if (type == "Mouse")
                    {
                        string livingRegion = cmdArgs[3];
                        animal = new Mouse(name, weight,livingRegion);
                        writer.WriteLine(animal.ProduceSound());
                        animals.Add(animal);
                        animal.FeedAnimal(food);
                        
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
              
            }
            foreach (Animal animalFromList in animals)
            {
                writer.WriteLine(animalFromList.ToString());
            }
        }

        public Food CreateFood(string type, int quantity)
        {
            if (type == "Meat")
            {
                return new Meat(quantity);
            }
            else if (type == "Vegetable")
            {
                return new Vegetable(quantity);
            }
            else if (type == "Fruit")
            {
                return new Fruit(quantity);
            }
            else if (type == "Seeds")
            {
                return new Seeds(quantity);
            }
            else
            {
                throw new ArgumentException("Invalid food type");
            }
        }
    }
}
