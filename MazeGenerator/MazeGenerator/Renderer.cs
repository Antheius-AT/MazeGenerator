//-----------------------------------------------------------------------
// <copyright file="Renderer.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace MazeGenerator
{
    using System;

    /// <summary>
    /// A renderer capable of rendering individual maze cells.
    /// </summary>
    public class Renderer
    {
        /// <summary>
        /// Renders a single maze cell.
        /// </summary>
        /// <param name="cell">The cell to render.</param>
        public void Render(MazeCell cell)
        {
            // Save default values and write an X. this represents the current cell.
            var initialLeft = Console.CursorLeft;
            var initialTop = Console.CursorTop;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write('X');
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);

            // Based on current direction, navgiate one pixel to left/up/top/down and overwrite the pixel there
            // to a green background. Green background symbol a valid path.
            // If direction is none, write a red X, which symbols the starting point of the random walk.
            switch (cell.WalkDirection)
            {
                case Direction.None:
                    this.RenderDirectionNone();
                    break;
                case Direction.Up:
                    this.RenderDirectionUp();
                    break;
                case Direction.Down:
                    this.RenderDirectionDown();
                    break;
                case Direction.Left:
                    this.RenderDirectionLeft();
                    break;
                case Direction.Right:
                    this.RenderDirectionRight();
                    break;
                default:
                    throw new ArgumentException();
            }

            // Advances cursor by 2, to leave space between 2 cells. Otherwise it would look like there was a valid path 
            // between all the cells in a row, even if that might not be the case.
            Console.SetCursorPosition(initialLeft + 2, initialTop);
            Console.ResetColor();
        }

        private void RenderDirectionUp()
        {
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
            Console.Write(' ');
        }

        private void RenderDirectionDown()
        {
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
            Console.Write(' ');
        }

        private void RenderDirectionRight()
        {
            Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
            Console.Write(' ');
        }

        private void RenderDirectionLeft()
        {
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            Console.Write(' ');
        }

        private void RenderDirectionNone()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write('X');
        }
    }
}
