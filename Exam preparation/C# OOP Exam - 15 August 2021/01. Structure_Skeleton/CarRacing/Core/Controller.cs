using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;
        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
            this.map = new Map();
        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar newCar = null;
            if(type == "SuperCar")
            {
                newCar = new SuperCar(make, model, VIN, horsePower);
            }
            else if(type == "TunedCar")
            {
                newCar = new TunedCar(make, model, VIN, horsePower);
            }
            else
            {
                return ExceptionMessages.InvalidCarType;
            }
            cars.Add(newCar);
            return String.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);

        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = cars.FindBy(carVIN);
            if(car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }
            IRacer racer = null;
            if(type == "ProfessionalRacer")
            {
                racer = new ProfessionalRacer(username, car);
            }
            else if (type == "StreetRacer")
            {
                racer = new StreetRacer(username, car);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }
            racers.Add(racer);
            return String.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = racers.FindBy(racerOneUsername);
            IRacer racerTwo = racers.FindBy(racerTwoUsername);
            if(racerOne == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }
            if(racerTwo == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }
            return map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            List<IRacer> orderedRacers = racers.Models.OrderByDescending(x => x.DrivingExperience).ThenBy(x => x.Username).ToList();
            StringBuilder sb = new StringBuilder();
            foreach(IRacer racer in orderedRacers)
            {
                sb.AppendLine(racer.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
