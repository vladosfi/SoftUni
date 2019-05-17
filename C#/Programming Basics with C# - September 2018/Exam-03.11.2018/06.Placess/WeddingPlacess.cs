using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            char sektor = Convert.ToChar(Console.ReadLine());
            int brredove = int.Parse(Console.ReadLine());
            int brmesta = int.Parse(Console.ReadLine());
            int count = 0;

            for (char i = 'A'; i <= sektor; i++)
            {
                for (int r = 1; r <= brredove; r++)
                {
                    if (r % 2 == 0)
                    {

                        for (int m = 'a'; m < ((brmesta+2) + 'a'); m++)
                        {

                            Console.WriteLine($"{i}{r}{(char)m}");
                            count++;
                        }
                    }
                    else
                    {
                        for (int m = 'a'; m < brmesta + 'a'; m++)
                        {

                            Console.WriteLine($"{i}{r}{(char)m}");
                            count++;
                        }
                    }
                }
                brredove++;
            }
            Console.WriteLine(count++);
        }
    }
}