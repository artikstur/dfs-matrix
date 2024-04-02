using DFSVisualization.GraphCore;
using DFSVisualization.Maze;

namespace DFSVisualization;

class Program
{
    static void Main()
    {
        Graph graph = new Graph();

        MazeBuilder mazeBuilder = new MazeBuilder(20, graph);
        mazeBuilder.CreateMaze();

        var res = graph.DepthFirstSearch();

        mazeBuilder.DrawMaze(res);
    }
}