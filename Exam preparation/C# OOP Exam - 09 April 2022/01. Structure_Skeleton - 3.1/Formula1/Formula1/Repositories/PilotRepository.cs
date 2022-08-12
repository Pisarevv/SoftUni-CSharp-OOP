using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private readonly ICollection<IPilot> models;
        public PilotRepository()
        {
            this.models = new HashSet<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models => (IReadOnlyCollection<IPilot>)models;

        public void Add(IPilot model) => this.models.Add(model);

        public bool Remove(IPilot model) => this.models.Remove(model);

        public IPilot FindByName(string fullName) => this.models.FirstOrDefault(x => x.FullName == fullName);
    }
}
