using _03BarracksFactory.Models.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_BarraksWars.Models.Units
{
    public class Gunner : Unit
    {
        private const int GunnerHealth = 20;
        private const int GunnerAttackDamage = 20;
        public Gunner() : base(GunnerHealth, GunnerAttackDamage)
        {
        }
    }
}
