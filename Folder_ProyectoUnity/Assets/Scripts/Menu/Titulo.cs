using UnityEngine;
using DG.Tweening;
public class Titulo : MonoBehaviour
{
    public Ease curva;
    public float velocidad;
    public RectTransform position;
    RectTransform rectTransform;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        rectTransform.DOAnchorPos(position.position,velocidad).SetEase(curva);
    }
}
