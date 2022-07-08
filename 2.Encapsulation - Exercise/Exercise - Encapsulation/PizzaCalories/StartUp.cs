using System;

namespace PizzaCalories
{
    internal class StartUp
    {
        static void Main()
        {
            string input = string.Empty;
            Pizza pizza = null;
            while((input = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = input.Split(' ');
                string command = cmdArgs[0];
                if(command == "Pizza")
                {
                    try
                    {
                        string pizzaName = cmdArgs[1];
                        Pizza newPizza = new Pizza(pizzaName);
                        pizza = newPizza;
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                        return;
                    }
                }
                else if (command == "Dough")
                {
                    string flourType = cmdArgs[1];
                    string bakingTechnique = cmdArgs[2];
                    double grams = double.Parse(cmdArgs[3]);
                    try
                    {
                        Dough newDough = new Dough(flourType, bakingTechnique, grams);
                        pizza.AddDough(newDough);
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                        return;
                    }
                    
                }
                else if (command == "Topping")
                {
                    string toppingType = cmdArgs[1];
                    double grams = double.Parse(cmdArgs[2]);
                    try
                    {
                        Topping newTopping = new Topping(toppingType, grams);
                        pizza.AddTopping(newTopping);
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                        return;
                    }

                }
            }
            Console.WriteLine(pizza.ToString());
        }
    }
}
