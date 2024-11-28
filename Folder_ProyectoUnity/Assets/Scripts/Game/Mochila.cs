using UnityEngine;
public class Mochila : MonoBehaviour
{
    ListaSimple<string> listaSimple;
    public ListaSimple<string> ListaSimple { get { return listaSimple; } set { listaSimple = value; } }

    private void Start()
    {
        listaSimple = new ListaSimple<string>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Objetos")
        {
            listaSimple.InsertAtEnd(other.gameObject.name);
            Destroy(other.gameObject);  
        }
    }
    
}
