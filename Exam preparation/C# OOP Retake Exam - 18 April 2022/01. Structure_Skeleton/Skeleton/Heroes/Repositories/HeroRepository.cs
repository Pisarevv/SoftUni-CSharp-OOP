﻿using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private ICollection<IHero> models;
        public HeroRepository()
        {
            models = new List<IHero>();
        }
        public IReadOnlyCollection<IHero> Models => (IReadOnlyCollection<IHero>)models;

        public void Add(IHero model) => this.models.Add(model);
        public bool Remove(IHero model) => this.models.Remove(model);
     
        public IHero FindByName(string name) => this.models.FirstOrDefault(x => x.Name == name);
 
        
    }
}
