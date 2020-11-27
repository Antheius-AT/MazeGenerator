using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGenerator
{
    public class MazeWall
    {
        public MazeWall(int left, int top)
        {
            this.Left = left;
            this.Top = top;
        }

        public int Left
        {
            get;
            set;
        }

        public int Top
        {
            get;
            set;
        }
    }
}
