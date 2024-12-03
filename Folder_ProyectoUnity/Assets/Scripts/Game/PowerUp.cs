using UnityEngine;
using System;
abstract public class PowerUp : MonoBehaviour
{
    public float tiempo;

    protected abstract void TriggerPowerUp();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerPowerUp();
            Destroy(gameObject); 
        }
    }
}
