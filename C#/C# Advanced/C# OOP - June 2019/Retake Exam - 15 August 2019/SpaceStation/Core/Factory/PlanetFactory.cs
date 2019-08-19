using SpaceStation.Models.Planets;

namespace SpaceStation.Core.Factory
{
    public class PlanetFactory
    {
        public IPlanet CreatePlanet(string planetName , params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }
            
            return planet;
        }
    }
}
