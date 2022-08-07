using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const double InitialArmorThickness = 300;
        private bool sonarMode;

        public bool SonarMode
        {
            get { return sonarMode; }
            private set { sonarMode = value; }
        }
        

        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
            this.SonarMode = false;
        }
        
        public void ToggleSonarMode()
        {
            if(this.sonarMode == false)
            {
                this.sonarMode = true;
                MainWeaponCaliber += 40;
                Speed -= 5;
            }
            else if(this.sonarMode == true)
            {
                this.sonarMode = false;
                MainWeaponCaliber -= 40;
                Speed += 5;
            }
        }
        public override void RepairVessel()
        {
            if(ArmorThickness < InitialArmorThickness)
            ArmorThickness = InitialArmorThickness;
        }
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $" *Sonar mode: {(this.SonarMode == true ? "ON" : "OFF")}".TrimEnd();
        }

    }
}
