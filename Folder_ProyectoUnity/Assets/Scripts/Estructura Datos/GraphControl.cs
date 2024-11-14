using UnityEngine;

public class GraphControl:MonoBehaviour
{
    private ListaCircular<NodeControl> listAllNodes = new ListaCircular<NodeControl>();
    public TextAsset textNodesPositions;
    public string[] arrayNodeRowsPositions;
    public string[] arrayNodeColumnsPositions;
    public GameObject objectNodePrefab;
    public TextAsset textNodesConnections;
    public string[] arrayNodeRowsConnections;
    public string[] arrayNodeColumnsConnections;
    public Enemy currentEnemy;

    private void Start()
    {
        DrawNodes();
        ConnectNodes();
        SetInitialNode();
    }

    public void DrawNodes()
    {
        GameObject currentNode;
        arrayNodeRowsPositions = textNodesPositions.text.Split('\n');

        for (int i = 0; i < arrayNodeRowsPositions.Length; ++i)
        {
            arrayNodeColumnsPositions = arrayNodeRowsPositions[i].Split(';');

            Vector3 positionToCreate = new Vector3(
                float.Parse(arrayNodeColumnsPositions[0]),
                float.Parse(arrayNodeColumnsPositions[1]),
                float.Parse(arrayNodeColumnsPositions[2])
            );

            currentNode = Instantiate(objectNodePrefab, positionToCreate, transform.rotation);
            currentNode.name = "NODE" + i.ToString();

            listAllNodes.AgregarAlFinal(currentNode.GetComponent<NodeControl>());
        }
    }

    private void ConnectNodes()
    {
        arrayNodeRowsConnections = textNodesConnections.text.Split("\n");

        for (int i = 0; i < listAllNodes.count; ++i)
        {
            arrayNodeColumnsConnections = arrayNodeRowsConnections[i].Split(";");

            for (int j = 0; j < arrayNodeColumnsConnections.Length; ++j)
            {
                listAllNodes.OptenerEnPosicion(i).AddAdjacentNode(
                    listAllNodes.OptenerEnPosicion(int.Parse(arrayNodeColumnsConnections[j])));
            }
        }
    }
    private void SetInitialNode()
    {
        currentEnemy.SetNewPosition(listAllNodes.OptenerEnPosicion(0).gameObject.transform.position);
    }


}
