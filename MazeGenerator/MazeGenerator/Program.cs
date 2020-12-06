using System;
using System.Linq;

namespace MazeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 40;
            int height = 40;

            var generator = new DefaultMazeGenerator();
            var maze = generator.Generate(width, height);

            //for (int i = 0; i < height; i++)
            //{
            //    for (int j = 0; j < width; j++)
            //    {
            //        Console.Write(maze.Cells[j + i * width].WalkDirection.ToString().First());
            //    }

            //    Console.WriteLine();
            //}

            Console.ReadLine();
        }
    }
}
