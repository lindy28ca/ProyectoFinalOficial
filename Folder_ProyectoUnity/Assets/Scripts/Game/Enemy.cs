using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 positionToMove;
    public float speedMove;
    public int vida;
    public GameObject PrefabBala; 
    [SerializeField] private float tiempoDisparo = 2f; 
    private float tiempoUltimoDisparo = 0f; 

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, positionToMove, speedMove * Time.deltaTime);

        if (vida <= 0)
        {
            Destroy(gameObject);
        }

        if (Time.time >= tiempoUltimoDisparo + tiempoDisparo)
        {
            Disparar();
            tiempoUltimoDisparo = Time.time;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Node"))
        {
            SetNewPosition(other.GetComponent<NodeControl>().GetAdjacentNode().transform.position);
        }

        if (other.gameObject.CompareTag("Bala"))
        {
            --vida;
        }
    }

    public void SetNewPosition(Vector3 newPosition)
    {
        positionToMove = newPosition;
    }

    private void Disparar()
    {
        GameObject bala = Instantiate(PrefabBala, transform.position, Quaternion.identity);

        Vector3 direccionDisparo = (positionToMove - transform.position).normalized;

        bala.GetComponent<Bullet>().GenerarBala(new Vector2(direccionDisparo.x, direccionDisparo.z));
    }
}
