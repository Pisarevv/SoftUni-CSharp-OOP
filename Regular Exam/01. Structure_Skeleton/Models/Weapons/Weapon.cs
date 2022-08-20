using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private double price;
        protected int destructionLevel;
        public Weapon(int destructionLevel, double price)
        {
            this.DestructionLevel = destructionLevel;
            this.Price = price;
        }
        public double Price
        {
            get => this.price;
            private set
            {
                this.price = value;
            }
        }

        public virtual int DestructionLevel
        {
            get =>this.destructionLevel;
            private set
            {
                if(value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.TooLowDestructionLevel);
                }
                if(value > 10)
                {
                    throw new ArgumentException(ExceptionMessages.TooHighDestructionLevel);
                }
                this.destructionLevel = value;
            }
        }
    }
}
