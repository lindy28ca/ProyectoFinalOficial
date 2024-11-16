using UnityEngine;
using DG.Tweening;
public class Centro : MonoBehaviour
{
    public Ease curva;
    public float velocidad;
    RectTransform rectTransform;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        rectTransform.DOAnchorPos(Vector2.zero,velocidad).SetEase(curva);
    }
}
