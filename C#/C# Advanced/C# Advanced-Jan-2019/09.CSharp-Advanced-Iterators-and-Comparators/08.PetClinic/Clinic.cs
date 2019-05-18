namespace _08.PetClinic
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Clinic : IEnumerable<Room>
    {
        public Clinic(string name, int roomsCount)
        {
            if (roomsCount % 2 == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }

            this.RoomsCount = roomsCount;
            this.Name = name;
            this.Rooms = new Room[roomsCount];
        }

        public string Name { get; set; }
        public int RoomsCount { get; set; }
        public Room[] Rooms { get; set; }

        public bool HasEmptyRooms()
        {
            foreach (var room in this.Rooms)
            {
                if (room == null)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Release()
        {
            int currentRoom = this.RoomsCount / 2;
            int upLimit = this.RoomsCount;

            for (int i = currentRoom; i < upLimit; i++)
            {
                if (this.Rooms[i] != null)
                {
                    this.Rooms[i] = null;
                    return true;
                }

                if (i + 1 == Rooms.Length && upLimit != 1)
                {
                    i = -1;
                    upLimit++;
                }
            }

            return false;
        }

        public bool Add(Pet pet)
        {
            int currentRoom = this.Rooms.Length / 2; ;
            bool moveUp = true;
            int currentStep = -1;
            
            for (int i = 0; i < this.Rooms.Length; i++)
            {
                currentStep++;
                moveUp = !moveUp;
                currentRoom = moveUp ? 
                    currentRoom - currentStep :
                    currentRoom + currentStep;

                if (this.Rooms[currentRoom] == null)
                {
                    this.Rooms[currentRoom] = new Room(pet);
                    return true;
                }                
            }

            return false;
        }
        
        public IEnumerator<Room> GetEnumerator()
        {
            for (int i = 0; i < this.Rooms.Length; i++)
            {
                yield return Rooms[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
