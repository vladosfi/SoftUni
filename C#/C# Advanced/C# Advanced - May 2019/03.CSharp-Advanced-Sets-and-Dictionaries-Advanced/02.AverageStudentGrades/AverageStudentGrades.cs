using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _02.AverageStudentGrades
{
    class AverageStudentGrades
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            int n = int.Parse(Console.ReadLine());
            var students = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string[] student = Console.ReadLine().Split();
                string studentName = student[0];
                double studentGrade = double.Parse(student[1]);
                
                if (!students.ContainsKey(studentName))
                {
                    students.Add(studentName, new List<double>());
                }

                students[studentName].Add(studentGrade);
            }


            foreach (var kvp in students)
            {
                Console.Write($"{kvp.Key} -> ");

                foreach (var grade in kvp.Value)
                {
                    Console.Write($"{grade:f02} ");
                }
                Console.WriteLine($"(avg: {kvp.Value.Average():f02})");
                 
            }
        }
    }
}
