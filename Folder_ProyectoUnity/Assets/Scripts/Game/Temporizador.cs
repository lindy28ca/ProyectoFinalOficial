using UnityEngine;
using TMPro;
using System;

public class Temporizador : MonoBehaviour
{
    TMP_Text text;
    private float tiempo;
    public float tiempoGameover;

    public static event Action Perder;
    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }
    private void Update()
    {
        tiempo += Time.deltaTime;
        text.text = "" + (int)tiempo;
        if( tiempo > tiempoGameover)
        {
            Perder?.Invoke();
        }
    }
}
