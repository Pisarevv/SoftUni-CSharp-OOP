using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int paladinPower = 100;
        public Paladin(string name, int power = paladinPower) : base(name, power)
        {
        }
        public override string CastAbility()
        {
            return base.CastAbility() + $"healed for {this.Power}";
        }
    }
}
