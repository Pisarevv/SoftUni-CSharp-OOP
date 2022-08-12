using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly ICollection<IRace> models;
        public RaceRepository()
        {
            this.models = new HashSet<IRace>();
        }
       

        public IReadOnlyCollection<IRace> Models => (IReadOnlyCollection<IRace>)models;

        public void Add(IRace model) => this.models.Add(model);

        public bool Remove(IRace model) => this.models.Remove(model);

        public IRace FindByName(string raceName) => this.models.FirstOrDefault(x => x.RaceName == raceName);
    }
}
