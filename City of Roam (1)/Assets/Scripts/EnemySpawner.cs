using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemyPrefabs; 
    [SerializeField]
    private float spawnMinTime;
    [SerializeField]
    private float spawnMaxTime;


    private float nextSpawnTime; 

    void Start()
    {

        nextSpawnTime = Random.Range(spawnMinTime, spawnMaxTime) + Time.time;
    }
    void Update()
    {
        if (nextSpawnTime <= Time.time)
        {
            int randomEnemyIndex = Random.Range(0, enemyPrefabs.Count);
            Instantiate(enemyPrefabs[randomEnemyIndex], transform);
            nextSpawnTime = Random.Range(spawnMinTime, spawnMaxTime) + Time.time;
        }
    }
}
