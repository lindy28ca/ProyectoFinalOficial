using UnityEngine;
using System;
public class PoderVelocidad : PowerUp
{
    public static event Action<float> powerUp;

    protected override void TriggerPowerUp()
    {
        powerUp?.Invoke(tiempo);
    }

}
