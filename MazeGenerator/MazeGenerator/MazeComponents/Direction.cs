//-----------------------------------------------------------------------
// <copyright file="Direction.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace MazeGenerator
{
    /// <summary>
    /// Direction enumeration.
    /// </summary>
    public enum Direction
    {
        /// <summary>
        /// Represents a null walk direction. Found on the starting cell.
        /// </summary>
        None,

        /// <summary>
        /// Represents an up walk direction.
        /// </summary>
        Up,

        /// <summary>
        /// Represent a down walk direction.
        /// </summary>
        Down,

        /// <summary>
        /// Represents a left walk direction.
        /// </summary>
        Left,

        /// <summary>
        /// Represents a right walk direction.
        /// </summary>
        Right
    }
}
