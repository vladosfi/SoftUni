namespace P01_StudentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Data.Models;

    public class StartUp
    {
        static void Main()
        {

            GenerateMappingTableData();


            //Generate Courses Names
            //string[] firstName =
            //{
            //    "Ivan",
            //    "Dragan",
            //    "Petyr",
            //    "Misho"
            //};

            //string[] lastName =
            //{
            //    "Ivanov",
            //    "Draganov",
            //    "Petyrov",
            //    "Dimitrov"
            //};

            //List<Student> allNames = GenerateStudents(firstName, lastName);

            //int numberOfSeeds = SeedData(allNames);

            //Generate Courses
            //string[] courseNames =
            //{
            //    "Advanced",
            //    "Fundamentals",
            //    "Basics",
            //    "Database"
            //};

            //string[] languages =
            //{
            //    "JS",
            //    "C#",
            //    "Java",
            //    "Piton",
            //    "PHP"
            //};

            //List<Course> allCourses = GenerateCourses(courseNames, languages);

            //int numberOfSeeds = SeedData(allCourses);

            //Console.WriteLine(numberOfSeeds);
        }

        private static void GenerateMappingTableData()
        {
            using (var context = new StudentSystemContext())
            {
                var students = context.Students.ToList();
                var cources = context.Courses.ToList();

                var rnd = new Random();

                var randomIds = new List<KeyValuePair<int, int>>();

                for (int i = 0; i < 10000; i++)
                {
                    var randomStudentIndex = rnd.Next(0, students.Count);
                    var randomStudent = students[randomStudentIndex];

                    var randomCourseIndex = rnd.Next(0, cources.Count);
                    var randomCourse = cources[randomCourseIndex];

                    var studentInCourse = new StudentCourse
                    {
                        Student = randomStudent,
                        Course = randomCourse
                    };

                    var randomKvp = new KeyValuePair<int, int>
                        (
                            randomStudent.StudentId,
                            randomCourse.CourseId);

                    randomIds.Add(randomKvp);
                }

                randomIds = randomIds.Distinct().ToList();


                foreach (var idPair in randomIds)
                {
                    context.StudentCourses.Add(
                        new StudentCourse
                        {
                            StudentId = idPair.Key,
                            CourseId = idPair.Value
                        });
                }
                Console.WriteLine(context.SaveChanges());
            }
        }

        private static List<Course> GenerateCourses(string[] firstData, string[] secondData)
        {
            var initialPrice = 0;
            var allCourses = new List<Course>();

            foreach (var second in secondData)
            {
                foreach (var first in firstData)
                {
                    string courceName = $"{second} {first}";

                    var course = new Course
                    {
                        Name = courceName,
                        Description = $"Desctiption for the {courceName}",
                        Price = initialPrice
                    };

                    allCourses.Add(course);
                    initialPrice += 33;
                }
            }

            return allCourses;
        }

        private static List<Student> GenerateStudents(string[] firstData, string[] secondData)
        {
            var initialPrice = 0;
            var allStudents = new List<Student>();

            foreach (var second in secondData)
            {
                foreach (var first in firstData)
                {
                    string fullName = $"{second} {first}";

                    var student = new Student
                    {
                        Name = fullName,

                    };

                    allStudents.Add(student);
                    initialPrice += 33;
                }
            }

            return allStudents;
        }

        private static int SeedData(List<Student> dataToSeed)
        {
            using (var context = new StudentSystemContext())
            {
                context.AddRange(dataToSeed);
                return context.SaveChanges();
            }
        }
    }
}
