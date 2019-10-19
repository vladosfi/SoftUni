using System;
using System.Collections.Generic;
using System.Text;

namespace P06_Sneaking
{
    public class Engine
    {
        private char[][] room;
        private int[] playerPosition;
        private int[] targetPosition;

        public Engine()
        {
            playerPosition = new int[2];
        }

        public void Start()
        {
            InitializeRoom();

            GetPlayerPosition();

            var moves = Console.ReadLine().ToCharArray();

            for (int i = 0; i < moves.Length; i++)
            {
                MoveEnemy();

                targetPosition = new int[2];

                GetTargetPosition();

                if (IsPlayerDead())
                {
                    room[playerPosition[0]][playerPosition[1]] = 'X';
                    Console.WriteLine($"Sam died at {playerPosition[0]}, {playerPosition[1]}");
                    PrintRoom();
                    break;
                }

                room[playerPosition[0]][playerPosition[1]] = '.';

                MovePlayer(moves[i]);

                room[playerPosition[0]][playerPosition[1]] = 'S';

                GetTargetPosition();

                if (room[targetPosition[0]][targetPosition[1]] == 'N' && playerPosition[0] == targetPosition[0])
                {
                    room[targetPosition[0]][targetPosition[1]] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    PrintRoom();
                    break;
                }
            }
        }

        private void GetTargetPosition()
        {
            for (int j = 0; j < room[playerPosition[0]].Length; j++)
            {
                if (room[playerPosition[0]][j] != '.' && room[playerPosition[0]][j] != 'S')
                {
                    targetPosition[0] = playerPosition[0];
                    targetPosition[1] = j;
                }
            }
        }

        private void MovePlayer(char move)
        {
            switch (move)
            {
                case 'U':
                    playerPosition[0]--;
                    break;
                case 'D':
                    playerPosition[0]++;
                    break;
                case 'L':
                    playerPosition[1]--;
                    break;
                case 'R':
                    playerPosition[1]++;
                    break;
                default:
                    break;
            }
        }

        private bool IsPlayerDead()
        {
            bool isPlayerDead = false;

            if (playerPosition[1] < targetPosition[1] && room[targetPosition[0]][targetPosition[1]] == 'd' && targetPosition[0] == playerPosition[0])
            {
                isPlayerDead = true;
            }
            else if (targetPosition[1] < playerPosition[1] && room[targetPosition[0]][targetPosition[1]] == 'b' && targetPosition[0] == playerPosition[0])
            {
                isPlayerDead = true;
            }

            return isPlayerDead;
        }

        private void PrintRoom()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }

                Console.WriteLine();
            }
        }

        private void MoveEnemy()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            room[row][col] = 'd';
                        }
                    }
                    else if (room[row][col] == 'd')
                    {
                        if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }
                        else
                        {
                            room[row][col] = 'b';
                        }
                    }
                }
            }
        }

        private void GetPlayerPosition()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        playerPosition[0] = row;
                        playerPosition[1] = col;
                    }
                }
            }
        }

        private void InitializeRoom()
        {
            int n = int.Parse(Console.ReadLine());
            room = new char[n][];

            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                room[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    room[row][col] = input[col];
                }
            }
        }
    }
}
