using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AquaShop.Models.Fish;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private IRepository<IDecoration> decorations = new DecorationRepository();
        private List<IAquarium> aquariums =new List<IAquarium>();
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            Aquarium aquarium = null;
            if(!(aquariumType == "FreshwaterAquarium" || aquariumType == "SaltwaterAquarium"))
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }
            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            aquariums.Add(aquarium);
            return $"Successfully added {aquarium.GetType().Name}.";
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;
            if (!(decorationType == "Ornament" || decorationType == "Plant"))
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }
            if(decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else
            {
                decoration = new Plant();
            }
            decorations.Add(decoration);
            return $"Successfully added {decoration.GetType().Name}.";
        }
        public string InsertDecoration(string aquariumName, string decorationType)
        {
            bool doesExist = false;
            IDecoration decoration = null;
            foreach (Decoration decorationVal in decorations.Models)
            {
                if (decorationVal.GetType().Name == decorationType)
                {
                    doesExist = true;
                    decoration = decorationVal;
                    break;
                }
            }
            if (doesExist)
            {
                IAquarium currAquarium = aquariums.Where(x => x.Name == aquariumName).FirstOrDefault();
                currAquarium.AddDecoration(decoration);
                decorations.Remove(decoration);
                return $"Successfully added {decorationType} to {aquariumName}.";
            }
            return $"There isn't a decoration of type {decorationType}.";


        }
        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            Fish fish = null;
            IAquarium aquarium = aquariums.Where(x => x.Name == aquariumName).FirstOrDefault();
            if (!(fishType == "FreshwaterFish" || fishType == "SaltwaterFish"))
            {
                return "Invalid fish type.";
            }
            if (fishType == "FreshwaterFish" && aquarium.GetType().Name == "FreshwaterAquarium")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish" && aquarium.GetType().Name == "SaltwaterAquarium")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                return "Water not suitable.";
            }
            aquarium.AddFish(fish);
            return $"Successfully added {fishType} to {aquariumName}.";
        }
        public string FeedFish(string aquariumName)
        {
            IAquarium aquarim = aquariums.Where(x => x.Name == aquariumName).FirstOrDefault();
            if (aquarim != null)
            {
                foreach (var fish in aquarim.Fish)
                {
                    fish.Eat();
                }
            }
            return $"Fish fed: {aquarim.Fish.Count}";
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarim = aquariums.Where(x => x.Name == aquariumName).FirstOrDefault();
            decimal valueOfItems = 0;
            if (aquarim != null)
            {
                valueOfItems += aquarim.Fish.Sum(x => x.Price);
                valueOfItems += aquarim.Decorations.Sum(x => x.Price);
            }
            return $"The value of Aquarium {aquariumName} is {valueOfItems}.";

        }
        

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Aquarium aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
