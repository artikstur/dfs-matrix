namespace DFSVisualization.GraphCore.Interfaces;

public interface IGraph
{
    void AddNode(Node node);
    void RemoveNode(Node node);
    List<Node> DepthFirstSearch();
}