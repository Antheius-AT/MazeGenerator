//-----------------------------------------------------------------------
// <copyright file="IMazeGenerator.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace MazeGenerator
{
    public interface IMazeGenerator
    {
        /// <summary>
        /// Generates a maze with the specified height and width.
        /// </summary>
        /// <param name="width">The maze width.</param>
        /// <param name="height">The maze height.</param>
        /// <returns>The generated maze.</returns>
        Maze Generate(int width, int height);
    }
}
