using DFSVisualization.GraphCore;
using DFSVisualization.Maze.Interfaces;

namespace DFSVisualization.Maze;

public class MazeBuilder : IMazeBuilder
{
    private Graph graph;
    public Node[,] Nodes { get; set; }
    private int n;
    private HashSet<(int, int)> _obstaclesCoords;
    public MazeBuilder(int n, Graph graph)
    {
        _obstaclesCoords = new HashSet<(int, int)>();
        this.n = n;
        Nodes = new Node[n, n];
        this.graph = graph;
        CreateNodes();
    }

    private void CreateNodes()
    {
        int nodeNumber = 1;
        Random random = new Random();
        for (int i = n - 1; i >= 0; i--)
        {
            for (int j = 0; j < n; j++)
            {
                int randomNumber = random.Next(100);

                if (randomNumber <= 70)
                {
                    Nodes[i, j] = new Node(nodeNumber, (i, j), false);
                }
                else
                {
                    Nodes[i, j] = new Node(nodeNumber, (i, j), true);
                    _obstaclesCoords.Add((i, j));
                }

                graph.AddNode(Nodes[i, j]);
                nodeNumber++;
            }
        }
    }
    public void CreateMaze()
    {

        if (Nodes is null)
        {
            return;
        }

        for (int i = n - 1; i >= 0; i--)
        {
            for (int j = 0; j < n; j++)
            {

                if (i == 0 && j == n - 1)
                {
                    return;
                }

                if (i == 0)
                {
                    Nodes[i, j].AddNeighbor(Nodes[i, j + 1]);
                }
                else if (j == n - 1)
                {
                    Nodes[i, j].AddNeighbor(Nodes[i - 1, j]);
                }
                else
                {
                    Nodes[i, j].AddNeighbor(Nodes[i - 1, j + 1]);
                    Nodes[i, j].AddNeighbor(Nodes[i, j + 1]);
                    Nodes[i, j].AddNeighbor(Nodes[i - 1, j]);
                }
            }
        }
    }

    public void DrawMaze(List<Node> traversedNodes)
    {
        if (Nodes is null)
        {
            return;
        }

        var positions = traversedNodes.Select(n => n.Pos).ToArray();
        Queue<(int, int)> queue = new Queue<(int, int)>();

        int count = -1;


        foreach (var valueTuple in positions)
        {
            queue.Enqueue(valueTuple);
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (_obstaclesCoords.Contains((i, j)))
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("██");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("██");
                    Console.ResetColor();
                }

            }
            Console.WriteLine();
        }

        foreach (var point in queue)
        {
            Thread.Sleep(50);
            Console.SetCursorPosition(point.Item2 * 2, n - 1 - point.Item1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("██");
        }

        Console.ResetColor();
    }
}