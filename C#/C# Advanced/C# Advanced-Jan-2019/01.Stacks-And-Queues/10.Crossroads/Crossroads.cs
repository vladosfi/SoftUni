using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Crossroads
{
    class Crossroads
    {
        static void Main()
        {
            int green = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            int passCounter = 0;
            bool success = true;

            while (true)
            {
                string token = Console.ReadLine();

                if (token.ToLower() == "end")
                {
                    break;
                }

                queue.Enqueue(token);
            }

            Queue<string> carQueue = new Queue<string>();

            while (queue.Any())
            {
                if (queue.Peek().ToLower() == "green")
                {
                    queue.Dequeue();
                    int greenTimer = green;
                    int freeWindowTimer = freeWindow;
                    string car = "";

                    while (carQueue.Any())
                    {
                        car = carQueue.Peek();
                        if (greenTimer >= car.Length)
                        {
                            passCounter++;
                            greenTimer -= car.Length;
                            car = "";
                            carQueue.Dequeue();
                        }
                        else if (greenTimer > 0 && greenTimer < car.Length)
                        {
                            car = car.Substring(greenTimer);
                            greenTimer = 0;
                        }

                        if (freeWindowTimer >= car.Length && car != "")
                        {
                                passCounter++;
                                freeWindowTimer -= car.Length;
                                car = "";
                                carQueue.Dequeue();
                        }
                        else if (freeWindowTimer < car.Length && car != "")
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{carQueue.Peek()} was hit at {car[freeWindowTimer]}.");
                            return;
                        }

                        if (carQueue.Any() && greenTimer == 0)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    carQueue.Enqueue(queue.Dequeue());
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passCounter} total cars passed the crossroads.");

        }
    }

}