namespace DFSVisualization.GraphCore.Interfaces;

public interface INode
{
    void AddNeighbor(Node node);
    void RemoveAddNeighbor(Node node);
    void ShowNeighbors();
    List<Node> GetNeighbors();

}