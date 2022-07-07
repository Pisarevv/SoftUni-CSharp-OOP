using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;
        private int horsePower;
        private double fuel;

        public Vehicle(int horsePower,double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }
        public int HorsePower { get => horsePower; set => horsePower = value; }
        public double Fuel { get => fuel; set => fuel = value; }
        
        public virtual double FuelConsumption
        {
            get
            {
                return DefaultFuelConsumption;
            }


        }
        public virtual void Drive(double kilometers)
        {
            double usedFuel = kilometers * FuelConsumption;
            fuel -= usedFuel;
        }
    }
}
