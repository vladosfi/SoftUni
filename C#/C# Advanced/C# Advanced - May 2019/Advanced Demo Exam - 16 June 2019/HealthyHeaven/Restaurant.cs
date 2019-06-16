using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Restaurant
    {
        public string Name { get; private set; }
        private List<Salad> data;

        public Restaurant(string name)
        {
            this.Name = name;
            this.data = new List<Salad>();
        }

        public void Add(Salad salad)
        {
            data.Add(salad);
        }

        public bool Buy(string name)
        {
            Salad saladToRemove = data.Where(s => s.Name == name).FirstOrDefault();

            if (saladToRemove != null)
            {
                data.Remove(saladToRemove);
                return true;
            }
            return false;
        }

        public Salad GetHealthiestSalad()
        {
            Salad healthiestSalad = data.OrderBy(n => n.GetTotalCalories()).FirstOrDefault();

            return healthiestSalad;
        }

        public string GenerateMenu()
        {
            StringBuilder menu = new StringBuilder();
            menu.AppendLine($"{this.Name} have {this.data.Count} salads:");

            foreach (var salad in this.data)
            {
                menu.AppendLine(salad.ToString());
            }

            return menu.ToString().TrimEnd();
        }

    }
}
