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
using AquaShop.Utilities.Messages;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private readonly DecorationRepository decorations;
        private readonly ICollection<IAquarium> aquariums;
        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new HashSet<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;           
            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            this.aquariums.Add(aquarium);
            return String.Format(OutputMessages.SuccessfullyAdded,aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;
            if(decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
            decorations.Add(decoration);
            return String.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }
        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = decorations.FindByType(decorationType);
            if(decoration == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }
            IAquarium currAquarium = aquariums.Where(x => x.Name == aquariumName).FirstOrDefault();
            if (currAquarium != null)
            {
               currAquarium.AddDecoration(decoration);
               decorations.Remove(decoration);
               return String.Format(OutputMessages.EntityAddedToAquarium, decorationType,aquariumName);
            }
            return null;
                
        }
        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            Fish fish = null;
            IAquarium aquarium = aquariums.Where(x => x.Name == aquariumName).FirstOrDefault();
            if (!(fishType == "FreshwaterFish" || fishType == "SaltwaterFish"))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidFishType, fishType));
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
                return String.Format(OutputMessages.UnsuitableWater);
            }
            aquarium.AddFish(fish);
            return String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }
        public string FeedFish(string aquariumName)
        {
            IAquarium aquarim = aquariums.Where(x => x.Name == aquariumName).FirstOrDefault();
            if (aquarim != null)
            {
                aquarim.Feed();
                return String.Format(OutputMessages.FishFed,aquarim.Fish.Count());
            }

            return null;
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarim = aquariums.Where(x => x.Name == aquariumName).FirstOrDefault();
            decimal valueOfItems = 0;
            if (aquarim != null)
            {
                valueOfItems = aquarim.Fish.Sum(x => x.Price) + aquarim.Decorations.Sum(x => x.Price);
                
            }
            return $"The value of Aquarium {aquariumName} is {valueOfItems:F2}.";

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
