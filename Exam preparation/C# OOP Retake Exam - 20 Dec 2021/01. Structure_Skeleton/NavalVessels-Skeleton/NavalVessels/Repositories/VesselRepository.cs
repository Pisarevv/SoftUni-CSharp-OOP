using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private ICollection<IVessel> models;
        public VesselRepository()
        {
            models = new HashSet<IVessel>();
        }
        public IReadOnlyCollection<IVessel> Models =>(IReadOnlyCollection<IVessel>)models;

        public void Add(IVessel model) => models.Add(model);


        public IVessel FindByName(string name) => models.FirstOrDefault(x => x.Name == name);
        
        public bool Remove(IVessel model) => models.Remove(model);
        
    }
}
