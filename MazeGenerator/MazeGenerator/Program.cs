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

            PrintMaze(maze);

            Console.ReadLine();
        }

        private static void PrintMaze(Maze maze)
        {
            Console.SetCursorPosition(1, 0);

            for (int rows = 0; rows < maze.Height; rows++)
            {
                for (int column = 0; column < maze.Width; column++)
                {
                    var currentCell = maze.Cells[column + rows * column];
                    PrintMazeCell(currentCell);
                    Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop);
                }

                Console.WriteLine();
                Console.SetCursorPosition(1, rows);
            }
        }

        private static void PrintMazeCell(MazeCell cell)
        {
            var initialLeft = Console.CursorLeft;
            var initialTop = Console.CursorTop;

                Console.Write('X');
                Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop + 1);
                Console.Write('X');
                Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                Console.Write('X');
                Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop + 1);
            Console.Write('X');

            switch (cell.WalkDirection)
            {
                case Direction.Up:
                    Console.SetCursorPosition(initialLeft, initialTop);
                    PrintInColor(' ', ConsoleColor.Green);
                    break;
                case Direction.Down:
                    Console.SetCursorPosition(initialLeft, initialTop + 2);
                    PrintInColor(' ', ConsoleColor.Green);
                    break;
                case Direction.Left:
                    Console.SetCursorPosition(initialLeft - 1, initialTop + 1);
                    break;
                case Direction.Right:
                    Console.SetCursorPosition(initialLeft + 1, initialTop + 1);
                    PrintInColor(' ', ConsoleColor.Green);
                    break;
                default:
                    break;
            }

            Console.SetCursorPosition(initialLeft, initialTop);
        }

        private static void PrintInColor(char character, ConsoleColor color)
        {
            Console.BackgroundColor = color;
            Console.Write(character);
            Console.ResetColor();
        }
    }
}
