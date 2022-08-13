using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public Mission()
        {

        }
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach(IAstronaut astronaut in astronauts)
            {
                while(astronaut.CanBreath)
                {
                    string item = planet.Items.First();
                    astronaut.Bag.Items.Add(item);
                    astronaut.Breath();
                    planet.Items.Remove(item);
                    if (planet.Items.Count == 0)
                        return;
                }
            }
        }
    }
}
