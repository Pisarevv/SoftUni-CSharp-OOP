using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private ICollection<IGym> gyms;
        public Controller()
        {
            this.equipment = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }
        public string AddGym(string gymType, string gymName)
        {
            if(gymType != "BoxingGym" && gymType != "WeightliftingGym")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }
            if(gymType == "BoxingGym")
            {
                IGym newGym = new BoxingGym(gymName);
                gyms.Add(newGym);
            }
            else if (gymType == "WeightliftingGym")
            {
                IGym newGym = new WeightliftingGym(gymName);
                gyms.Add(newGym);
            }
            return String.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string AddEquipment(string equipmentType)
        {
            if(equipmentType != "BoxingGloves" && equipmentType != "Kettlebell")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }
            IEquipment newEquipment = null;
            if (equipmentType == "Kettlebell")
            {
                newEquipment = new Kettlebell();
            }
            if (equipmentType == "BoxingGloves")
            {
                newEquipment = new BoxingGloves();
            }
            equipment.Add(newEquipment);
            return String.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            if(!equipment.Models.Any(x => x.GetType().Name == equipmentType))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }
            IEquipment transferEquipment = equipment.Models.First(x => x.GetType().Name == equipmentType);
            IGym gymToTransfer = gyms.FirstOrDefault(x => x.Name == gymName);
            if (gymToTransfer != null)
            {
                gymToTransfer.AddEquipment(transferEquipment);
                equipment.Remove(transferEquipment);
                return String.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
            }
            return null;
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            if (athleteType != "Boxer" && athleteType != "Weightlifter")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }
            IAthlete newAthlete = null;
            IGym gymToTrain = gyms.FirstOrDefault(x => x.Name == gymName);
            if(gymToTrain != null)
            {
                if (athleteType == "Boxer")
                {
                    if (gymToTrain.GetType().Name != "BoxingGym")
                    {
                        return OutputMessages.InappropriateGym;
                    }
                    newAthlete = new Boxer(athleteName, motivation, numberOfMedals);
                    gymToTrain.AddAthlete(newAthlete);                    
                }
                else if (athleteType == "Weightlifter")
                {
                    if (gymToTrain.GetType().Name != "WeightliftingGym")
                    {
                        return OutputMessages.InappropriateGym;
                    }
                    newAthlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                    gymToTrain.AddAthlete(newAthlete);
                }
                return String.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
            }            
            return "Invalid Gym";
            
        }

        public string TrainAthletes(string gymName)
        {
            IGym gymToTrainAthletes = gyms.FirstOrDefault(x => x.Name == gymName);
            if(gymToTrainAthletes != null)
            {
                foreach(IAthlete athletes in gymToTrainAthletes.Athletes)
                {
                    athletes.Exercise();
                }
                int trainedAthletes = gymToTrainAthletes.Athletes.Count;
                return String.Format(OutputMessages.AthleteExercise, trainedAthletes);
            }
            return "Invalid gym";
        }
        public string EquipmentWeight(string gymName)
        {
            IGym gymToTrainAthletes = gyms.FirstOrDefault(x => x.Name == gymName);
            if (gymToTrainAthletes != null)
            {
                double equipmentWeight = gymToTrainAthletes.EquipmentWeight;
                return String.Format(OutputMessages.EquipmentTotalWeight, gymName, equipmentWeight);
            }
            return "Invalid gymName";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach(IGym gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }
            return sb.ToString().TrimEnd();
        }

        
    }
}
