//-----------------------------------------------------------------------
// <copyright file="Edge.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace MazeGenerator
{
    public class Edge
    {
        public Edge(MazeCell first, MazeCell second)
        {
            this.First = first;
            this.Second = second;
        }

        public MazeCell First
        {
            get;
            set;
        }

        public MazeCell Second
        {
            get;
            set;
        }
    }
}
