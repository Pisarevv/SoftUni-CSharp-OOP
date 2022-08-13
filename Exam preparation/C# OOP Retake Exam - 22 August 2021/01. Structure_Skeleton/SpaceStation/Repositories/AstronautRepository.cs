using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private ICollection<IAstronaut> models;
        public AstronautRepository()
        {
            this.models = new List<IAstronaut>();
        }
        public IReadOnlyCollection<IAstronaut> Models => (IReadOnlyCollection<IAstronaut>)this.models;

        public void Add(IAstronaut model) => this.models.Add(model);

        public bool Remove(IAstronaut model)=>this.models.Remove(model);


        public IAstronaut FindByName(string name) => this.models.FirstOrDefault(x => x.Name == name);
        

        
    }
}
