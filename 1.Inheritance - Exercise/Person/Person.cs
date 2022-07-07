using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name
        {
            get 
            { 
                return name; 
            }
            set 
            {
                name = value; 
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set 
            { 
                if (value < 0)
                {
                    throw new ArgumentException("A person's age canno't be a negative number!");
                }
                age = value;
            }
        }
        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }
    }
}
