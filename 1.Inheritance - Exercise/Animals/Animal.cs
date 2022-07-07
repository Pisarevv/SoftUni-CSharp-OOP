using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;

        protected Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set 
            { 
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Invalid input!");
                }
                name = value;
            }
        }
        public int Age
        {
            get
            { 
                return age;
            }
            private set
            {
             if(value < 0)
                {
                    throw new ArgumentNullException("Invalid input!");
                }
             age = value;
            }
        }
        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Invalid input!");
                }
                gender = value;
            }
        }
        public abstract string ProduceSound();
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.AppendLine(this.ProduceSound());
            return sb.ToString().TrimEnd();
        }
    }
}
