using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.PetClinic
{
    class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Clinic> clinics = new List<Clinic>();
            List<Pet> pets = new List<Pet>();

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0].ToLower();

                if (command == "create")
                {
                    if (tokens[1].ToLower() == "pet")
                    {
                        string petName = tokens[2];
                        int petAge = int.Parse(tokens[3]);
                        string petKind = tokens[4];
                        Pet pet = new Pet(petName, petAge, petKind);
                        pets.Add(pet);
                    }
                    else if (tokens[1].ToLower() == "clinic")
                    {
                        string clinicName = tokens[2];
                        int roomsCount = int.Parse(tokens[3]);

                        try
                        {
                            Clinic clinic = new Clinic(clinicName, roomsCount);
                            clinics.Add(clinic);
                        }
                        catch (ArgumentException message)
                        {
                            result.AppendLine(message.Message);
                            //Console.WriteLine(message.Message);
                        }
                    }
                }
                else if (command == "add")
                {
                    string petName = tokens[1];
                    string clinicName = tokens[2];

                    Clinic clinic = clinics.Where(x => x.Name == clinicName).FirstOrDefault();
                    if (clinic != null)
                    {
                        int petIndex = pets.FindIndex(p => p.Name == petName);
                        if (petIndex != -1)
                        {
                            Pet pet = pets[petIndex];
                            pets.RemoveAt(petIndex);
                            result.AppendLine(clinic.Add(pet).ToString());
                        }
                        //Console.WriteLine(clinic.Add(pet));
                    }
                }
                else if (command == "release")
                {
                    string clinicName = tokens[1];
                    Clinic clinic = clinics.Where(x => x.Name == clinicName).FirstOrDefault();
                    if (clinic != null)
                    {
                        result.AppendLine(clinic.Release().ToString());
                        //Console.WriteLine(clinic.Release());
                    }
                }
                else if (command == "hasemptyrooms")
                {
                    string clinicName = tokens[1];
                    Clinic clinic = clinics.Where(x => x.Name == clinicName).FirstOrDefault();
                    if (clinic != null)
                    {
                        result.AppendLine(clinic.HasEmptyRooms().ToString());
                        //Console.WriteLine(clinic.HasEmptyRooms());
                    }
                }
                else if (command == "print")
                {
                    string clinicName = tokens[1];
                    Clinic clinic = clinics.Where(x => x.Name == clinicName).FirstOrDefault();

                    if (clinic == null)
                    {
                        continue;
                    }

                    if (tokens.Length == 2)
                    {
                        foreach (var room in clinic)
                        {
                            if (room != null)
                            {
                                //Console.WriteLine(room.Pet);
                                result.AppendLine(room.ToString());
                            }
                            else
                            {
                                //Console.WriteLine("Room empty");
                                result.AppendLine("Room empty");
                            }
                        }
                    }
                    else if (tokens.Length == 3)
                    {
                        int roomNumber = int.Parse(tokens[2]);

                        if (roomNumber < 1 || roomNumber > clinic.Rooms.Length)
                        {
                            continue;
                        }

                        var roomContent = clinic.Rooms[roomNumber - 1];

                        if (roomContent != null)
                        {
                            result.AppendLine(roomContent.ToString());
                        }
                        else
                        {
                            result.AppendLine("Room empty");
                        }
                        
                        //Console.WriteLine(clinic.Rooms[roomNumber].Pet);
                    }
                }
            }

            Console.Write(result);
        }
    }
}

