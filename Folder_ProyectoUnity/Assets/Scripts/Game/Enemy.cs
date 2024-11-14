using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 positionToMove;
    public float speedMove;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, positionToMove, speedMove * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag=="Node")
        {
            SetNewPosition(other.GetComponent<NodeControl>().GetAdjacentNode().transform.position);
        }
    }
    public void SetNewPosition(Vector3 newPosition)
    {
        positionToMove = newPosition;
    }
}
