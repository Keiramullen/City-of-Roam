using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityPowerUp : PowerUpBase
{
    [SerializeField]
    private float time;

    private float startTime;
    private Collider2D playerCollider;
    private float invincibleTime;
    
    public override void Apply(PlayerController player)
    {
        
        startTime = Time.time;
        playerCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime > time)
        {
            playerCollider.enabled = true;
            Destroy(gameObject);
        }
    }
}
