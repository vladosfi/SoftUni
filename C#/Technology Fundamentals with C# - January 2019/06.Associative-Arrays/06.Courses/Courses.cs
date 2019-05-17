using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Courses
{
    class Courses
    {
        static void Main()
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(" : ");

                if (tokens[0].ToLower() == "end")
                {
                    break;
                }

                string courseName = tokens[0];
                string studentName  = tokens[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>());
                }

                courses[courseName].Add(studentName);
            }

            foreach (var kvp in courses.OrderByDescending(x => x.Value.Count))
            {
                List<string> students = kvp.Value;
                students.Sort();

                Console.WriteLine($"{kvp.Key}: {students.Count}" );
                
                foreach (var student in students)
                {
                    Console.WriteLine($"-- {student}");
                }
            }

        }
    }
}
