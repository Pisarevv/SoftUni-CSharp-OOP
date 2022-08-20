using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private IRepository<IPlanet> planets;
        public Controller()
        {
            planets = new PlanetRepository();
        }

        public string CreatePlanet(string name, double budget)
        {
            if(planets.FindByName(name) != null)
            {
                return String.Format(OutputMessages.ExistingPlanet, name);
            }
            IPlanet newPlanet = new Planet(name, budget);
            planets.AddItem(newPlanet);
            return String.Format(OutputMessages.NewPlanet, name);
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            
            IPlanet planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            IMilitaryUnit unitToBeAdded = null;
            if(unitTypeName == "AnonymousImpactUnit")
            {
                unitToBeAdded = new AnonymousImpactUnit();
            }
            else if(unitTypeName == "SpaceForces")
            {
                unitToBeAdded = new SpaceForces();
            }
            else if(unitTypeName == "StormTroopers")
            {
                unitToBeAdded = new StormTroopers();
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }
            if(planet.Army.Any(x => x.GetType().Name == unitToBeAdded.GetType().Name))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName,planetName));
            }
            planet.Spend(unitToBeAdded.Cost);
            planet.AddUnit(unitToBeAdded);
            return String.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
            
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if(planet.Weapons.Any(x=> x.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName,planetName));    
            }
            IWeapon weapon = null;
            if (weaponTypeName == "BioChemicalWeapon")
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if(weaponTypeName == "SpaceMissiles")
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }
            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);
            return String.Format(OutputMessages.WeaponAdded, planetName,weaponTypeName);
        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if(planet.Army.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }
            double moneyForTraining = 1.25;
            planet.Spend(moneyForTraining);
            foreach(IMilitaryUnit unit in planet.Army)
            {
                unit.IncreaseEndurance();
            }
            return String.Format(OutputMessages.ForcesUpgraded, planetName);
        }
        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet planetOneForCombat = planets.FindByName(planetOne);
            IPlanet planetTwoForCombat = planets.FindByName(planetTwo);

            IPlanet winnerPlanet = null;
            IPlanet loserPlanet = null;

            double firstPlanetMilitaryPower = planetOneForCombat.MilitaryPower;
            double secondPlanetMilitaryPower = planetTwoForCombat.MilitaryPower;
            if(firstPlanetMilitaryPower == secondPlanetMilitaryPower)
            {
                if(planetOneForCombat.Weapons.Any(x => x.GetType().Name == "NuclearWeapon") 
                && planetTwoForCombat.Weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
                {
                    planetOneForCombat.Spend(planetOneForCombat.Budget / 2);
                    planetTwoForCombat.Spend(planetTwoForCombat.Budget / 2);
                    return OutputMessages.NoWinner;
                }
                else if(!planetOneForCombat.Weapons.Any(x => x.GetType().Name == "NuclearWeapon")
                && !planetTwoForCombat.Weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
                {
                    planetOneForCombat.Spend(planetOneForCombat.Budget / 2);
                    planetTwoForCombat.Spend(planetTwoForCombat.Budget / 2);
                    return OutputMessages.NoWinner;
                }
                else if (planetOneForCombat.Weapons.Any(x => x.GetType().Name == "NuclearWeapon")
                && !planetTwoForCombat.Weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
                {
                    winnerPlanet = planetOneForCombat;
                    loserPlanet = planetTwoForCombat;
                }
                else if (!planetOneForCombat.Weapons.Any(x => x.GetType().Name == "NuclearWeapon")
                && planetTwoForCombat.Weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
                {
                    winnerPlanet = planetTwoForCombat;
                    loserPlanet = planetOneForCombat;
                }
            }
            else if(firstPlanetMilitaryPower > secondPlanetMilitaryPower)
            {
                winnerPlanet = planetOneForCombat;
                loserPlanet = planetTwoForCombat;
            }
            else if (secondPlanetMilitaryPower > firstPlanetMilitaryPower)
            {
                winnerPlanet = planetTwoForCombat;
                loserPlanet = planetOneForCombat;
            }
            winnerPlanet.Spend(winnerPlanet.Budget / 2);
            winnerPlanet.Profit(loserPlanet.Budget / 2);
            foreach(IWeapon weapon in loserPlanet.Weapons)
            {
                winnerPlanet.Profit(weapon.Price);
            }
            foreach (IMilitaryUnit unit in loserPlanet.Army)
            {
                winnerPlanet.Profit(unit.Cost);
            }
            planets.RemoveItem(loserPlanet.Name);
            return String.Format(OutputMessages.WinnigTheWar, winnerPlanet.Name, loserPlanet.Name);
        }
        public string ForcesReport()
        {
            List<IPlanet> orderedPlanets = planets.Models.OrderByDescending(x => x.MilitaryPower).ThenBy(x => x.Name).ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach(IPlanet planet in orderedPlanets)
            {
                sb.AppendLine(planet.PlanetInfo());
            }
            return sb.ToString().TrimEnd();
        }

        

        
    }
}
