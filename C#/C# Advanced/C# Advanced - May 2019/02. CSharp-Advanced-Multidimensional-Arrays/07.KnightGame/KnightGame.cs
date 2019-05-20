using System;

namespace _07.KnightGame
{
    class KnightGame
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[,] chessField = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    chessField[row, col] = input[col];
                }
            }

            int counter = 0;

            while (true)
            {
                int maxAttack = 0;
                int maxAttackRow = 0;
                int maxAttackCol = 0;
                
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (chessField[row, col] == 'K')
                        {
                            int curAttack = 0;

                            if (row - 2 >= 0 && col - 1 >= 0 && chessField[row - 2, col - 1] == 'K')
                            {
                                curAttack++;
                            }
                            if (row - 1 >= 0 && col - 2 >= 0 && chessField[row - 1, col - 2] == 'K')
                            {
                                curAttack++;
                            }
                            if (row - 2 >= 0 && col + 1 < n && chessField[row - 2, col + 1] == 'K')
                            {
                                curAttack++;
                            }
                            if (row - 1 >= 0 && col + 2 < n && chessField[row - 1, col + 2] == 'K')
                            {
                                curAttack++;
                            }
                            if (row + 1 < n && col - 2 >= 0 && chessField[row + 1, col - 2] == 'K')
                            {
                                curAttack++;
                            }
                            if (row + 2 < n && col - 1 >= 0 && chessField[row + 2, col - 1] == 'K')
                            {
                                curAttack++;
                            }
                            if (row + 2 < n && col + 1 < n && chessField[row + 2, col + 1] == 'K')
                            {
                                curAttack++;
                            }
                            if (row + 1 < n && col + 2 < n && chessField[row + 1, col + 2] == 'K')
                            {
                                curAttack++;
                            }

                            if (maxAttack < curAttack)
                            {
                                maxAttack = curAttack;
                                maxAttackRow = row;
                                maxAttackCol = col;
                            }
                        }
                    }
                }

                if (maxAttack == 0)
                {
                    break;
                }
                else
                {
                    chessField[maxAttackRow, maxAttackCol] = '0';
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }
    }
}
