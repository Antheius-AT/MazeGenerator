//-----------------------------------------------------------------------
// <copyright file="DefaultMazeGenerator.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace MazeGenerator
{
    using System;
    using System.Linq;

    /// <summary>
    /// The default maze generator, which simply generates the complete maze via a random walk, but does not
    /// update the caller upon individual steps.
    /// </summary>
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

        /// <summary>
        /// Generates a maze with the specified height and width.
        /// </summary>
        /// <param name="width">the maze width.</param>
        /// <param name="height">The maze height.</param>
        /// <returns>The generated maze.</returns>
        public Maze Generate(int width, int height)
        {
            this.mazeCells = new MazeCell[width * height];
            this.mazeWidth = width;
            this.mazeHeight = height;

            // Initializes the maze cells, to avoid Nullreference exceptions.
            for (int i = 0; i < mazeCells.Length; i++)
            {
                mazeCells[i] = new MazeCell();
            }

            // Generate starting point for random walk. Mark any point in cells as "in maze".
            mazeCells[this.random.Next(0, mazeCells.Length)].IsInMaze = true;

            // Keeps generating maze paths until no cell is left marked as "not in maze".
            do
            {
                this.GenerateMazePath();
            }
            while (mazeCells.FirstOrDefault(cell => !cell.IsInMaze) != null);

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
            // Walks the randomly generated path starting from the current index, and adds 
            // each of the cells on the path to the maze.
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

            // Generate random index, and keep trying until finding a cell which is not yet in the maze.
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

            // This is the actual random walk logic.
            // Generates a random direction for each cell, and walks into that direction if the direction is valid.
            // This goes on, until current index represent a cell, that is already in the maze.
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

        /// <summary>
        /// Gets a random walk direction.
        /// </summary>
        /// <returns>The random walk direction.</returns>
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

        /// <summary>
        /// Determines whether the walk can walk in a specified direction.
        /// </summary>
        /// <param name="direction">The specified direction.</param>
        /// <param name="currentIndex">The current index.</param>
        /// <returns>Whether the walk can walk in the current direction.</returns>
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

        /// <summary>
        /// Checks whether the walk can walk right from the current index.
        /// </summary>
        /// <param name="currentIndex">The current index.</param>
        /// <returns>Whether the walk can walk right.</returns>
        private bool CanWalkRight(int currentIndex)
        {
            // true if anywhere but in the right-most column.
            return (currentIndex + 1) % this.mazeWidth > 0;
        }

        /// <summary>
        /// Checks whether the walk can walk left from the current index.
        /// </summary>
        /// <param name="currentIndex">The current index.</param>
        /// <returns>Whether the walk can walk left.</returns>
        private bool CanWalkLeft(int currentIndex)
        {
            // true if anywhere but in the left most column.
            return currentIndex % this.mazeWidth > 0;
        }

        /// <summary>
        /// Checks whether the walk can walk down from the current index.
        /// </summary>
        /// <param name="currentIndex">The current index.</param>
        /// <returns>Whether the walk can walk down.</returns>
        private bool CanWalkDown(int currentIndex)
        {
            // Similar to check if can walk right. True if anyhwere but in the lower most row.
            return currentIndex < (this.mazeHeight * this.mazeWidth) - this.mazeWidth;
        }

        /// <summary>
        /// Checks whether the walk can walk up from the current index.
        /// </summary>
        /// <param name="currentIndex">The current index.</param>
        /// <returns>Whether the walk can walk up.</returns>
        private bool CanWalkUp(int currentIndex)
        {
            // True if anywhere but in the upper most row.
            return currentIndex >= this.mazeWidth;
        }

        /// <summary>
        /// Updates the index, based on the latest walk direction.
        /// </summary>
        /// <param name="direction">The walk direction.</param>
        /// <param name="currentIndex">The current index that needs updating.</param>
        /// <returns>The updated index.</returns>
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
    }
}
