using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Product> productsList = new List<Product>();
            List<Person> personsList = new List<Person>();
            string[] peopleInput = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries);
            foreach (string person in peopleInput)
            {
                try
                {
                    string[] personInfo = person.Split("=");                    
                    string name = personInfo[0];
                    decimal money = decimal.Parse(personInfo[1]);
                    Person newPerson = new Person(name,money);
                    personsList.Add(newPerson);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
            }
            string[] productsInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            foreach (string product in productsInput)
            {
                try
                {
                    string[] productInfo = product.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    string name = productInfo[0];
                    decimal money = decimal.Parse(productInfo[1]);
                    Product newProduct = new Product(name,money);
                    productsList.Add(newProduct);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
            }
            string input = string.Empty;
            while((input = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Person currentPerson = personsList.FirstOrDefault(x => x.Name == cmdArgs[0]);
                Product currentProduct = productsList.FirstOrDefault(x => x.Name == cmdArgs[1]);

                if(currentPerson.Money >= currentProduct.Cost)
                {
                    currentPerson.AddProduct(currentProduct);
                    currentPerson.ReduceMoney(currentProduct.Cost);
                    Console.WriteLine($"{currentPerson.Name} bought {currentProduct.Name}");
                }
                else
                {
                    Console.WriteLine($"{currentPerson.Name} can't afford {currentProduct.Name}");
                }
            }
            foreach (Person person1 in personsList)
            {
                if (person1.BoughtProducts.Count > 0)
                {
                    Console.WriteLine($"{person1.Name} - {person1.ToString()}");
                }
                else
                {
                    Console.WriteLine($"{person1.Name} - Nothing bought");
                }
            }
        }
    }
}
