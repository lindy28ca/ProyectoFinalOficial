using DG.Tweening;
using UnityEngine;

public class Paneles : MonoBehaviour
{
    private RectTransform rectTransform;
    public float velocidad;
    public Ease curva;
    public Vector3 comenzar;
    public Vector3 finalizar;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void Comenzar()
    {
        rectTransform.DOAnchorPos(finalizar, velocidad).SetEase(curva);
    }
    public void Regresar()
    {
        rectTransform.DOAnchorPos(comenzar, velocidad).SetEase(curva);
    }
}
