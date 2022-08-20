﻿using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private ICollection<IPlanet> models;
        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => (IReadOnlyCollection<IPlanet>)models;

        public void AddItem(IPlanet model)=>this.models.Add(model);


        public IPlanet FindByName(string name) => this.models.FirstOrDefault(x => x.Name == name);


        public bool RemoveItem(string name) => this.models.Remove(FindByName(name));
        
    }
}
