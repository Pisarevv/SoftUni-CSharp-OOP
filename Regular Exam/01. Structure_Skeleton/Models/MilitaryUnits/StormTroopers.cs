using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public class StormTroopers : MilitaryUnit
    {
        private const double InitialCost = 2.5;
        public StormTroopers() : base(InitialCost)
        {
        }
    }
}
