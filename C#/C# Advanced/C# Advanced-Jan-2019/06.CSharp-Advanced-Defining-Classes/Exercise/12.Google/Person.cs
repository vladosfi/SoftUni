using System;
using System.Collections.Generic;
using System.Text;

namespace _12.Google
{
    public class Person
    {
        public string Name { get; set; }
        public Company Company { get; set; }
        public Car Car { get; set; }

        public List<Pokemon> Pokemons { get; set; }
        public List<Parent> Parents { get; set; }
        public List<Child> Children { get; set; }

        public Person(string name)
        {
            this.Name = name;
            Pokemons = new List<Pokemon>();
            Parents = new List<Parent>();
            Children = new List<Child>();
        }

        public void AddCompany(string name, string department, double salary)
        {
            if (this.Company == null)
            {
                this.Company = new Company(name, department, salary);
            }
            else
            {
                Company.Name = name;
                Company.Department = department;
                Company.Salary = salary;
            }
        }

        public void AddCar(string model, int speed)
        {
            if (this.Car == null)
            {
                this.Car = new Car(model, speed);
            }
            else
            {
                Car.Model = model;
                Car.Speed = speed;
            }
        }

        public void AddPokemon(string name, string type)
        {
            this.Pokemons.Add(new Pokemon(name, type));
        }

        public void AddParent(string name, string birthday)
        {
            this.Parents.Add(new Parent(name, birthday));
        }

        public void AddChild(string name, string birthday)
        {
            this.Children.Add(new Child(name, birthday));
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{this.Name}");
            result.AppendLine($"Company:");
            if (this.Company != null)
            {
                result.AppendLine($"{this.Company.ToString()}");
            }
            result.AppendLine($"Car:");
            if (this.Car != null)
            {
                result.AppendLine($"{this.Car.ToString()}");
            }
            result.AppendLine($"Pokemon:");
            if (this.Pokemons.Count > 0)
            {
                foreach (var Pokemon in Pokemons)
                {
                    result.AppendLine($"{Pokemon.ToString()}");
                }
            }
            result.AppendLine($"Parents:");
            if (this.Parents.Count > 0)
            {
                foreach (var Parent in Parents)
                {
                    result.AppendLine($"{Parent.ToString()}");
                }
            }
            result.AppendLine($"Children:");
            if (this.Children.Count > 0)
            {
                foreach (var Child in Children)
                {
                    result.AppendLine($"{Child.ToString()}");
                }
            }

            return result.ToString();
        }
    }
}
