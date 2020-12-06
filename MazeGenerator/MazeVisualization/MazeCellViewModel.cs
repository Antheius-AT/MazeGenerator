using System;
using System.Collections.Generic;
using System.Text;
using MazeGenerator;

namespace MazeVisualization
{
    public class MazeCellViewModel
    {
        public MazeCellViewModel()
        {

        }

        public MazeCellViewModel(MazeCell cell, int left, int top)
        {
            this.Cell = cell;
            this.Left = left;
            this.Top = top;
            this.Height = 4;
            this.Width = 4;
        }

        public MazeCell Cell
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }

        public int Width
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
