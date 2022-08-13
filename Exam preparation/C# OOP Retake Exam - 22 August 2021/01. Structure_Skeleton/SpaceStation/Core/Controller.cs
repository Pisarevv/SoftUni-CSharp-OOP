using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private IRepository<IAstronaut> astronautsRepository;
        private IRepository<IPlanet> planetsRepository;
        private int exploredPlanets;
        public Controller()
        {
            this.astronautsRepository = new AstronautRepository();
            this.planetsRepository = new PlanetRepository();
            exploredPlanets = 0;
        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut newAstronaut = null;
            if(type == "Biologist")
            {
                newAstronaut = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                newAstronaut = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                newAstronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }
            astronautsRepository.Add(newAstronaut);
            return String.Format(OutputMessages.AstronautAdded, type, astronautName);

        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet newPlanet = new Planet(planetName);
            foreach(string item in items)
            {
                newPlanet.Items.Add(item);
            }
            planetsRepository.Add(newPlanet);
            return String.Format(OutputMessages.PlanetAdded, planetName);
        }
        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronautToRetire = astronautsRepository.FindByName(astronautName);
            if(astronautToRetire == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }
            astronautsRepository.Remove(astronautToRetire);
            return String.Format(OutputMessages.AstronautRetired, astronautName);
        }
        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> suitableAstronauts = astronautsRepository.Models.Where(x => x.Oxygen > 60).ToList();
            if(suitableAstronauts.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }
            IPlanet planetToExplore = planetsRepository.FindByName(planetName);
            if(planetToExplore!= null)
            {
                IMission mission = new Mission();
                mission.Explore(planetToExplore, suitableAstronauts);
                exploredPlanets++;
            }
            return String.Format(OutputMessages.PlanetExplored, planetName,suitableAstronauts.Where(x=> !x.CanBreath).ToList().Count);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{exploredPlanets} planets were explored!");
            foreach (IAstronaut astronaut in astronautsRepository.Models)
            {
              
                    sb.AppendLine("Astronauts info:")
                    .AppendLine($"Name: {astronaut.Name}")
                    .AppendLine($"Oxygen: {astronaut.Oxygen}")
                    .AppendLine($"Bag items: {(astronaut.Bag.Items.Count > 0 ? (String.Join(", ", astronaut.Bag.Items)) : "none")}");

            }
            return sb.ToString().TrimEnd();
        }

        
    }
}
