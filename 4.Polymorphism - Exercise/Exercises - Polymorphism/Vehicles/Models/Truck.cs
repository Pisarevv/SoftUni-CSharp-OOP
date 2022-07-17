using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double FuelModifier = 1.6;
        private const double RefuelCoefficient = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption+ FuelModifier)
        {
        }
        public override void Refuel(double liters)
        {
            base.Refuel(liters * RefuelCoefficient);
        }
    }
}
