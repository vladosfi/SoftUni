using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceStation.Core.Contracts;
using SpaceStation.Core.Factory;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private readonly AstronautFactory astronautFactory;
        private readonly PlanetFactory planetFactory;
        private readonly IRepository<IAstronaut> astronautRepository;
        private readonly IRepository<IPlanet> planetRepository;
        private int exploredPlanetsCount;

        public Controller()
        {
            this.astronautFactory = new AstronautFactory();
            this.planetFactory = new PlanetFactory();

            this.astronautRepository = new AstronautRepository();
            this.planetRepository = new PlanetRepository();
            this.exploredPlanetsCount = 0;
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = this.astronautFactory.CreateAstronaut(type, astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            this.astronautRepository.Add(astronaut);

            return string.Format(OutputMessages.AstronautAdded, astronaut.GetType().Name, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = this.planetFactory.CreatePlanet(planetName, items);
            this.planetRepository.Add(planet);
            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> suitableAstronauts = astronautRepository.Models.Where(a => a.Oxygen > 60).ToList();

            if (suitableAstronauts.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            IMission mission = new Mission();
            IPlanet planet = this.planetRepository.FindByName(planetName);
            mission.Explore(planet, suitableAstronauts);
            this.exploredPlanetsCount++;

            return string.Format(OutputMessages.PlanetExplored, planetName,suitableAstronauts.Select(a=>a.CanBreath == false).Count());
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();

            report.AppendLine($"{exploredPlanetsCount} planets were explored!");
            report.AppendLine("Astronauts info:");

            foreach (var astronaut in astronautRepository.Models)
            {                
                report.AppendLine($"Name: {astronaut.Name}");
                report.AppendLine($"Oxygen: {astronaut.Oxygen}");

                report.Append("Bag items: ");
                if (astronaut.Bag.Items == 0)
                {
                    report.AppendLine("none");
                }
                else
                {
                    report.AppendLine(string.Join(", ", astronaut.Bag.Items));
                }
            }

            return report.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = this.astronautRepository.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            this.astronautRepository.Remove(astronaut);

            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
