using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        
        private double fuelQuantity;
        private double fuelConsumption;
        private int tankCapacity;
        private double drivenDistance = 0;

        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity
        {
            get
            {
                return fuelQuantity;
            }
            protected set
            {
                if(value > this.TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else 
                {
                    fuelQuantity = value; 
                }
                
            }
        }

        public double FuelConsumption
        {
            get
            {
                return fuelConsumption;
            }
            private set
            {
                fuelConsumption = value;
            }
        }

        public double DrivenDistance
        {
            get
            {
                return drivenDistance;
            }
            private set
            {
                drivenDistance = value;
            }
        }

        public int TankCapacity
        {
            get
            {
                return tankCapacity;
            }
            private set
            {
                tankCapacity = value;
            }
        }

        public string Drive(double distance)
        {
            double neededFuelToTravel = distance * this.FuelConsumption;
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
        public virtual void Refuel(double liters)
        {
            if (liters < 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (liters > tankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            this.FuelQuantity += liters;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
