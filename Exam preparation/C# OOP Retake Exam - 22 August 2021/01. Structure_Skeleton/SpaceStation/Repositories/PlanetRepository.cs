using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private ICollection<IPlanet> models;
        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => (IReadOnlyCollection<IPlanet>)this.models;
        public void Add(IPlanet model)=>this.models.Add(model);
        public bool Remove(IPlanet model) => this.models.Remove(model);

        public IPlanet FindByName(string name) => this.models.FirstOrDefault(x => x.Name == name);
       
     
    }
}
