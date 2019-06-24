using System;

namespace Program3
{
    class StartUp
    {
        static char[,] galaxy;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            galaxy = new char[n, n];
            int shipRow = 0;
            int shipCol = 0;
            int starPower = 0;
            bool wentToTheVoid = false;

            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    galaxy[row, col] = input[col];

                    if (galaxy[row, col] == 'S')
                    {
                        shipRow = row;
                        shipCol = col;
                    }
                }
            }


            while (true)
            {
                string command = Console.ReadLine();
                galaxy[shipRow, shipCol] = '-';

                if (command == "up")
                {
                    int newRow = shipRow - 1;

                    if (OutOfRange(newRow, shipCol))
                    {
                        wentToTheVoid = true;
                        break;
                    }

                    if (char.IsDigit(galaxy[newRow, shipCol]))
                    {
                        starPower += (int)(galaxy[newRow, shipCol] - '0' );

                        shipRow = newRow;
                        galaxy[shipRow, shipCol] = 'S';
                    }
                    else if (galaxy[newRow, shipCol] == 'O')
                    {
                        galaxy[newRow, shipCol] = '-';
                        for (int row = 0; row < galaxy.GetLength(0); row++)
                        {
                            for (int col = 0; col < galaxy.GetLength(0); col++)
                            {
                                if (galaxy[row, col] == 'O')
                                {
                                    shipRow = row;
                                    shipCol = col;
                                    galaxy[shipRow, shipCol] = 'S';
                                }
                            }
                        }
                    }
                    else
                    {
                        shipRow = newRow;
                        galaxy[shipRow, shipCol] = 'S';
                    }                    
                }
                else if (command == "down")
                {
                    int newRow = shipRow + 1;

                    if (OutOfRange(newRow, shipCol))
                    {
                        wentToTheVoid = true;
                        break;
                    }

                    if (char.IsDigit(galaxy[newRow, shipCol]))
                    {
                        starPower += (int)(galaxy[newRow, shipCol] - '0' );

                        shipRow = newRow;
                        galaxy[shipRow, shipCol] = 'S';
                    }
                    else if (galaxy[newRow, shipCol] == 'O')
                    {
                        galaxy[newRow, shipCol] = '-';
                        for (int row = 0; row < galaxy.GetLength(0); row++)
                        {
                            for (int col = 0; col < galaxy.GetLength(0); col++)
                            {
                                if (galaxy[row, col] == 'O')
                                {
                                    shipRow = row;
                                    shipCol = col;
                                    galaxy[shipRow, shipCol] = 'S';
                                }
                            }
                        }
                    }
                    else
                    {
                        shipRow = newRow;
                        galaxy[shipRow, shipCol] = 'S';
                    }
                }
                else if (command == "left")
                {
                    int newCol = shipCol - 1;

                    if (OutOfRange(shipRow, newCol))
                    {
                        wentToTheVoid = true;
                        break;
                    }

                    if (char.IsDigit(galaxy[shipRow, newCol]))
                    {
                        starPower += (int)(galaxy[shipRow, newCol] - '0' );

                        shipCol = newCol;
                        galaxy[shipRow, shipCol] = 'S';
                    }
                    else if (galaxy[shipRow, newCol] == 'O')
                    {
                        galaxy[shipRow, newCol] = '-';
                        for (int row = 0; row < galaxy.GetLength(0); row++)
                        {
                            for (int col = 0; col < galaxy.GetLength(0); col++)
                            {
                                if (galaxy[row, col] == 'O')
                                {
                                    shipRow = row;
                                    shipCol = col;
                                    galaxy[shipRow, shipCol] = 'S';
                                }
                            }
                        }
                    }
                    else
                    {
                        shipCol = newCol;
                        galaxy[shipRow, shipCol] = 'S';
                    }
                }
                else if (command == "right")
                {
                    int newCol = shipCol + 1;

                    if (OutOfRange(shipRow, newCol))
                    {
                        wentToTheVoid = true;
                        break;
                    }

                    if (char.IsDigit(galaxy[shipRow, newCol]))
                    {
                        starPower += (int)(galaxy[shipRow, newCol] - '0' );

                        shipCol = newCol;
                        galaxy[shipRow, shipCol] = 'S';
                    }
                    else if (galaxy[shipRow, newCol] == 'O')
                    {
                        galaxy[shipRow, newCol] = '-';

                        for (int row = 0; row < galaxy.GetLength(0); row++)
                        {
                            for (int col = 0; col < galaxy.GetLength(0); col++)
                            {
                                if (galaxy[row, col] == 'O')
                                {
                                    shipRow = row;
                                    shipCol = col;
                                    galaxy[shipRow, shipCol] = 'S';
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        shipCol = newCol;
                        galaxy[shipRow, shipCol] = 'S';
                    }
                }


                if (starPower >= 50)
                {
                    break;
                }
            }

            if (wentToTheVoid)
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
            }
            else if (starPower >= 50)
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
            }

            Console.WriteLine($"Star power collected: {starPower}");
            
            PrintGalagy();
        }

        public static bool OutOfRange(int row, int col)
        {
            if (row < 0 ||
                col < 0 ||
                col >= galaxy.GetLength(0) ||
                row >= galaxy.GetLength(0))
            {
                return true;
            }

            return false;
        }

        static void PrintGalagy()
        {
            for (int row = 0; row < galaxy.GetLength(0); row++)
            {
                for (int col = 0; col < galaxy.GetLength(0); col++)
                {
                    Console.Write(galaxy[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
