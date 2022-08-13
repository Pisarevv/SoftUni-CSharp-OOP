using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const int InitialDrivingExperience = 10;
        private const string InitialDrivingBehaviour = "aggressive";
        public StreetRacer(string username,ICar car) : base(username, InitialDrivingBehaviour, InitialDrivingExperience, car)
        {
        }
        public override void Race()
        {
            base.Race();
            DrivingExperience += 5;
        }
    }
}
