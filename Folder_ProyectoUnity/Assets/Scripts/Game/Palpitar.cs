using UnityEngine;
using DG.Tweening;

public class Palpitar : MonoBehaviour
{
    public float duration = 0.5f; 
    public float targetScale = 0.9f; 

    private void Start()
    {
        Parpadear();
    }

    private void Parpadear()
    {
        transform.DOScale(targetScale, duration).SetLoops(-1, LoopType.Yoyo);
    }
}