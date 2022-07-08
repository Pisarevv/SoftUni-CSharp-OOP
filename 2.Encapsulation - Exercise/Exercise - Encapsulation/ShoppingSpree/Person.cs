using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private readonly List<Product> boughtProducts;

        public Person()
        {
            boughtProducts = new List<Product>();
        }
        public Person(string name, decimal money):this()
        {
            this.Name = name;
            this.Money = money;
        }
        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        public decimal Money
        {
            get
            {
                return money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public IReadOnlyCollection<Product> BoughtProducts
        {
            get
            {
                return boughtProducts.AsReadOnly();
            }
        }

        public void AddProduct(Product product)
        {
            boughtProducts.Add(product);
        }
        public void ReduceMoney(decimal money)
        {
            this.Money -= money;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in boughtProducts)
            {
                sb.Append(item.Name + ",");
            }
            string[] toSplit = sb.ToString().Split(",",StringSplitOptions.RemoveEmptyEntries);
            string toReturn = string.Join(", ", toSplit);
            return toReturn.ToString().Trim();
        }

    }
}
