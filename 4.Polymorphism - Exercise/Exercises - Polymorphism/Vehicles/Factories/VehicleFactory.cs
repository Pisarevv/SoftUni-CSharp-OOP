using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Factories.Interfaces;
using Vehicles.Models;

namespace Vehicles.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public Vehicle CreateVehicle(string vehicleType, double fuelQuantity, double fuelConsumption, int tankCapacity)
        {
            Vehicle vehicle;

            if (vehicleType == "Car")
            {
                vehicle = new Car (fuelQuantity, fuelConsumption,tankCapacity);
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck (fuelQuantity, fuelConsumption,tankCapacity);

            }
            else if (vehicleType == "Bus")
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else
            {
                throw new ArgumentException("Invalid vehicle type");
            }
            return vehicle;
        }
    }
}
