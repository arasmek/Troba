using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RestartMenu : MonoBehaviour
{
    
    [SerializeField] private WaveManager waveManager;
    [HideInInspector] public WaveManager WaveManager => waveManager;
    public TextMeshProUGUI HighScoreText;
    public TextMeshProUGUI CurrentScoreText;
    

    void Start()
    {
        int currentscore = waveManager.currentWave - 1;
        
        if( currentscore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", currentscore);
        }

        HighScoreText.text = "High score: " + PlayerPrefs.GetInt("HighScore").ToString("00");
        CurrentScoreText.text = "Score: " + currentscore.ToString("00");
    }
    
    public void Restart()
    {
        SceneManager.LoadScene("MainLevelScene");
    }
    public void LeaveToMainMenu()
    {
        //SceneManager.UnloadSceneAsync("MainLevelScene");
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
