using UnityEngine;

public class Puerta : MonoBehaviour
{

    public static bool operator ==(Puerta puerta, string llave)
    {
        if (puerta.gameObject.name == llave)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool operator !=(Puerta puerta, string llave)
    {
        if (puerta.gameObject.name != llave)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Confirmar(collision.gameObject.GetComponent<Mochila>().ListaSimple);
        }
    }

    private void Confirmar(ListaSimple<string> lista)
    {
        for(int i = 0; i < lista.ObtenerValor(); ++i)
        {
            if (this == lista.GetAtPosition(1))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
