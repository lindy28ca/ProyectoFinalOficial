using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Vector3 positionToMove;
    public float speedMove;
    public int vida;
    private NavMeshAgent agentito;
    public GameObject PrefabBala;
    [SerializeField] private float tiempoDisparo = 2f; 
    private float tiempoUltimoDisparo = 0f;

    private Transform jugador; 
    [SerializeField] private float rangoDeteccion = 10f;
    public static event Action muerto;
    private void Awake()
    {
        agentito = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (jugador != null)
        {
            float distanciaJugador = Vector3.Distance(transform.position, jugador.position);

            if (distanciaJugador <= rangoDeteccion)
            {
                agentito.destination = jugador.position;

                if (Time.time - tiempoUltimoDisparo >= tiempoDisparo)
                {
                    Disparar(jugador.position);
                    tiempoUltimoDisparo = Time.time;
                }
            }
            else
            {
                agentito.destination = positionToMove;
            }
        }
        else
        {
            agentito.destination = positionToMove;
        }

        if (vida <= 0)
        {
            Destroy(gameObject);
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
            Debug.Log("Me disparaste");
        }

        if (other.gameObject.CompareTag("Player"))
        {
            jugador = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            jugador = null;
        }
    }

    public void SetNewPosition(Vector3 newPosition)
    {
        positionToMove = newPosition;
    }

    private void Disparar(Vector3 targetPosition)
    {
        GameObject bala = Instantiate(PrefabBala, transform.position, Quaternion.identity);

        Vector3 direccionDisparo = (targetPosition - transform.position).normalized;

        bala.GetComponent<Bullet>().GenerarBala(new Vector2(direccionDisparo.x, direccionDisparo.z));
    }
    private void OnDestroy()
    {
        muerto?.Invoke();
    }
}
