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
            while (mazeCells.First(cell => cell.IsInMaze) == null);


            throw new NotImplementedException();
        }

        private void GenerateMazePath()
        {
            int randomStartIndex;
            int currentIndex;

            do
            {
                randomStartIndex = this.random.Next(0, this.mazeCells.Length);
            }
            while (this.mazeCells[randomStartIndex].IsInMaze);

            currentIndex = randomStartIndex;

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

            throw new NotImplementedException();
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
    }
}
