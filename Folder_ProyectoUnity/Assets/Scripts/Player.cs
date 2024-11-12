using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody movimientos;
    private Vector2 inputMovimiento;
    public float velocidad;
    private void Awake()
    {
        movimientos = GetComponent<Rigidbody>();
    }
    public void InputMovimiento(InputAction.CallbackContext context)
    {
        inputMovimiento=context.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        movimientos.velocity=new Vector3 (inputMovimiento.x*velocidad,movimientos.velocity.y,inputMovimiento.y*velocidad);
    }

}
