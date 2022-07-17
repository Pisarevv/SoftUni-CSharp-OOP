using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models.Interfaces
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }
        public double FuelConsumption { get; }
        public double DrivenDistance { get; }
        public int TankCapacity { get; }
    }
}
