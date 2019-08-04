using System;
using System.Collections.Generic;
using System.Linq;

using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Utilities.Messages;

namespace MXGP.Models.Races
{
    public class Race : IRace
    {
        private string name;
        private int laps;
        private readonly List<IRider> riders;

        public Race()
        {
            this.riders = new List<IRider>();
        }

        public Race(string name, int laps)
            :this()
        {
            this.Name = name;
            this.Laps = laps;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, 5));
                }

                this.name = value;
            }
        }

        public int Laps
        {
            get
            {
                return this.laps;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, 1));
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IRider> Riders => this.riders;

        public void AddRider(IRider rider)
        {
            if (rider == null)
            {
                throw new ArgumentNullException(ExceptionMessages.RiderInvalid);
            }
            else if (rider.CanParticipate == false)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderNotParticipate, rider.Name));
            }
            else if (this.riders.Any(r=>r.Name == rider.Name))
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.RiderAlreadyAdded, rider.Name, this.name));
            }

            this.riders.Add(rider);
        }
    }
}
