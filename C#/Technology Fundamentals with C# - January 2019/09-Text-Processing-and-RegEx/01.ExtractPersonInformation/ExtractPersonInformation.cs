using System;
using System.Text.RegularExpressions;

namespace _01.ExtractPersonInformation
{
    class ExtractPersonInformation
    {
        static void Main()
        {
            //string pattern = @"@(?<name>[A-Z][a-z]+|[a-z]+)\|[^#]+#(?<age>[\d]{1,2})\*";
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                
                Regex regex = new Regex(@"@(?<name>[\w]+)\|");
                Match match = regex.Match(input);
                string name = match.Groups["name"].ToString();

                regex = new Regex(@"#(?<age>[\d]{1,3})\*");
                match = regex.Match(input);
                string age = match.Groups["age"].ToString();

                Console.WriteLine($"{name} is {age} years old.");
                
            }             
        }

    }
}
