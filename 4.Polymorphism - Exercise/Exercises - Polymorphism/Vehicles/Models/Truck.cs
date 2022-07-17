using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double FuelModifier = 1.6;
        private const double RefuelCoefficient = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption, int tankCapacity) : base(fuelQuantity, fuelConsumption+ FuelModifier, tankCapacity)
        {
        }
        public override void Refuel(double liters)
        {
            if (liters > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            base.Refuel(liters * RefuelCoefficient);
        }
    }
}
