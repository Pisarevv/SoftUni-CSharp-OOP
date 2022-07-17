using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int druidPower = 80;
        public Druid(string name, int power = druidPower) : base(name, power)
        {
        }
        public override string CastAbility()
        {
            return base.CastAbility() + $"healed for {this.Power}";
        }
    }
}
