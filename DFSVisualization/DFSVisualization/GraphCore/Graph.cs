using System.Collections;
using DFSVisualization.GraphCore.Interfaces;

namespace DFSVisualization.GraphCore;

public class Graph: IGraph, IEnumerable<Node>
{
    private List<Node> _nodes;

    public Graph()
    {
        _nodes = new List<Node>();
    }

    public void AddNode(Node node)
    {
        _nodes.Add(node);
    }

    public void RemoveNode(Node node)
    {
        _nodes = _nodes.Where(n => !n.Equals(node)).ToList();
    }

    public List<Node> DepthFirstSearch()
    {
        var visited = new HashSet<Node>();
        var traversedNodes = new List<Node>();
        DFSRecursive(_nodes.First(), visited, traversedNodes);

        return traversedNodes;
    }

    private void DFSRecursive(Node node, HashSet<Node> visited, List<Node> traversedNodes)
    {
        visited.Add(node);
        traversedNodes.Add(node);

        foreach (var neighbor in node.GetNeighbors())
        {
            if (!visited.Contains(neighbor))
            {
                DFSRecursive(neighbor, visited, traversedNodes);
            }
        }
    }

    public IEnumerator<Node> GetEnumerator()
    {
        foreach (Node node in _nodes)
        {
            yield return node;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}