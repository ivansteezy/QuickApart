using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public List<GameObject> spawnees;

    public float spawnTime = 2.5f;

    void Start()
    {
        
    }

    void Update()
    {
        spawnTime -= Time.deltaTime;
        if(spawnTime <= 0)
        {
            int randSpawnee = Random.Range(0, spawnees.Count);
            Instantiate(spawnees[randSpawnee], spawnPoints[0].position, transform.rotation);

            spawnTime = 2.5f;
        }
    }
}
