using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MazeGenerator;
using NUnit.Framework;

namespace MazeUnitTests
{
    public class Tests
    {
        private DefaultMazeGenerator generator;
        private Renderer renderer;

        [SetUp]
        public void Setup()
        {
            this.generator = new DefaultMazeGenerator();
            this.renderer = new Renderer();
        }

        [Test]
        [TestCase(10, 10)]
        [TestCase(20, 5)]
        [TestCase(100, 200)]
        [TestCase(53, 41)]
        public void Does_Generator_GenerateMaze_WithCorrectAmountofCells(int height, int width)
        {
            var maze = this.generator.Generate(width, height);

            Assert.True(maze.Cells.Length == height * width);
        }

        [Test]
        [TestCase(-5, 20)]
        [TestCase(-5, -1)]
        [TestCase(5, -2)]
        public void Does_Generator_ThrowExceptionIf_HeightOrWidthNegative(int height, int width)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                this.generator.Generate(width, height);
            });
        }

        [Test]
        [TestCase(10, 10)]
        [TestCase(4, 4)]
        [TestCase(100, 100)]
        [TestCase(23, 13)]
        public void Is_Generated_Maze_Valid(int height, int width)
        {
            var maze = this.generator.Generate(width, height);
            var visited = new List<MazeCell>();

            // If anything is not reachable it won`t show up in the graph, which means I can take a look
            // at the cells in the graph and compare them agains the cells in the maze itself.
            var graph = Helpers.ConvertToGraph(maze);

            foreach (var item in graph.Cells.Distinct())
            {
                visited.Add(item);
            }

            if (visited.Count != maze.Cells.Length)
                Assert.Fail();

            for (int i = 0; i < visited.Count; i++)
            {
                if (!visited.Contains(maze.Cells[i]))
                    Assert.Fail();
            }

            Assert.Pass();
        }

        [Test]
        [TestCase(5, 5)]
        [TestCase(10, 10)]
        [TestCase(66, 33)]
        [TestCase(100, 100)]
        public void Is_MazetoGraphConvertion_Functional(int width, int height)
        {
            var maze = this.generator.Generate(width, height);

            var graph = Helpers.ConvertToGraph(maze);

            if (graph.Cells.Count != maze.Cells.Length)
                Assert.Fail();

            // The idea here is to create a list and then take a look at all the edges in the graph, 
            // and storing the nodes that are connected by these graphs in the list.
            // Afterwards I can check whether the maze cells and the cells in the control list are the same (they should be).
            var control = new List<MazeCell>();

            foreach (var item in graph.Edges)
            {
                control.Add(item.First);
                control.Add(item.Second);
            }

            control = control.Distinct().ToList();

            for (int i = 0; i < control.Count; i++)
            {
                if (!control.Contains(maze.Cells[i]))
                    Assert.Fail();
            }

            Assert.Pass();
        }
    }
}