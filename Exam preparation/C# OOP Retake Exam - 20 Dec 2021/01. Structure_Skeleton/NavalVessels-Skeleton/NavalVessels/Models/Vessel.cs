using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
         private string name;
         private ICaptain captain;
         private double armorThickness;
         private double mainWeaponCaliber;
         private double speed;
         private ICollection<string> targets = new List<string>();

         
             
         
         public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
         {
             this.Name = name;
             this.MainWeaponCaliber = mainWeaponCaliber;
             this.Speed = speed;
             this.ArmorThickness = armorThickness;            
        }

         public string Name
         {
             get 
             {
                 return name; 
             }
             private set
             {
                 if (string.IsNullOrWhiteSpace(value))
                 {
                     throw new ArgumentNullException("Vessel name cannot be null or empty.");
                 }
                 name = value;
             }
         }

         public ICaptain Captain
         {
             get
             {
                 return captain;
             }
              set
             {
                 if(value == null)
                 {
                     throw new NullReferenceException("Captain cannot be null.");
                 }
                 captain = value;
             }
         }
         public double ArmorThickness
         {
             get
             {
                 return armorThickness;
             }
             set
             {
                 armorThickness = value;
             }
         }

         public double MainWeaponCaliber
         {
             get
             {
                 return this.mainWeaponCaliber;
             }
            protected set
            {
                 this.mainWeaponCaliber = value;
             }
         }

         public double Speed
         {
             get
             {
                 return this.speed;
             }
            protected set
            {
                 this.speed = value;
             }
         }

         public ICollection<string> Targets => this.targets;

         public void Attack(IVessel target)
         {
             if(target == null)
             {
                 throw new NullReferenceException("Target cannot be null.");
             }
             target.ArmorThickness -= this.MainWeaponCaliber;
             targets.Add(target.Name);
             if (target.ArmorThickness < 0)
             {
                 target.ArmorThickness = 0;
             }
         }

        public abstract void RepairVessel();
         

         public override string ToString()
         {
             StringBuilder sb = new StringBuilder();
             sb.AppendLine($"- {this.Name}")
                 .AppendLine($" *Type: {this.GetType().Name}")
                 .AppendLine($" *Armor thickness: {this.ArmorThickness}")
                 .AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}")
                 .AppendLine($" *Speed: {this.Speed} knots").
                 Append($" *Targets: {(targets.Count > 0 ? (string.Join(", ", targets)) : "None")}");
             return sb.ToString().TrimEnd();
         }
       
    }
}
