using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public float spawnTime, repeatTime;
    public GameObject enemy;
    // public GameObject[] enemy;
    public List<Transform> spawnPoints;

    // Use this for initialization
    void Start()
    {

        InvokeRepeating("SpawnEnemy", spawnTime, repeatTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        // for (int i = 0; i < 2; i++)
        //{
        int randSpawnPoint = Random.Range(0, spawnPoints.Count);
        Instantiate(enemy, spawnPoints[randSpawnPoint].position, Quaternion.identity);
        // Instantiate(enemy[i], spawnPoints[randSpawnPoint].position, Quaternion.identity);
        //  }
    }



}
