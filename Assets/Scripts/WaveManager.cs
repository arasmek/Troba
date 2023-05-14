using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnLocations;
    public int[] enemyCountsPerWave;

    private int currentWave = 0;
    private bool isWaveInProgress = false;
    //private bool isWaitingForNextWave = false;
    public TextMeshProUGUI EnemyCountText;
    int EnemyCounter = 0;
    
    // Counts the amount of enemies on every update
    void Update()
    {
        EnemyCounter = 0;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        EnemyCounter += enemies.Length;
        enemies = GameObject.FindGameObjectsWithTag("Enemy2");
        EnemyCounter += enemies.Length;
        enemies = GameObject.FindGameObjectsWithTag("Enemy3");
        EnemyCounter += enemies.Length;
        EnemyCountText.text = EnemyCounter.ToString();
        
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
        EnemyCounter = enemyCount;
        EnemyCountText.text = EnemyCounter.ToString();
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
        //isWaitingForNextWave = true;
    }
}
