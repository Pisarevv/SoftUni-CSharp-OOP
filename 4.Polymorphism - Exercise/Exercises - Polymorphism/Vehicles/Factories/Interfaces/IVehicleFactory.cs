using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models;

namespace Vehicles.Factories.Interfaces
{
    public interface IVehicleFactory
    {
        Vehicle CreateVehicle(string vehicleType, double fuelQuantity, double fuelConsumption);
    }
}
