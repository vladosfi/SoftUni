using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniCoursePlanning
{
    class SoftUniCoursePlanning
    {
        static void Main()
        {
            List<string> schedule = Console.ReadLine().Split(", ").ToList();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(":");

                if (tokens[0] == "course start")
                {
                    break;
                }

                string command = tokens[0];
                string lessonTitle = tokens[1];

                if (command == "Add")
                {
                    if (!schedule.Contains(lessonTitle))
                    {
                        schedule.Add(lessonTitle);
                    }
                }
                else if (command == "Insert")
                {
                    if (!schedule.Contains(lessonTitle))
                    {
                        int index = int.Parse(tokens[2]);
                        schedule.Insert(index, lessonTitle);
                    }
                }
                else if (command == "Remove")
                {
                    if (schedule.Contains(lessonTitle))
                    {
                        schedule.Remove(lessonTitle);
                        if (schedule.Contains(lessonTitle + "-Exercise"))
                        {
                            schedule.Remove(lessonTitle + "-Exercise");
                        }
                    }
                }
                else if (command == "Swap")
                {
                    string secondLessonTitle = tokens[2];

                    if (schedule.Contains(lessonTitle) && schedule.Contains(secondLessonTitle))
                    {
                        int indexOfFirstTitle = schedule.IndexOf(lessonTitle);
                        int indexOfSecondTitle = schedule.IndexOf(secondLessonTitle);

                        schedule.Insert(indexOfFirstTitle, secondLessonTitle);
                        schedule.RemoveAt(indexOfFirstTitle + 1);
                        
                        schedule.Insert(indexOfSecondTitle, lessonTitle);
                        schedule.RemoveAt(indexOfSecondTitle + 1);

                        if (schedule.Contains(lessonTitle + "-Exercise"))
                        {
                            schedule.RemoveAt(indexOfFirstTitle + 1);
                            schedule.Insert(indexOfSecondTitle, lessonTitle + "-Exercise");
                        }
                        if (schedule.Contains(secondLessonTitle + "-Exercise"))
                        {
                            schedule.RemoveAt(indexOfSecondTitle + 1);
                            schedule.Insert(indexOfFirstTitle + 1, secondLessonTitle + "-Exercise");
                        }
                    }

                }
                else if (command == "Exercise")
                {
                    if (!schedule.Contains(lessonTitle))
                    {
                        schedule.Add(lessonTitle);
                        schedule.Add(lessonTitle + "-Exercise");
                    }
                    else if (!schedule.Contains(lessonTitle + "-Exercise"))
                    {
                        int indexOfTitle = schedule.IndexOf(lessonTitle);
                        schedule.Insert(indexOfTitle+1, lessonTitle + "-Exercise");
                    }
                }
            }


            for (int i = 0; i < schedule.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{schedule[i]}");
            }
        }
    }
}
