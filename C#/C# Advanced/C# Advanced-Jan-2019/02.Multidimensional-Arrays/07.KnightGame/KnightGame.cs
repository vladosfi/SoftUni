using System;

namespace _07.KnightGame
{
    class KnightGame
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[,] board = new char[n, n];
            int removedKnight = 0;

            for (int row = 0; row < n; row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    board[row, col] = line[col];
                }
            }

            while (true)
            {
                int[,] attackBoard = new int[n, n];

                //Loop trough all cells on board and search for K
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (board[row, col] == 'K')
                        {
                            int attackCount = CheckAttackCount(board,row,col);
                            attackBoard[row, col] = attackCount;
                        }
                    }
                }


                //Search max attacked knight and remove it
                int maxRow = 0;
                int maxCol = 0;
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if(attackBoard[row,col] > attackBoard[maxRow, maxCol])
                        {
                            maxRow = row;
                            maxCol = col;
                        }
                    }
                }

                if (attackBoard[maxRow,maxCol] != 0)
                {
                    board[maxRow, maxCol] = '0';
                    removedKnight++;
                }
                else
                {
                    break;
                }
            }


            Console.WriteLine(removedKnight);
        }

        private static int CheckAttackCount(char[,] board,int row, int col)
        {
            int count = 0;
            
            //Up left
            if (row - 2 >= 0 && col - 1 >= 0 && board[row - 2,col - 1] == 'K')
            {
                count++;
            }
            if (row - 1 >= 0 && col - 2 >= 0 && board[row - 1, col - 2] == 'K')
            {
                count++;
            }
            //Up right
            if (row - 2 >= 0 && col + 1 < board.GetLength(1) && board[row - 2, col + 1] == 'K')
            {
                count++;
            }
            if (row - 1 >= 0 && col + 2 < board.GetLength(1) && board[row - 1, col + 2] == 'K')
            {
                count++;
            }
            //Down left
            if (row + 2 < board.GetLength(0) && col - 1 >= 0 && board[row + 2, col - 1] == 'K')
            {
                count++;
            }
            if (row + 1 < board.GetLength(0) && col - 2 >= 0 && board[row + 1, col - 2] == 'K')
            {
                count++;
            }
            //Down right
            if (row + 2 < board.GetLength(0) && col + 1 < board.GetLength(1) && board[row + 2, col + 1] == 'K')
            {
                count++;
            }
            if (row + 1 < board.GetLength(0) && col + 2 < board.GetLength(1) && board[row + 1, col + 2] == 'K')
            {
                count++;
            }



            return count;
        }
    }
}
