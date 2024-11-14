using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    
    Rigidbody movimientos;
    private Vector2 inputMovimiento;
    private Vector2 ultimoMovimiento;
    public float velocidad;
    [SerializeField] private GameObject Prefab;
    public int vida;

    private void Awake()
    {
        movimientos = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (vida <= 0)
        {
            GameManager.Instance.CargarScena("GameOver");
        }
    }
    public void InputMovimiento(InputAction.CallbackContext context)
    {
        inputMovimiento=context.ReadValue<Vector2>();
        if(inputMovimiento != Vector2.zero)
        {
            ultimoMovimiento = inputMovimiento;
        }
    }
    private void FixedUpdate()
    {
        movimientos.velocity=new Vector3 (inputMovimiento.x*velocidad,movimientos.velocity.y,inputMovimiento.y*velocidad);
    }
    public void Disparar(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameObject go= Instantiate(Prefab,transform.position, transform.rotation);
            go.GetComponent<Bullet>().GenerarBala(ultimoMovimiento);
        }
    }
}
