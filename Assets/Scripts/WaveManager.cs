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
    public TextMeshProUGUI WaveInfo;
    public int WaveType = 0;
    private Dictionary<int, string> waveTypeNames = new Dictionary<int, string>()
    {
        { 0, "Default" },
        { 1, "Fast enemies" },
        { 2, "Tough enemies" },
        { 3, "Strong enemies" }
    };
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
            enemyCount = previous + Random.Range(0, 5);

            if((currentWave + 1) % 3 == 0) 
            {
                WaveType = Random.Range(1, 4);
                Debug.Log("SPECIAL WAVE: " + WaveType);
            }
            else WaveType = 0;
        }
        WaveHUD();
        StartCoroutine(SpawnEnemies(enemyCount));
        return enemyCount;
    }

    public void WaveHUD()
    {
        int wavenr = currentWave + 1;
        if(WaveType == 0) WaveInfo.text = string.Format("Wave {0}", wavenr.ToString("00"));
        else WaveInfo.text = string.Format("Wave {0}: {1}", wavenr.ToString("00"), waveTypeNames[WaveType]);
        if(currentWave > PlayerPrefs.GetInt("HighScore")) WaveInfo.color = Color.yellow;
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
