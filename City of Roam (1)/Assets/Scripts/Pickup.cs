using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private PowerUpBase PowerUp;

    public void Init(PowerUpBase power)
    {
        PowerUp = power;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            PowerUp.Apply(player);
            Destroy(gameObject);
        }
    }
}
