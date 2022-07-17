using Raiding.IO.Interfaces;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly List<BaseHero> heroesList;

        public Engine()
        {
            heroesList = new List<BaseHero>();
        }
        public Engine(IReader reader, IWriter writer, List<BaseHero> heroesList):this()
        {
            this.reader = reader;
            this.writer = writer;
            this.heroesList = heroesList;
        }
        public void Start()
        {
            int bossHealth = int.Parse(reader.ReadLine());
            int sumDamage = 0;
            foreach(BaseHero hero in heroesList)
            {
                writer.WriteLine(hero.CastAbility());
                sumDamage += hero.Power;
            }
            if (sumDamage >= bossHealth && heroesList.Count > 0)
            {
                writer.WriteLine("Victory!");
            }
            else
            {
                writer.WriteLine("Defeat...");
            }
        }


    }
}
