using Raiding.Factories.Interfaces;
using Raiding.Models;
using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace Raiding.Factories
{
    public class HeroFactory : IHeroFactory
    {
        public BaseHero CreateHero(string name, string type)
        {
            BaseHero hero = null;
            Assembly assembly = Assembly.GetCallingAssembly();         
            Type typeClass = assembly.GetTypes().Where(x => x.Name == type).FirstOrDefault();
            typeClass.GetProperty("name").SetValue(typeClass, name);
            object instance = Activator.CreateInstance(typeClass);

            

            /*if (type == "Paladin")
            {
                hero = new Paladin(name);
            }
            else if (type == "Druid")
            {
                hero = new Druid(name);
            }
            else if (type == "Rogue")
            {
                hero = new Rogue(name);
            }
            else if (type == "Warrior")
            {
                hero = new Warrior(name);
            }
            else
            {
                throw new ArgumentException("Invalid hero!");
            }*/

            return hero;
        }
    }
}
