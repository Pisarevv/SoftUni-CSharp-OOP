using BirthdatCelebrations.IO.Interfaces;
using BirthdatCelebrations.Models;
using BirthdatCelebrations.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BirthdatCelebrations.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private Engine()
        {

        }
        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            List<IIdentifiable > identifiables = new List<IIdentifiable>();
            List<IBirthable> birthables = new List<IBirthable>();
            string input = String.Empty;
            while((input = reader.ReadLine()) != "End")
            {
                string[] cmdArgs = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                string command = cmdArgs[0];
                if (command == "Citizen")
                {
                    string name = cmdArgs[1];
                    int age = int.Parse(cmdArgs[2]);
                    string id = cmdArgs[3];
                    string birthDate = cmdArgs[4];
                    IIdentifiable newCitizenIdentifiable = new Citizen(name, age, id, birthDate);
                    IBirthable newCitizenBirthable = new Citizen(name, age, id, birthDate);
                    identifiables.Add(newCitizenIdentifiable);
                    birthables.Add(newCitizenBirthable);

                }
                else if (command == "Robot")
                {
                    string model = cmdArgs[1];
                    string id = cmdArgs[2];
                    IIdentifiable newRobotIdentifiable = new Robot(model,id);
                    identifiables.Add(newRobotIdentifiable);

                }
                else if (command == "Pet")
                {
                    string name = cmdArgs[1];
                    string birthdate = cmdArgs[2];
                    IBirthable newPetBirthable = new Pet (name,birthdate);
                    birthables.Add(newPetBirthable);
                }
            }

            string inputYear = reader.ReadLine();
            List<IBirthable> birthablesWithMatchYear = new List<IBirthable>();
            birthablesWithMatchYear = birthables.FindAll(x => x.BirthDay.EndsWith(inputYear));
            if (birthablesWithMatchYear.Count > 0)
                foreach(IBirthable birthable in birthablesWithMatchYear)
                {
                    writer.WriteLine(birthable.BirthDay);
                }
            


        }
    }
}
