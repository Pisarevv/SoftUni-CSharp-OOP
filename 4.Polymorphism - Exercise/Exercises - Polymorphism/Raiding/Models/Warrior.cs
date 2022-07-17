using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int warriorPower = 100;
        public Warrior(string name, int power = warriorPower) : base(name, power)
        {
        }
        public override string CastAbility()
        {
            return base.CastAbility() + $"hit for {this.Power} damage";
        }
    }
}
