using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double InitialFuelAvailable = 65;
        private const double InitialFuelConsmptionPerRace = 7.5;
        public TunedCar(string make, string model, string VIN, int horsePower) : base(make, model, VIN, horsePower, InitialFuelAvailable, InitialFuelConsmptionPerRace)
        {
        }

        public override void Drive()
        {
            base.Drive();
            HorsePower = (int)Math.Round((double)HorsePower - (double)HorsePower * 0.03);
        }
    }
}
