using BorderControl.IO.Interfaces;
using BorderControl.Models;
using BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BorderControl.Core
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
            string input = String.Empty;
            while((input = reader.ReadLine()) != "End")
            {
                string[] cmdArgs = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                IIdentifiable identifiable;
                if (cmdArgs.Length == 2)
                {
                    string model = cmdArgs[0];
                    string id = cmdArgs[1];
                    identifiable = new Robot(model, id);
                    identifiables.Add(identifiable);
                }
                else if(cmdArgs.Length == 3)
                {
                    string name = cmdArgs[0];
                    int age = int.Parse(cmdArgs[1]);
                    string id = cmdArgs[2];
                    identifiable  = new Citizen(name,age,id);
                    identifiables.Add(identifiable);
                }       
            }
            string fakeIdDigits = reader.ReadLine();
            ICollection<string> fakeIdObjects = new List<string>();
            foreach (IIdentifiable identifiable in identifiables)
            {
                string currentObjectId = identifiable.Id;
                if (currentObjectId.EndsWith(fakeIdDigits))
                {
                    fakeIdObjects.Add(currentObjectId);
                }
            }
            writer.WriteLine(string.Join(Environment.NewLine, fakeIdObjects.ToArray()));

        }
    }
}
