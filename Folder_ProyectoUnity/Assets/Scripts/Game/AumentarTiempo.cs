using UnityEngine;
using System;
public class AumentarTiempo : PowerUp
{
    public static event Action<float> aumentarTiempo;

    protected override void TriggerPowerUp()
    {
        aumentarTiempo?.Invoke(-tiempo);
    }
}
