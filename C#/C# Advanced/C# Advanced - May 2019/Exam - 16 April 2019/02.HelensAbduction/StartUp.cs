using System;

namespace _02.HelensAbduction
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int parisEnergy = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            char[][] spartaField = new char[n][];
            int parisRow = 0;
            int parisCol = 0;
            bool abductedHelen = true;

            for (int i = 0; i < n; i++)
            {
                char[] inputField = Console.ReadLine().ToCharArray();
                spartaField[i] = new char[inputField.Length];

                for (int j = 0; j < inputField.Length; j++)
                {
                    spartaField[i][j] = inputField[j];

                    if (inputField[j] == 'P')
                    {
                        parisRow = i;
                        parisCol = j;
                    }
                }
            }

            while (true)
            {
                string[] tokens = Console.ReadLine().Split();
                string moveDirection = tokens[0];
                int spawnsRow = int.Parse(tokens[1]);
                int spawnsCol = int.Parse(tokens[2]);

                //set indices
                if (InsideMatrix(spartaField, spawnsRow, spawnsCol))
                {
                    spartaField[spawnsRow][spawnsCol] = 'S';
                }

                parisEnergy--;
                spartaField[parisRow][parisCol] = '-';

                if (moveDirection == "up" && 
                    InsideMatrix(spartaField, parisRow - 1, parisCol))
                {
                    parisRow--;

                    if (spartaField[parisRow][parisCol] == 'S')
                    {
                        parisEnergy -= 2;
                    }
                    else if (spartaField[parisRow][parisCol] == 'H')
                    {
                        spartaField[parisRow][parisCol] = '-';
                        break;
                    }

                    spartaField[parisRow][parisCol] = 'P';
                }
                else if (moveDirection == "down" && 
                    InsideMatrix(spartaField, parisRow + 1, parisCol))
                {
                    parisRow++;

                    if (spartaField[parisRow][parisCol] == 'S')
                    {
                        parisEnergy -= 2;
                    }
                    else if (spartaField[parisRow][parisCol] == 'H')
                    {
                        spartaField[parisRow][parisCol] = '-';
                        break;
                    }

                    spartaField[parisRow][parisCol] = 'P';
                }
                else if (moveDirection == "left" && 
                    InsideMatrix(spartaField, parisRow, parisCol - 1))
                {
                    parisCol--;

                    if (spartaField[parisRow][parisCol] == 'S')
                    {
                        parisEnergy -= 2;
                    }
                    else if (spartaField[parisRow][parisCol] == 'H')
                    {
                        spartaField[parisRow][parisCol] = '-';
                        break;
                    }

                    spartaField[parisRow][parisCol] = 'P';

                }
                else if (moveDirection == "right" && 
                    InsideMatrix(spartaField, parisRow, parisCol + 1))
                {
                    parisCol++;

                    if (spartaField[parisRow][parisCol] == 'S')
                    {
                        parisEnergy -= 2;
                    }
                    else if (spartaField[parisRow][parisCol] == 'H')
                    {
                        spartaField[parisRow][parisCol] = '-';
                        break;
                    }

                    spartaField[parisRow][parisCol] = 'P';
                }

                if (parisEnergy <= 0)
                {
                    spartaField[parisRow][parisCol] = 'X';
                    abductedHelen = false;
                    break;
                }
            }

            if (abductedHelen)
            {
                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {parisEnergy}");
            }
            else
            {
                Console.WriteLine($"Paris died at {parisRow};{parisCol}.");
            }

            foreach (var row in spartaField)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static bool InsideMatrix(char[][] spartaField, int parisRow, int parisCol)
        {
            bool result = false;
            if (parisRow >= 0 &&
                    parisCol >= 0 &&
                    parisRow < spartaField.Length &&
                    parisCol < spartaField[parisRow].Length)
            {
                result = true;
            }

            return result;
        }
    }
}
