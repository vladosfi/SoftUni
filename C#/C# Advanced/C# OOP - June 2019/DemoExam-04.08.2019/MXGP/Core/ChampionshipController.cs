using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Races;
using MXGP.Models.Riders;
using MXGP.Utilities.Messages;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private List<Rider> riders;
        private List<Motorcycle> motorcycles;
        private List<Race> races;

        public ChampionshipController()
        {
            this.riders = new List<Rider>();
            this.motorcycles = new List<Motorcycle>();
            this.races = new List<Race>();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            Rider rider = riders.Where(r => r.Name == riderName).First();

            Motorcycle motorcycle = motorcycles.Where(m => m.Model == motorcycleModel).First();

            if (rider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            if (motorcycle == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }

            rider.AddMotorcycle(motorcycle);

            return string.Format(Utilities.Messages.OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            Rider rider = riders.Where(r => r.Name == riderName).First();
            Race race = races.Where(m => m.Name == raceName).First();

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (rider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }


            race.AddRider(rider);

            return string.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            Motorcycle motorcycle = null;

            if (type == "Power")
            {
                motorcycle = new PowerMotorcycle(model, horsePower);
            }
            else if (type == "Speed")
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);
            }

            if (motorcycles.Any(r => r.Model == model))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MotorcycleExists, model));
            }

            motorcycles.Add(motorcycle);

            return string.Format(OutputMessages.MotorcycleCreated, motorcycle.GetType().Name, model);
        }

        public string CreateRace(string name, int laps)
        {
            Race race = new Race();
            race.Name = name;
            race.Laps = laps;

            if (races.Any(r => r.Name == name))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            races.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string CreateRider(string riderName)
        {
            if (riders.Any(r => r.Name == riderName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderExists, riderName));
            }

            Rider rider = new Rider(riderName);

            riders.Add(rider);

            return string.Format(OutputMessages.RiderCreated, riderName);
        }

        public string StartRace(string raceName)
        {
            Race race = races.Where(m => m.Name == raceName).First();

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            races.Remove(race);

            List<Rider> winners = riders.OrderByDescending(r => r.Motorcycle.CalculateRacePoints(race.Laps)).Take(3).ToList();

            StringBuilder result = new StringBuilder();
            
            result.AppendLine(string.Format(OutputMessages.RiderFirstPosition, winners[0].Name, race.Name));
            result.AppendLine(string.Format(OutputMessages.RiderSecondPosition, winners[1].Name, race.Name));
            result.AppendLine(string.Format(OutputMessages.RiderThirdPosition, winners[2].Name, race.Name));

            return result.ToString().TrimEnd();
        }
    }
}
