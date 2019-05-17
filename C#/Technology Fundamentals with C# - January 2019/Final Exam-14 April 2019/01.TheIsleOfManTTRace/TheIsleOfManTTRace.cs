using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _01.TheIsleOfManTTRace
{
    class TheIsleOfManTTRace
    {
        static void Main()
        {
            while (true)
            {
                string message = Console.ReadLine();
                Regex regex = new Regex(@"^([#$%*&])(?<name>[A-Za-z]+)\1=(?<code>[\d]+)!!(?<encrypted>.+$)");
                Match match = regex.Match(message);

                if (match.Success)
                {
                    string nameOfRacer = match.Groups["name"].Value;
                    int code = int.Parse(match.Groups["code"].Value);
                    string geohashcode = match.Groups["encrypted"].Value;

                    if (code == geohashcode.Length)
                    {
                        StringBuilder decrypted = new StringBuilder();

                        for (int i = 0; i < geohashcode.Length; i++)
                        {
                            decrypted.Append((char)(geohashcode[i] + code));
                        }

                        Console.WriteLine($"Coordinates found! {nameOfRacer} -> {decrypted}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                    }
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }
                
            }
        }
        
    }
}
