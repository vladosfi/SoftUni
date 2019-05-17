using System;

namespace _07.Salary
{
    class Salary
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());
            string tabSite = "";

            for (int i = 0; i < n; i++)
            {
                tabSite = Console.ReadLine();

                if (tabSite == "Facebook")
                {
                    salary = salary - 150;
                }
                else if (tabSite == "Instagram")
                {
                    salary = salary - 100;
                }
                else if (tabSite == "Reddit")
                {
                    salary = salary - 50;
                }

                if (salary <= 0)
                {
                    break;
                }
            }

            if (salary <= 0)
            {
                Console.WriteLine("You have lost your salary.");
            }
            else
            {
                Console.WriteLine(salary);
            }
        }
    }
}
