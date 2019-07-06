namespace P03_JediGalaxy
{
    using System;
    using System.Linq;

    public class Engine
    {
        private int[,] galaxy;
        long sumOfCollectedStars = 0;

        public void Start()
        {
            int[] dimesions = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimesions[0];
            int cols = dimesions[1];

            this.InitializeGalaxy(rows, cols);
            sumOfCollectedStars = 0;

            string command = Console.ReadLine();

            while (command != "Let the Force be with you")
            {
                int[] playerPosition = command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int[] evilPosition = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int evelRow = evilPosition[0];
                int evelCol = evilPosition[1];
                this.MoveEvelToTopLeftCorner(evelRow, evelCol);

                int playerRow = playerPosition[0];
                int playerCol = playerPosition[1];
                this.MovePlayerToTopRightCorner(playerRow, playerCol);

                command = Console.ReadLine();
            }

            Console.WriteLine(sumOfCollectedStars);

        }

        private void MovePlayerToTopRightCorner(int ivoRow, int ivoCol)
        {
            while (ivoRow >= 0 && ivoCol < this.galaxy.GetLength(1))
            {
                if (this.IsInside(ivoRow, ivoCol))
                {
                    sumOfCollectedStars += this.galaxy[ivoRow, ivoCol];
                }

                ivoCol++;
                ivoRow--;
            }
        }

        private void MoveEvelToTopLeftCorner(int evelRow, int evelCol)
        {
            while (evelRow >= 0 && evelCol >= 0)
            {
                if (this.IsInside(evelRow, evelCol))
                {
                    galaxy[evelRow, evelCol] = 0;
                }

                evelRow--;
                evelCol--;
            }
        }

        private int[,] InitializeGalaxy(int rows, int cols)
        {
            this.galaxy = new int[rows, cols];
            int starValue = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    this.galaxy[row, col] = starValue++;
                }
            }

            return galaxy;
        }

        private bool IsInside(int row, int col)
        {
            return row >= 0 && col >= 0 && 
                row < this.galaxy.GetLength(0) && col < this.galaxy.GetLength(1);
        }
    }
}
