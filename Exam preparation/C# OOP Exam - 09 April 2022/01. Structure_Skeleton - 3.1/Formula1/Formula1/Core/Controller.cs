﻿using Formula1.Core.Contracts;
using Formula1.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Formula1.Models.Contracts;
using Formula1.Utilities;
using Formula1.Models;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository formulaOneCarRepository;
        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            formulaOneCarRepository = new FormulaOneCarRepository();
        }
        public string CreatePilot(string fullName)
        {
            if(pilotRepository.FindByName(fullName) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }
            IPilot pilot = new Pilot(fullName);
            pilotRepository.Add(pilot);
            return String.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if(formulaOneCarRepository.FindByName(model) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage, model));
            }
            if(type != "Williams" && type!= "Ferrari")
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidTypeCar, type));
            }
            IFormulaOneCar newCar = null;
            if(type == "Williams")
            {
                newCar = new Williams(model,horsepower,engineDisplacement);
            }
            if (type == "Ferrari")
            {
                newCar = new Ferrari(model, horsepower, engineDisplacement);
            }
            formulaOneCarRepository.Add(newCar);
            return String.Format(OutputMessages.SuccessfullyCreateCar, type,model);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if(raceRepository.FindByName(raceName) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }
            IRace newRace = new Race(raceName,numberOfLaps);
            raceRepository.Add(newRace);
            return String.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilotToAddCar = pilotRepository.FindByName(pilotName);
            if (pilotToAddCar == null || pilotToAddCar.Car != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            IFormulaOneCar carToBeAdded = formulaOneCarRepository.FindByName(carModel);
            if(carToBeAdded == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }
            pilotToAddCar.AddCar(carToBeAdded);
            formulaOneCarRepository.Remove(carToBeAdded);
            return String.Format(OutputMessages.SuccessfullyPilotToCar, pilotName,carToBeAdded.GetType().Name,carModel);
            
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace raceToAddPilot = raceRepository.FindByName(raceName);
            if(raceToAddPilot== null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            IPilot pilotToAddToRace = pilotRepository.FindByName(pilotFullName);
            if (pilotToAddToRace == null || pilotToAddToRace.CanRace == false 
                || raceToAddPilot.Pilots.FirstOrDefault(x => x.FullName == pilotFullName) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }
            raceToAddPilot.AddPilot(pilotToAddToRace);
            return String.Format(OutputMessages.SuccessfullyAddPilotToRace,pilotFullName,raceName);
        }

        public string StartRace(string raceName)
        {
            IRace raceToStart = raceRepository.FindByName(raceName);
            if(raceToStart == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage,raceName));
            }
            if(raceToStart.Pilots.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }
            if(raceToStart.TookPlace == true)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceTookPlaceErrorMessage,raceName));
            }

            raceToStart.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(raceToStart.NumberOfLaps));

           List <IPilot> topThreePilots = raceToStart
                .Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(raceToStart.NumberOfLaps))
                .Take(3).ToList();
            topThreePilots[0].WinRace();
            raceToStart.TookPlace = true;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Pilot {topThreePilots[0].FullName} wins the {raceName} race.")
                .AppendLine($"Pilot {topThreePilots[1].FullName} is second in the {raceName} race.")
                .Append($"Pilot {topThreePilots[2].FullName} is third in the {raceName} race");
            return sb.ToString();

        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IRace race in raceRepository.Models.Where(x=> x.TookPlace == true))
            {
                sb.AppendLine(race.RaceInfo());
            }
            return sb.ToString().TrimEnd();
        }
        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach(IPilot pilot in pilotRepository.Models.OrderByDescending(x => x.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        

        
    }
}
