using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPowerUpSpawner : MonoBehaviour
{
    List<PowerUpBase> powerupPrefab = new List<PowerUpBase>();

    // Start is called before the first frame update
    void Start()
    {
        int randomInd = Random.Range(0, powerupPrefab.Count);
        Instantiate(powerupPrefab[randomInd], transform);
    }

}
