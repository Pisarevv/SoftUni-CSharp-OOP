using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        private const int InitlialStamina = 60;
        public Boxer(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, numberOfMedals, InitlialStamina)
        {
        }

        public override void Exercise()
        {
            this.Stamina += 15;
        }
    }
}
