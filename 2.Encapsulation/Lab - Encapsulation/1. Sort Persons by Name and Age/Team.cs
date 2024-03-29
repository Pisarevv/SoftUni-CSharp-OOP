﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private readonly List<Person> firstTeam;
        private readonly List<Person> reserveTeam;

   
        public Team(string name)
        {
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
            this.Name = name;
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
        public IReadOnlyCollection<Person> FirstTeam
        {
            get
            {
                return firstTeam.AsReadOnly();
            }
            
        }
        public IReadOnlyCollection<Person> ReserveTeam
        {
            get
            {
                return reserveTeam.AsReadOnly();
            }
        }
        public void AddPlayer (Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }
       
    }
}
