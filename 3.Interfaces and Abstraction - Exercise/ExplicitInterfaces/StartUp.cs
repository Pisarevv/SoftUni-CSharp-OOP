using ExplicitInterfaces.Models;
using ExplicitInterfaces.Models.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ExplicitInterfaces
{
    internal class StartUp
    {
        static void Main()
        {
            List<IPerson> citizensPerson = new List<IPerson>();
            List<IResident> citizensResident = new List<IResident>();
            string input = string.Empty;
            while((input = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                string name = cmdArgs[0];
                string country = cmdArgs[1];
                int age = int.Parse(cmdArgs[2]);
                Citizen citizen = new Citizen(name, country, age);
                citizensPerson.Add(citizen);
                citizensResident.Add(citizen);
            }
            for (int i = 0; i < citizensPerson.Count; i++)
            {
                IPerson currentPerson = citizensPerson[i];
                IResident currentResident = citizensResident[i];
                Console.WriteLine(currentPerson.GetName());
                Console.WriteLine(currentResident.GetName());
                


            }
        }
    }
}
