using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private readonly ICollection<IEquipment> models;
        public EquipmentRepository()
        {
            models = new List<IEquipment>();
        }
        public IReadOnlyCollection<IEquipment> Models => (IReadOnlyCollection<IEquipment>)models;

        public void Add(IEquipment model) => this.models.Add(model);

        public bool Remove(IEquipment model) => this.models.Remove(model);

        public IEquipment FindByType(string type) =>
            this.models.Where(x => x.GetType().Name == type).FirstOrDefault();
     
        
    }
}
