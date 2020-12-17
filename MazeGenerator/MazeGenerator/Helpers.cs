//-----------------------------------------------------------------------
// <copyright file="Helpers.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MazeGenerator
{
    /// <summary>
    /// Helpers class for maze generation.
    /// </summary>
    public static class Helpers
    {
        public static Graph ConvertToGraph(Maze maze)
        {
            var edges = new List<Edge>();

            // This method loops through all of the maze cells, and takes a look at the cells direction.
            // Then, depending on the direction, it adds the current cell, and its neighboring cell, to the result
            // and connects them by an edge.
            for (int i = 0; i < maze.Cells.Length; i++)
            {
                switch (maze.Cells[i].WalkDirection)
                {
                    case Direction.None:
                        edges.Add(new Edge(maze.Cells[i], GetAdjacentCell(maze, i)));
                        break;
                    case Direction.Up:
                        edges.Add(new Edge(maze.Cells[i], maze.Cells[i - maze.Width]));
                        break;
                    case Direction.Down:
                        edges.Add(new Edge(maze.Cells[i], maze.Cells[i + maze.Width]));
                        break;
                    case Direction.Left:
                        edges.Add(new Edge(maze.Cells[i], maze.Cells[i - 1]));
                        break;
                    case Direction.Right:
                        edges.Add(new Edge(maze.Cells[i], maze.Cells[i + 1]));
                        break;
                    default:
                        throw new ArgumentException();
                }
            }

            return new Graph(maze.Cells.ToList(), edges);
        }

        private static MazeCell GetAdjacentCell(Maze maze, int index)
        {
            if (index - 1 > 0 && maze.Cells[index - 1].WalkDirection == Direction.Right)
                return maze.Cells[index - 1];
            else if (index + 1 < maze.Cells.Length && maze.Cells[index + 1].WalkDirection == Direction.Left)
                return maze.Cells[index + 1];
            else if (index - maze.Width > 0 && maze.Cells[index - maze.Width].WalkDirection == Direction.Down)
                return maze.Cells[index - maze.Width];
            else if (index + maze.Width < maze.Cells.Length && maze.Cells[index + maze.Width].WalkDirection == Direction.Up)
                return maze.Cells[index + maze.Width];
            else
                throw new ArgumentException();
        }
    }
}
