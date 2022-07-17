using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    internal class Car : Vehicle
    {
        private const double FuelModifier = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, int tankCapacity) : base(fuelQuantity, fuelConsumption + FuelModifier, tankCapacity)
        {
        }
    }
}
