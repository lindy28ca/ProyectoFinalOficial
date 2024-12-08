using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Collections;
using Unity.Mathematics;
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

    public float aceleracion;
    public float aceleracioninicial;
    private bool mRUV;

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
        if(mRUV)
        {
            aceleracioninicial += Time.deltaTime;
        }
        else
        {
            aceleracioninicial -= Time.deltaTime;
        }
        aceleracioninicial = math.clamp(aceleracioninicial, 1, aceleracion);

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
        movimientos.velocity = new Vector3(inputMovimiento.x * velocidad*aceleracioninicial, movimientos.velocity.y, inputMovimiento.y * velocidad*aceleracioninicial);
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
    private void MRUV(float tiempo)
    {
        StartCoroutine(TiempoMRUV(tiempo));
    }
    private IEnumerator TiempoMRUV(float tiempo)
    {
        mRUV = true;
        yield return new WaitForSeconds(tiempo);
        mRUV = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ganaste")
        {
            Ganar?.Invoke();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="BalaEnemy")
        {
            --vida;
        }
    }
    private void OnEnable()
    {
        PoderVelocidad.powerUp += MRUV;
    }
    private void OnDisable()
    {
        PoderVelocidad.powerUp -= MRUV;
    }
}
