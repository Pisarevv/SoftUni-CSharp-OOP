using BirthdatCelebrations.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdatCelebrations.Models
{
    public class Citizen : IIdentifiable, IBirthable
    {
        private string name;
        private int age;
        private string id;
        private string birthDate;

        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthDay = birthday;
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
        public int Age
        {
            get
            {
                return age;
            }
            private set
            {
                age = value;
            }
        }
        public string Id
        {
            get
            {
                return id;
            }
            private set
            {
                id = value;
            }
        }

        public string BirthDay
        {
            get
            {
                return birthDate;
            }
            private set
            {
                birthDate = value;
            }
        }
    }
}
