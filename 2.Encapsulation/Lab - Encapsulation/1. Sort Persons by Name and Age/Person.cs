using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException(ErrorsList.InvalidFirstName);
                }
                firstName = value;
            }
        }
        public string LastName
        {
            get
            { 
                return lastName;
            }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException(ErrorsList.InvalidLastName);
                }
                lastName = value;
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
                if (value <= 0)
                {
                    throw new ArgumentException(ErrorsList.NegativeAge);
                }
                age = value;
            }
        }
        public decimal Salary
        {
            get
            {
                return salary;
            }
            private set
            {
               if (value < 650)
                {
                    throw new ArgumentException(ErrorsList.InvalidSalary);
                }
                salary = value;
            }
        }

    
        
    }
}
