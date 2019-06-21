﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TrojanInvasion
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());

            int[] platesData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> plates = new Queue<int>(platesData);

            Stack<int> trojanWarriors = new Stack<int>();

            int waveCounter = 0;

            while (plates.Count > 0)
            {
                int[] trojansData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                trojanWarriors = new Stack<int>(trojansData);

                while (trojanWarriors.Count > 0)
                {                    
                    int warior = trojanWarriors.Pop();
                    int plate = plates.Dequeue();

                    if (warior > plate)
                    {
                        int wariorValue = warior - plate;

                        if (wariorValue > 0)
                        {
                            trojanWarriors.Push(wariorValue);
                        }
                    }
                    else if (plate > warior)
                    {
                        int paleteValue = plate - warior;

                        if (paleteValue > 0)
                        {
                            plates.Enqueue(paleteValue);
                        }
                    }
                }

                waveCounter++;

                if (waveCounter % 3 == 0)
                {
                    int extraPlate = int.Parse(Console.ReadLine());
                    plates.Enqueue(extraPlate);
                    waveCounter = 0;
                }
            }

            if (trojanWarriors.Count>0)
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {string.Join(", ", trojanWarriors)}");
            }
            else
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }



        }
    }
}
