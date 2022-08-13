using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const int InitialDrivingExperience = 30;
        private const string InitialDrivingBehaviour = "strict";
        public ProfessionalRacer(string username,ICar car) : base(username, InitialDrivingBehaviour, InitialDrivingExperience, car)
        {
        }
        public override void Race()
        {
            base.Race();
            DrivingExperience += 10;
        }
    }
}
