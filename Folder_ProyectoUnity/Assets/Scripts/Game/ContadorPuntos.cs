using UnityEngine;
using TMPro;
public class ContadorPuntos : MonoBehaviour
{
    TMP_Text TMP_Text;
    float puntos;
    private void Awake()
    {
        TMP_Text=GetComponent<TMP_Text>();  
    }
    private void Update()
    {
        TMP_Text.text=puntos.ToString();
    }
    public void AumentarPuntos()
    {
        puntos++;
    }
    private void OnEnable()
    {
        Enemy.muerto += AumentarPuntos;
    }
    private void OnDisable()
    {
        Enemy.muerto -= AumentarPuntos;
    }
}

