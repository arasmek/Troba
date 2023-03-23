using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 1.0f;
    public float spawnTimer = 0.0f;

    // Start is called before the first frame update
    //void Start()
    //{
    //    SpawnEnemy();
    //}

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnRate)
        {
            SpawnEnemy();
            spawnTimer = 0.0f;
        }
    }
    void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}