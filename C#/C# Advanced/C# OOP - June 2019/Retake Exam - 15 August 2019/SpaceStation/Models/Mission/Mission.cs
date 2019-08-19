using System.Collections.Generic;
using System.Linq;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts.Where(a => a.CanBreath == true))
            {

                
                for (int i = 0; i < planet.Items.Count; i++)
                {
                    if (astronaut.CanBreath == false)
                    {
                        break;
                    }

                    astronaut.Breath();
                    //var planetItems = planet.Items.ToArray();
                    //astronaut.Bag.Items.Add(planetItems[i]);
                    //planet.Items.Remove(planetItems[i]);
                    //i--;
                }
            }
        }
    }
}
