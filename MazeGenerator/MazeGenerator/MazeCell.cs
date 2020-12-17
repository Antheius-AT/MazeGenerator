//-----------------------------------------------------------------------
// <copyright file="MazeCell.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace MazeGenerator
{
    /// <summary>
    /// Represent a single maze cell.
    /// </summary>
    public class MazeCell
    {
        public MazeCell(Direction walkDirection = Direction.None)
        {
            this.WalkDirection = walkDirection;
            this.IsInMaze = false;
        }

        public Direction WalkDirection
        {
            get;
            set;
        }

        public bool IsInMaze
        {
            get;
            set;
        }

        public override string ToString()
        {
            return $"Is in maze:{this.IsInMaze}, direction to next cell:{this.WalkDirection}";
        }
    }
}
