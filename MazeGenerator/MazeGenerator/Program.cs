using System;

namespace MazeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Remember default values.
            var initialHeight = Console.WindowHeight;
            var initialWidth = Console.WindowWidth;
            var initialBufferWidth = Console.BufferWidth;
            var initialBufferHeight = Console.BufferHeight;

            // Parameterize Console.
            Console.SetWindowSize(Console.LargestWindowWidth - 2, Console.LargestWindowHeight - 2);
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);

            // Set maze parameters.
            int width = 10;
            int height = 10;

            var renderer = new Renderer();
            var generator = new DefaultMazeGenerator();
            var maze = generator.Generate(width, height);

            Console.SetCursorPosition(5, 5);
            var initialLeft = 5;

            // Render each cell. If index equals a multiple of width, continue in next row.
            for (int i = 0; i < maze.Cells.Length; i++)
            {
                if (i != 0 && i % maze.Width == 0)
                    Console.SetCursorPosition(initialLeft, Console.CursorTop + 2);

                renderer.Render(maze.Cells[i]);
            }

            // Wait for input and reset values.
            Console.ReadKey();
            Console.SetWindowSize(initialWidth, initialHeight);
            Console.SetBufferSize(initialBufferWidth, initialBufferHeight);
        }
    }
}
