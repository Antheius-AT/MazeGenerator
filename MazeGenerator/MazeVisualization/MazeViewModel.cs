using System;
using System.Collections.Generic;
using System.Text;
using MazeGenerator;

namespace MazeVisualization
{
    public class MazeCellViewModel
    {
        public MazeCellViewModel(MazeCell cell, int left, int top)
        {
            this.Cell = cell;
            this.Left = left;
            this.Top = top;
        }

        public MazeCell Cell
        {
            get;
            set;
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
