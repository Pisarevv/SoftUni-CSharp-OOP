using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    internal class Bus : Vehicle
    {        
        private const double FuelModifierFull = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption + FuelModifierFull)
        {
        }

        public string DriveEmpty(double distance)
        {
            double neededFuelToTravel = distance * (this.FuelConsumption - FuelModifierFull);
            if (this.FuelQuantity > neededFuelToTravel)
            {
                this.FuelQuantity -= neededFuelToTravel;
                return $"{this.GetType().Name} travelled {distance} km";
            }
            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }
    }
}
