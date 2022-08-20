using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduraceLevel;
        public MilitaryUnit(double cost)
        {
            this.Cost = cost;
            this.EnduranceLevel = 1;
        }
        public double Cost
        {
            get => this.cost;
            private set
            {
                this.cost = value;
            }
        }

        public int EnduranceLevel
        {
            get => this.enduraceLevel;
            private set
            {
                if(value > 20)
                {
                    throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
                }
                this.enduraceLevel = value;
            }
        }

        public void IncreaseEndurance()
        {
            this.EnduranceLevel++;
        }
    }
}
