using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        private const int InitialWeightlifetStamina = 50;
        public Weightlifter(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, numberOfMedals, InitialWeightlifetStamina)
        {
        }

        public override void Exercise()
        {
            this.Stamina += 10;
        }
    }
}
