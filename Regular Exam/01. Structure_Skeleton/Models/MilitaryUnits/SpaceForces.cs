using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public class SpaceForces : MilitaryUnit
    {
        private const double InitialCost = 11;
        public SpaceForces() : base(InitialCost)
        {
        }
    }
}
