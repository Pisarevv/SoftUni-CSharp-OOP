using Raiding.Core;
using Raiding.Factories;
using Raiding.Factories.Interfaces;
using Raiding.IO;
using Raiding.IO.Interfaces;
using Raiding.Models;
using System;
using System.Collections.Generic;

namespace Raiding
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IHeroFactory heroFactory = new HeroFactory();
            List<BaseHero> heroesList = new List<BaseHero>();
            
            int n = int.Parse(reader.ReadLine());
            for (int i = 0; i < n;)
            {
                try
                {
                    
                    string name = reader.ReadLine();
                    string type = reader.ReadLine();
                    if (!string.IsNullOrEmpty(name))
                    {
                        BaseHero newhero = heroFactory.CreateHero(name, type);
                        heroesList.Add(newhero);
                        i++;
                    }
                    
                }
                catch(ArgumentException ae)
                {
                    writer.WriteLine(ae.Message);
                }
            }
            IEngine Engine = new Engine(reader,writer,heroesList);
            Engine.Start();


        }
    }
}
