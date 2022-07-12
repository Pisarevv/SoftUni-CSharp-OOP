using ExplicitInterfaces.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces.Models
{
    public class Citizen : IResident, IPerson
    {
        private string name;
        private string country;
        private int age;

        public Citizen(string name, string country, int age)
        {
            this.Name = name;
            this.Country = country;
            this.Age = age;
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public string Country
        {
            get { return country; }
            private set { country = value; }
        }

        public int Age
        {
            get { return age; }
            private set { age = value; }
        }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }

        string IPerson.GetName()
        {
            return $"{this.Name}";
        }
    }
}
