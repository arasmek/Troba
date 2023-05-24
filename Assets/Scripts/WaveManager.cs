using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnLocations;
    public int[] enemyCountsPerWave;

    public int currentWave = 0;
    private bool isWaveInProgress = false;
    //private bool isWaitingForNextWave = false;
    public TextMeshProUGUI EnemyCountText;
    int EnemyCounter = 0;
    int PreviousEnemyCount = 0;
    int CurrentEnemyCount = 0;
    

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
        if (isWaveInProgress && EnemyCounter != 0)
        {          
            // A wave is already in progress, or there are no more waves
            return;
        }
        PreviousEnemyCount = CurrentEnemyCount;

        isWaveInProgress = true;
        CurrentEnemyCount = CreateWave(PreviousEnemyCount);
        currentWave++;
    }
    public int CreateWave(int previous)
    {
        int enemyCount;
        if(previous == 0) 
        {  
            enemyCount = 3;
        }
        else 
        {
            enemyCount = previous + Random.Range(-2, 5);
        }
        StartCoroutine(SpawnEnemies(enemyCount));
        return enemyCount;
    }

    IEnumerator SpawnEnemies(int enemyCount)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            int spawnIndex = Random.Range(0, spawnLocations.Length);
            Instantiate(enemyPrefabs[enemyIndex], spawnLocations[spawnIndex].position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }

        isWaveInProgress = false;
    }
}
