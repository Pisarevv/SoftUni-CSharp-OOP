using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private IRepository<IHero> heroes;
        private IRepository<IWeapon> weapons;
        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }
        public string CreateHero(string type, string name, int health, int armour)
        {
            if(heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }
            IHero hero = null;
            if(type == "Knight")
            {
                hero = new Knight(name, health, armour);
            }
            else if (type == "Barbarian")
            {
                hero = new Barbarian(name, health, armour);
            }
            else
            {
                throw new InvalidOperationException("Invalid hero type.");
            }
            heroes.Add(hero);
            return $"Successfully added {(hero.GetType().Name == "Knight" ? "Sir" : "Barbarian")} {name} to the collection.";
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (weapons.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }
            IWeapon weapon = null;
            if (type == "Claymore")
            {
                weapon = new Claymore(name, durability);
            }
            else if (type == "Mace")
            {
                weapon = new Mace(name, durability);
            }
            else
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }
            weapons.Add(weapon);
            return $"A {type.ToLower()} {name} is added to the collection.";
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = heroes.FindByName(heroName);
            if(hero == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }
            IWeapon weapon = weapons.FindByName(weaponName);
            if(weapon == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }
            if(hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }
            hero.AddWeapon(weapon);
            weapons.Remove(weapon);
            return $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";
        }

        public string StartBattle()
        {
            IMap map = new Map();
            ICollection<IHero> heroesThatCanParticipateInFight = heroes.Models.Where(x => x.Weapon != null && x.IsAlive).ToList();
            return map.Fight(heroesThatCanParticipateInFight);
        }
        public string HeroReport()
        {
            ICollection<IHero> orderedHeroes =
                heroes.Models.OrderBy(x => x.GetType().Name).ThenByDescending(x => x.Health).ThenBy(x => x.Name).ToList();
            StringBuilder sb = new StringBuilder();
            foreach(IHero hero in orderedHeroes)
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}")
                    .AppendLine($"--Health: {hero.Health}")
                    .AppendLine($"--Armour: {hero.Armour}")
                    .AppendLine($"--Weapon: {(hero.Weapon != null ? hero.Weapon.Name : "Unarmed")}");

            }
            return sb.ToString().Trim();
        }

       
    }
}
