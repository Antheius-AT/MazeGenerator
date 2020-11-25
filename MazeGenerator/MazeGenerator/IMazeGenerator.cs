using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGenerator
{
    public interface IMazeGenerator
    {
        Maze Generate(int width, int height);
    }
}
