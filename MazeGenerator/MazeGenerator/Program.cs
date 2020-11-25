using System;

namespace MazeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new DefaultMazeGenerator();
            generator.Generate(4, 4);
        }
    }
}
