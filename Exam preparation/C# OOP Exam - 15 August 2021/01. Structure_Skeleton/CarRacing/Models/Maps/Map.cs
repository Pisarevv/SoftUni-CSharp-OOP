using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public Map()
        {

        }
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {

            if (racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                racerOne.Race();
                racerTwo.Race();
                double firstRacerBehaviourMultiplier = racerOne.RacingBehavior == "aggressive" ? 1.1 : 1.2;
                double firstRacerWinningRate = racerOne.Car.HorsePower * racerOne.DrivingExperience * firstRacerBehaviourMultiplier;
                double secondRacerBehaviourMultiplier = racerTwo.RacingBehavior == "aggressive" ? 1.1 : 1.2;
                double secondRacerWinningRate = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * secondRacerBehaviourMultiplier;
                if (firstRacerWinningRate > secondRacerWinningRate)
                {
                    return String.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
                }
                if (firstRacerWinningRate < secondRacerWinningRate)
                {
                    return String.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
                }
            }          
             if(racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                //racerOne.Race();
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
             if (!racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                //racerTwo.Race();
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else 
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
        }
    }
}
