using FoodShortage.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Models
{
    public class Pet : IBirthable
    {
        private string name;
        private string birthday;

        public Pet(string name, string birthDay)
        {
            this.Name = name;
            this.BirthDay = birthDay;
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
        public string BirthDay
        {
            get
            {
                return birthday;
            }
            private set
            {
                birthday = value;
            }
        }
    }
}
