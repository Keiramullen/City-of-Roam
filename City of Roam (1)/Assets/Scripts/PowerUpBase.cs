using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    [SerializeField]
    private Pickup InWorldPickUpPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        Pickup instance = Instantiate(InWorldPickUpPrefab, transform);
        instance.Init(this);
    }

    public abstract void Apply(PlayerController player);
}
