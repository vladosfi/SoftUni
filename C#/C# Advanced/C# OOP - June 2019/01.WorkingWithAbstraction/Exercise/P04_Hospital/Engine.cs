using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Engine
    {
        private Dictionary<string, List<string>> doctors;
        private Dictionary<string, List<List<string>>> departments;
        private readonly string separator = Environment.NewLine;

        public Engine()
        {
            doctors = new Dictionary<string, List<string>>();
            departments = new Dictionary<string, List<List<string>>>();
        }

        public void Start()
        {
            string command = Console.ReadLine();

            while (command != "Output")
            {
                string[] tokens = command.Split();

                var department = tokens[0];
                var firstName = tokens[1];
                var surName = tokens[2];
                var patient = tokens[3];

                var fullName = firstName + surName;

                AddDoctor(fullName);
                AddDepartment(department);

                bool freeRoom = departments[department]
                    .SelectMany(x => x)
                    .Count() < 60;

                if (freeRoom)
                {
                    AddPatientToRoom(department, patient, fullName);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();
                string department = args[0];

                if (args.Length == 1)
                {
                    PrintPatientsInDepartment(department);
                }
                else if (args.Length == 2)
                {
                    bool isRoom = int.TryParse(args[1], out int room);

                    if (isRoom)
                    {
                        PrintPatientsByDepartmentRoom(department, room);
                    }
                    else
                    {
                        var fullname = args[0] + args[1];

                        PrintPatientsByDoctor(fullname);
                    }
                }

                command = Console.ReadLine();
            }
        }

        private void PrintPatientsByDoctor(string fullname)
        {
            var patientsByDoctor = doctors[fullname]
                                    .OrderBy(x => x);

            Console.WriteLine(string.Join(separator, patientsByDoctor));
        }

        private void PrintPatientsByDepartmentRoom(string department, int room)
        {
            var patientsByDepartmentRoom = departments[department][room - 1]
                                    .OrderBy(x => x);

            Console.WriteLine(string.Join(separator, patientsByDepartmentRoom));
        }

        private void PrintPatientsInDepartment(string department)
        {
            var allPatientsInDepartment = departments[department]
                                    .Where(x => x.Count > 0)
                                    .SelectMany(x => x);

            Console.WriteLine(string.Join(separator, allPatientsInDepartment));
        }

        private void AddPatientToRoom(string department, string patient, string fullName)
        {
            int room = 0;
            doctors[fullName].Add(patient);

            for (int currentRoom = 0; currentRoom < departments[department].Count; currentRoom++)
            {
                if (departments[department][currentRoom].Count < 3)
                {
                    room = currentRoom;
                    break;
                }
            }

            departments[department][room].Add(patient);
        }

        private void AddDepartment(string departament)
        {
            if (!departments.ContainsKey(departament))
            {
                departments[departament] = new List<List<string>>();

                for (int rooms = 0; rooms < 20; rooms++)
                {
                    departments[departament].Add(new List<string>());
                }
            }
        }

        private void AddDoctor(string fullName)
        {
            if (!doctors.ContainsKey(fullName))
            {
                doctors[fullName] = new List<string>();
            }
        }
    }
}
