using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private ICollection<IDecoration> models;
        public DecorationRepository()
        {
            this.models = new HashSet<IDecoration>();
        }
        public IReadOnlyCollection<IDecoration> Models => (IReadOnlyCollection<IDecoration>)this.models;
        

        public void Add(IDecoration model) => this.models.Add(model);
       

        public IDecoration FindByType(string type)=> models.Where(x => x.GetType().Name == type).FirstOrDefault();


        public bool Remove(IDecoration model) => this.models.Remove(model);

    }
}
