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
            var students = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var array = Console.ReadLine().Split();
                string name = array[0];
                double grade = double.Parse(array[1]);

                if (!students.ContainsKey(name))
                {
                    students[name] = new List<double>();
                }

                students[name].Add(grade);
            }

            foreach (var kvp in students)
            {
                Console.Write($"{kvp.Key} -> ");
                foreach (var grade in  kvp.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.WriteLine($"(avg: { kvp.Value.Average():f2})" );
            }
        }
    }
}
