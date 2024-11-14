using UnityEngine;

public class NodeControl : MonoBehaviour
{
    private ListaCircular<NodeControl> listAdjacentNodes = new ListaCircular<NodeControl>();
    public void AddAdjacentNode(NodeControl adjacentNode)
    {
        listAdjacentNodes.AgregarAlFinal(adjacentNode);
    }
    public NodeControl GetAdjacentNode()
    {
        return listAdjacentNodes.OptenerEnPosicion(Random.Range(0, listAdjacentNodes.count));
    }
}
