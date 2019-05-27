using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Hospital
{
    class HospitalTask
    {
        static void Main()
        {
            var departments = new Dictionary<string, string[][]>();
            var doctors = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input.ToLower() != "output")
            {
                string[] tokens = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string department = tokens[0];
                string doctor = tokens[1] + " " + tokens[2];
                string patient = tokens[3];

                if (!departments.ContainsKey(department))
                {
                    departments.Add(department, new string[20][]);
                }

                for (int room = 0; room < 20; room++)
                {
                    if (departments[department][room] == null)
                    {
                        departments[department][room] = new string[3];
                    }

                    if (departments[department][room].Any(b => b == null))
                    {
                        for (int bed = 0; bed < 3; bed++)
                        {
                            if (departments[department][room][bed] == null)
                            {
                                departments[department][room][bed] = patient;
                                break;
                            }
                        }
                        break;
                    }
                }

                if (!doctors.ContainsKey(doctor))
                {
                    doctors.Add(doctor, new List<string>());
                }

                doctors[doctor].Add(patient);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input.ToLower() != "end")
            {
                input = input.Trim(); 

                if (departments.ContainsKey(input))
                {
                    foreach (var room in departments[input].Where(p => p != null))
                    {
                        foreach (var patient in room.Where(p=>p != null))
                        {
                            Console.WriteLine(patient);
                        }
                    }
                }
                else if (doctors.ContainsKey(input))
                {
                    string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string doctor = tokens[0] + " " + tokens[1];
                    
                    foreach (var patient in doctors[doctor].OrderBy(p => p))
                    {
                        Console.WriteLine(patient);
                    }
                }
                else
                {
                    string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string department = tokens[0];
                    int room = int.Parse(tokens[1]) - 1;

                    if (departments[department][room] != null)
                    {
                        foreach (var bed in departments[department][room].Where(p => p != null).OrderBy(p => p))
                        {
                            Console.WriteLine(bed);
                        }
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
