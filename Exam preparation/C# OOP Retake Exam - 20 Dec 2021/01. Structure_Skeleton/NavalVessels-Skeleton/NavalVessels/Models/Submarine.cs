using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double InitialSubmarineArmorThickness = 200;
        private bool submergeMode;
        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, InitialSubmarineArmorThickness)
        {
            this.SubmergeMode = false;
        }

        public bool SubmergeMode
        {
            get { return submergeMode; }
            private set { submergeMode = value; }
        }

        public override void RepairVessel()
        {
            if(ArmorThickness < InitialSubmarineArmorThickness)
                ArmorThickness = InitialSubmarineArmorThickness;
        }
        public void ToggleSubmergeMode()
        {
            if (this.submergeMode == false)
            {
                this.submergeMode = true;
                MainWeaponCaliber += 40;
                Speed -= 4;
            }
            else if (this.submergeMode == true)
            {
                this.submergeMode = false;
                MainWeaponCaliber -= 40;
                Speed += 4;
            }
        }
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $" *Submerge mode: {(submergeMode == true ? "ON" : "OFF")}".TrimEnd();
        }
    }
}
