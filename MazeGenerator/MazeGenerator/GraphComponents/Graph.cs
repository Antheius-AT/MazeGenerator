//-----------------------------------------------------------------------
// <copyright file="Graph.cs" company="FHWN">
//     Copyright (c) FHWN. All rights reserved.
// </copyright>
// <author>Gregor Faiman</author>
//-----------------------------------------------------------------------
namespace MazeGenerator
{
    using System.Collections.Generic;

    public class Graph
    {
        public Graph(List<MazeCell> cells, List<Edge> edges)
        {
            this.Cells = cells;
            this.Edges = edges;
        }

        public List<MazeCell> Cells
        {
            get;
            set;
        }

        public List<Edge> Edges
        {
            get;
            set;
        }
    }
}
