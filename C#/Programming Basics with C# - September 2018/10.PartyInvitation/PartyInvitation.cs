using System;

namespace _10.PartyInvitation
{
    class PartyInvitation
    {
        static void Main(string[] args)
        {
            string name;
            string validName;
            int nameCounter = 0;
            int validNameCounter = 0;
            bool isVlalidName;
            bool firstLettet;
            double percentValidNames = 0;

            while ((name = Console.ReadLine()) != "Statistic")
            {
                isVlalidName = true;
                nameCounter++;
                validName = "";

                foreach (char letter in name)
                {
                    if (!((letter >= 65 && letter <= 90) || (letter >= 97 && letter <= 122)))
                    {
                        isVlalidName = false;
                        break;
                    }
                }
                
                if (isVlalidName)
                {
                    firstLettet = true;
                    validNameCounter++;

                    foreach (char letter in name)
                    {
                        if (firstLettet && (letter >= 97 && letter <= 122))
                        {
                            validName = validName + (char)(letter - 32);
                        }
                        else if (firstLettet && !(letter >= 97 && letter <= 122))
                        {
                            validName = validName + letter;
                        }
                        else if(!firstLettet && letter >= 65 && letter <= 90)
                        {
                            
                            validName = validName + (char)(letter + 32);
                        }
                        else if(!firstLettet)
                        {
                            validName = validName + letter;
                        }
                        firstLettet = false;
                    }
                }

                if (isVlalidName)
                {
                    Console.WriteLine(validName);
                }
                else
                {
                    Console.WriteLine("Invalid name!");
                }
            }

            percentValidNames = (validNameCounter * 100.0) / nameCounter;
            Console.WriteLine($"Valid names are {percentValidNames:F02}% from {nameCounter} names.");
            Console.WriteLine($"Invalid names are {100 - percentValidNames:F02}% from {nameCounter} names.");
        }
    }
}
