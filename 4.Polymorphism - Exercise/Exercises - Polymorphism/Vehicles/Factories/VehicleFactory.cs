using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Factories.Interfaces;
using Vehicles.Models;

namespace Vehicles.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public Vehicle CreateVehicle(string vehicleType, double fuelQuantity, double fuelConsumption)
        {
            Vehicle vehicle;

            if (vehicleType == "Car")
            {
                vehicle = new Car (fuelQuantity, fuelConsumption);
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck (fuelQuantity, fuelConsumption);

            }
            else
            {
                throw new ArgumentException("Invalid vehicle type");
            }
            return vehicle;
        }
    }
}
