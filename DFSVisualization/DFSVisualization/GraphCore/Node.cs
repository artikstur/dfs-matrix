
using DFSVisualization.GraphCore.Interfaces;

namespace DFSVisualization.GraphCore;

public class Node: INode, IComparable<Node>
{
    public int Number { get; private set; }
    private List<Node> _neighbors;
    public (int, int) Pos { get; private set; }
    public bool IsObstacle { get; set; }

    public Node(int number, (int, int) pos, bool isObstacle)
    {
        Number = number;
        _neighbors = new List<Node>();
        this.Pos = pos;
        IsObstacle = isObstacle;
    }

    public void AddNeighbor(Node node)
    {
        if (!_neighbors.Contains(node))
        {
            _neighbors.Add(node);
        }
        else
        {
            Console.WriteLine("Данные вершины уже связаны");
        }
    }

    public void RemoveAddNeighbor(Node node)
    {
        if (!_neighbors.Contains(node))
        {
            _neighbors = _neighbors.Where(n => n.Equals(node)).ToList();
        }
        else
        {
            Console.WriteLine("Данные вершины не связаны");
        }
    }

    public int CompareTo(Node? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        return Number.CompareTo(other.Number);
    }

    public void ShowNeighbors()
    {
        foreach (var neighbor in _neighbors)
        {
            Console.Write(neighbor.ToString());
        }
    }

    public List<Node> GetNeighbors()
    {
        return _neighbors;
    }

    public override string ToString()
    {
        return Number.ToString();
    }
}