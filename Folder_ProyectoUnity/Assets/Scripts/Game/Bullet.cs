using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody movimientos;
    [SerializeField] private float Velocidad;
    private Vector2 direccion;
    private void Awake()
    {
        movimientos = GetComponent<Rigidbody>();
    }
    public void GenerarBala(Vector2 direccion)
    {
        this.direccion = direccion;
    }
    private void FixedUpdate()
    {
        movimientos.velocity=new Vector3(direccion.x*Velocidad,movimientos.velocity.y,direccion.y*Velocidad);
       
    }
   
}
