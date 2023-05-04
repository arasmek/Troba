using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnLocations;
    public int[] enemyCountsPerWave;

    private int currentWave = 0;
    private bool isWaveInProgress = false;
    private bool isWaitingForNextWave = false;

    void Start()
    {
        
    }

    void Update()
    {
        //if (isWaitingForNextWave && GameObject.FindWithTag("Enemy") == null)
        //{
        //    isWaitingForNextWave = false;
        //    StartNextWave();
        //}
    }

    public void StartNextWave()
    {
        if (isWaveInProgress || currentWave >= enemyCountsPerWave.Length)
        {
            // A wave is already in progress, or there are no more waves
            return;
        }

        isWaveInProgress = true;

        // Spawn enemies for the current wave
        int enemyCount = enemyCountsPerWave[currentWave];
        StartCoroutine(SpawnEnemies(enemyCount));

        currentWave++;
    }

    IEnumerator SpawnEnemies(int enemyCount)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            int spawnIndex = Random.Range(0, spawnLocations.Length);
            Instantiate(enemyPrefabs[enemyIndex], spawnLocations[spawnIndex].position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }

        isWaveInProgress = false;
        isWaitingForNextWave = true;
    }
}
