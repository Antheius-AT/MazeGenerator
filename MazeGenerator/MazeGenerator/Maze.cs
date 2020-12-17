//-----------------------------------------------------------------------
// <copyright file="Maze.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace MazeGenerator
{
    using System;

    /// <summary>
    /// Represents a maze consisting of individual cells that each have a walk direction.
    /// </summary>
    public class Maze
    {
        public Maze(int height, int width, MazeCell[] cells)
        {
            if (height < 0 || width < 0)
                throw new ArgumentException($"Height and width must not be negative. Height was: {height}. Width was: {width}");

            this.Height = height;
            this.Width = width;
            this.Cells = cells;
        }

        public int Height
        {
            get;
            private set;
        }

        public int Width
        {
            get;
            private set;
        }

        public MazeCell[] Cells
        {
            get;
            set;
        }
    }
}
