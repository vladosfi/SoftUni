using System;
using System.Collections.Generic;
using System.Text;

namespace _08.PetClinic
{
    public class Room
    {
        public Pet Pet { get; set; }

        public Room(Pet pet)
        {
            this.Pet = pet;
        }

        public override string ToString()
        {
            return $"{this.Pet.Name} {this.Pet.Age} {this.Pet.Kind}";
        }
    }
}
