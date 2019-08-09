namespace MXGP.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using MXGP.Core.Contracts;
    using MXGP.Models.Motorcycles;
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Models.Races;
    using MXGP.Models.Races.Contracts;
    using MXGP.Models.Riders;
    using MXGP.Models.Riders.Contracts;
    using MXGP.Repositories;
    using MXGP.Utilities.Messages;

    public class ChampionshipController : IChampionshipController
    {
        private readonly RiderRepository riderRepo;
        private readonly MotorcycleRepository motorcycleRepo;
        private readonly RaceRepository raceRepo;

        public ChampionshipController()
        {
            this.riderRepo = new RiderRepository();
            this.motorcycleRepo = new MotorcycleRepository();
            this.raceRepo = new RaceRepository();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            IRider rider = this.riderRepo.GetByName(riderName);

            if (rider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            IMotorcycle motorcycle = this.motorcycleRepo.GetByName(motorcycleModel);

            if (motorcycle == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }

            rider.AddMotorcycle(motorcycle);

            return string.Format(OutputMessages.MotorcycleAdded, riderName,motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            IRace race = this.raceRepo.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            IRider rider = this.riderRepo.GetByName(riderName);

            if (rider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            race.AddRider(rider);

            return string.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            IMotorcycle motorcycle = motorcycleRepo.GetByName(model);

            if (this.motorcycleRepo.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MotorcycleExists, model));
            }

            if (type == "Power")
            {
                motorcycle = new PowerMotorcycle(model, horsePower);
            }
            else if (type == "Speed")
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);
            }

            this.motorcycleRepo.Add(motorcycle);

            return string.Format(OutputMessages.MotorcycleCreated, motorcycle.GetType().Name, model);
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = this.raceRepo.GetByName(name);

            if (race != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            race = new Race(name,laps);

            this.raceRepo.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string CreateRider(string riderName)
        {
            if (this.riderRepo.GetByName(riderName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderExists, riderName));
            }

            this.riderRepo.Add(new Rider(riderName));

            return string.Format(OutputMessages.RiderCreated, riderName);
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepo.GetByName(raceName);

            if (race is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound,raceName));
            }

            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName,3));
            }

            var winners = race.Riders.OrderByDescending(r => r.Motorcycle.CalculateRacePoints(race.Laps)).Take(3).ToList();            

            StringBuilder result = new StringBuilder();
            result.AppendLine(string.Format(OutputMessages.RiderFirstPosition, winners[0].Name, raceName));
            result.AppendLine(string.Format(OutputMessages.RiderSecondPosition, winners[1].Name, raceName));
            result.AppendLine(string.Format(OutputMessages.RiderThirdPosition, winners[2].Name, raceName));

            this.raceRepo.Remove(race);

            return result.ToString().TrimEnd();
        }
    }
}
