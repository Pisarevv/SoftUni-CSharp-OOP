using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private ICollection<IRacer> models;
        public RacerRepository()
        {
            this.models = new List<IRacer>();
        }
        public IReadOnlyCollection<IRacer> Models => (IReadOnlyCollection<IRacer>)models;

        public void Add(IRacer racer)
        {
           if(racer == null)
            {
                throw new ArgumentNullException(ExceptionMessages.InvalidAddRacerRepository);
            }
           this.models.Add(racer);
        }
        public bool Remove(IRacer racer) => this.models.Remove(racer);
       

        public IRacer FindBy(string property)=>this.models.FirstOrDefault(x=> x.Username==property);
        

        
    }
}
