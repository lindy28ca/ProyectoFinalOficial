using UnityEngine;
using UnityEngine.InputSystem;

using System;
public class Player : MonoBehaviour
{
    Rigidbody movimientos;
    private Vector2 inputMovimiento;
    private Vector2 ultimoMovimiento;
    public float velocidad;
    public GameObject Prefab;
    public float TiempoDisparo = 1f;
    private float tiempoOficial; 
    private float tiempoUltimoDisparo; 
    public int vida;

    public static event Action Ganar;
    public static event Action Perder;

    private void Awake()
    {
        movimientos = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        tiempoOficial += Time.deltaTime;

        if (vida <= 0)
        {
            Perder?.Invoke();
        }
    }

    public void InputMovimiento(InputAction.CallbackContext context)
    {
        inputMovimiento = context.ReadValue<Vector2>();
        if (inputMovimiento != Vector2.zero)
        {
            ultimoMovimiento = inputMovimiento;
        }
    }

    private void FixedUpdate()
    {
        movimientos.velocity = new Vector3(inputMovimiento.x * velocidad, movimientos.velocity.y, inputMovimiento.y * velocidad);
    }

    public void Disparar(InputAction.CallbackContext context)
    {
        if (context.performed && tiempoOficial >= tiempoUltimoDisparo + TiempoDisparo)
        {
            GameObject go = Instantiate(Prefab, transform.position, transform.rotation);

            go.GetComponent<Bullet>().GenerarBala(ultimoMovimiento);

            tiempoUltimoDisparo = tiempoOficial;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ganaste")
        {
            Ganar?.Invoke();
        }
    }
}
