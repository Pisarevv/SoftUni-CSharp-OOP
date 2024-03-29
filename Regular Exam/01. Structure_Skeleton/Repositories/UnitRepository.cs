﻿using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private ICollection<IMilitaryUnit> models;
        public UnitRepository()
        {
            this.models = new List<IMilitaryUnit>();
        }
        public IReadOnlyCollection<IMilitaryUnit> Models => (IReadOnlyCollection<IMilitaryUnit>)models;

        public void AddItem(IMilitaryUnit model)=>this.models.Add(model);
        
        public IMilitaryUnit FindByName(string name)=>this.models.FirstOrDefault(x=> x.GetType().Name == name);

        public bool RemoveItem(string name) => this.models.Remove(FindByName(name));
        
    }
}
