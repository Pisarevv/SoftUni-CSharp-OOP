using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private ICollection<IWeapon> models;
        public WeaponRepository()
        {
            this.models = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => (IReadOnlyCollection<IWeapon>)models;

        public void AddItem(IWeapon model)=> this.models.Add(model);
       

        public IWeapon FindByName(string name)=>this.models.FirstOrDefault(x => x.GetType().Name == name);
     

        public bool RemoveItem(string name)=>this.models.Remove(FindByName(name));
        
    }
}
