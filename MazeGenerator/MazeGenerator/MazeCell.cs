using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGenerator
{
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
