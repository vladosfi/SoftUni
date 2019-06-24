using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        private List<Astronaut> data;

        public SpaceStation(string name, int capacity)
        {
            data = new List<Astronaut>();
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.data.Count();


        public void Add(Astronaut astronaut)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            bool result = false;

            Astronaut astronautToRemove = this.data.Where(a => a.Name == name).FirstOrDefault();

            if (astronautToRemove != null)
            {   
                this.data.Remove(astronautToRemove);
                result = true;
            }

            return result;
        }

        public Astronaut GetOldestAstronaut()
        {
            Astronaut oldestAstronaut = this.data.OrderByDescending(a => a.Age).FirstOrDefault();

            return oldestAstronaut;
        }

        public Astronaut GetAstronaut(string name)
        {
            return this.data.Where(a => a.Name == name).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder reportData = new StringBuilder();
            reportData.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (var astronaut in this.data)
            {
                reportData.AppendLine($"{astronaut}");
            }

            return reportData.ToString().TrimEnd();
        }
    }
}
