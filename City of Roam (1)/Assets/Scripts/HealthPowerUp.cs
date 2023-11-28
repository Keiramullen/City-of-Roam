using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : PowerUpBase
{
    [SerializeField]
    private float Health;

    public override void Apply(PlayerController player)
    {
        player.AddHealth(Health);
        Destroy(gameObject);
    }
}
