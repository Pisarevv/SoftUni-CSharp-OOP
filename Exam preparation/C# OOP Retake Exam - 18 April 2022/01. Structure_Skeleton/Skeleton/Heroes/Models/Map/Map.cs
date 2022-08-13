using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            ICollection<IHero>knights = players.Where(x => x.GetType().Name == "Knight").ToList();
            ICollection<IHero> barbarians = players.Where(x => x.GetType().Name == "Barbarian").ToList();
            foreach(IHero knight in knights.Where(x => x.IsAlive))
            {
                foreach(IHero barbarian in barbarians.Where(x => x.IsAlive))
                {
                    barbarian.TakeDamage(knight.Weapon.DoDamage());
                }
            }
            foreach (IHero barbarian in barbarians.Where(x => x.IsAlive))
            {
                foreach (IHero knight in knights.Where(x => x.IsAlive))
                {
                    knight.TakeDamage(barbarian.Weapon.DoDamage());
                }
            }

            if(barbarians.Where(x=> x.IsAlive).Count() == 0)
            {
                return $"The knights took {knights.Where(x=> !x.IsAlive).Count()} casualties but won the battle.";
            }
            else if(knights.Where(x=> x.IsAlive).Count() == 0)
            {
                return $"The barbarians  took {barbarians.Where(x => !x.IsAlive).Count()} casualties but won the battle.";
            }
            else
            {
                return null;
            }
        }
    }
}
