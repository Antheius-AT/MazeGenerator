using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MazeGenerator
{
    public class DefaultMazeGenerator : IMazeGenerator
    {
        private Random random;
        private MazeCell[] mazeCells;
        private int mazeWidth;
        private int mazeHeight;

        public DefaultMazeGenerator()
        {
            this.random = new Random();
        }

        public Maze Generate(int width, int height)
        {
            this.mazeCells = new MazeCell[width * height];
            this.mazeWidth = width;
            this.mazeHeight = height;

            for (int i = 0; i < mazeCells.Length; i++)
            {
                mazeCells[i] = new MazeCell();
            }

            mazeCells[this.random.Next(0, width * height)].IsInMaze = true;

            do
            {
                this.GenerateMazePath();
            }
            while (mazeCells.FirstOrDefault(cell => !cell.IsInMaze) != null);

            var walls = this.GenerateMazeWalls();
            return new Maze(height, width, mazeCells);
        }

        /// <summary>
        /// This method generates a single random maze path.
        /// </summary>
        private void GenerateMazePath()
        {
            int randomStartIndex;
            int currentIndex;
            int walkEndIndex;

            randomStartIndex = this.GenerateRandomWalkStart();
            currentIndex = randomStartIndex;
            walkEndIndex = this.PerformRandomWalk(currentIndex);
            this.AddPathToMaze(currentIndex, walkEndIndex);
        }

        /// <summary>
        /// Starts at a specified index and walks a path, adding cells on the path to the maze.
        /// </summary>
        /// <param name="currentIndex">The current index of the cell being walked.</param>
        /// <param name="walkEndIndex">The index at which to terminate the walk.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Is thrown if either of the indexes are negative or greater than the cells amount.
        /// </exception>
        private void AddPathToMaze(int currentIndex, int walkEndIndex)
        {
            do
            {
                this.mazeCells[currentIndex].IsInMaze = true;
                currentIndex = this.UpdateIndex(this.mazeCells[currentIndex].WalkDirection, currentIndex);
            }
            while (currentIndex != walkEndIndex);
        }

        /// <summary>
        /// Generates a random starting index for the random walk.
        /// </summary>
        /// <returns>The random starting index for the random walk.</returns>
        private int GenerateRandomWalkStart()
        {
            int randomStartIndex;

            do
            {
                randomStartIndex = this.random.Next(0, this.mazeCells.Length);
            }
            while (this.mazeCells[randomStartIndex].IsInMaze);

            return randomStartIndex;
        }

        /// <summary>
        /// Performs the random walk to find a path in the maze.
        /// </summary>
        /// <param name="startingIndex">The index to start the random walk from.</param>
        /// <returns>The index of the cell that terminated the random walk.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if start index is negative or already contained in maze.
        /// </exception>
        private int PerformRandomWalk(int startingIndex)
        {
            var currentIndex = startingIndex;

            do
            {
                var direction = this.GetRandomWalkDirection();

                if (this.CanWalkDirection(direction, currentIndex))
                {
                    this.mazeCells[currentIndex].WalkDirection = direction;
                    currentIndex = this.UpdateIndex(direction, currentIndex);
                }
            }
            while (!this.mazeCells[currentIndex].IsInMaze);

            return currentIndex;
        }

        private Direction GetRandomWalkDirection()
        {
            var randomNumber = this.random.Next(1, 101);

            if (randomNumber < 25)
                return Direction.Up;
            if (randomNumber < 50)
                return Direction.Right;
            if (randomNumber < 75)
                return Direction.Down;
            else
                return Direction.Left;
        }

        private bool CanWalkDirection(Direction direction, int currentIndex)
        {
            switch (direction)
            {
                case Direction.Up:
                    return this.CanWalkUp(currentIndex);
                case Direction.Down:
                    return this.CanWalkDown(currentIndex);
                case Direction.Left:
                    return this.CanWalkLeft(currentIndex);
                case Direction.Right:
                    return this.CanWalkRight(currentIndex);
                default:
                    throw new ArgumentException(nameof(direction), "Invalid Direction.");
            }
        }

        private bool CanWalkRight(int currentIndex)
        {
            // true if anywhere but in the right-most column.
            return (currentIndex + 1) % this.mazeWidth > 0;
        }

        private bool CanWalkLeft(int currentIndex)
        {
            // true if anywhere but in the left most column.
            return currentIndex % this.mazeWidth > 0;
        }

        private bool CanWalkDown(int currentIndex)
        {
            // Similar to check if can walk right. True if anyhwere but in the lower most row.
            return currentIndex < (this.mazeHeight * this.mazeWidth) - this.mazeWidth;
        }

        private bool CanWalkUp(int currentIndex)
        {
            // True if anywhere but in the upper most row.
            return currentIndex >= this.mazeWidth;
        }

        private int UpdateIndex(Direction direction, int currentIndex)
        {
            switch (direction)
            {
                case Direction.Up:
                    return currentIndex - this.mazeWidth;
                case Direction.Down:
                    return currentIndex + this.mazeWidth;
                case Direction.Left:
                    return currentIndex - 1;
                case Direction.Right:
                    return currentIndex + 1;
                default:
                    throw new ArgumentException(nameof(direction), "Invalid direction");
            }
        }

        private MazeWall[] GenerateMazeWalls()
        {
            for (int i = 0; i < this.mazeCells.Length; i++)
            {
                throw new NotImplementedException();
            }

            throw new NotImplementedException();
        }
    }
}
