using FoodShortage.IO.Interfaces;
using FoodShortage.Models;
using FoodShortage.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FoodShortage.Core
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
            List<IBuyer> buyerList = new List<IBuyer>();
            int n = int.Parse(reader.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = reader.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string name = cmdArgs[0];
                int age = int.Parse(cmdArgs[1]);
                if (cmdArgs.Length == 3)
                {
                    string group = cmdArgs[2];
                    IBuyer buyer = new Rebel(name, age, group);
                    buyerList.Add(buyer);
                }
                else if (cmdArgs.Length == 4)
                {
                    string id = cmdArgs[2];
                    string birthday = cmdArgs[3];
                    IBuyer buyer = new Citizen(name, age, id, birthday);
                    buyerList.Add(buyer);
                }
            }
            string input = String.Empty;
            while((input = reader.ReadLine()) != "End")
            {
                if(buyerList.Any(x => x.Name == input))
                {
                    IBuyer buyer = buyerList.FirstOrDefault(x => x.Name == input);
                    buyer.BuyFood();
                }
            }
            writer.WriteLine(buyerList.Sum(x => x.Food).ToString());

            
            


        }
    }
}
