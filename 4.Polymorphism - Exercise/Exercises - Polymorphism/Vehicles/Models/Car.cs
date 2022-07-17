using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    internal class Car : Vehicle
    {
        private const double FuelModifier = 0.9;
        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption + FuelModifier)
        {
        }
    }
}
