using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public Button ContinueButton;
    public GameObject SettingsMenu;
    public TextMeshProUGUI HiScore;
    void Start()
    {
        HiScore.text = "Hi: " + PlayerPrefs.GetInt("HighScore").ToString("00");
    }
    public void ClearScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        Start();
    }
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Zaidimas baigtas.");
    }

    //DABAR PADIDINA HIGHSCORE TESTAVIMUI. REIKS PAKEIST VELIAU
    public void AboutButton()
    {
        PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("HighScore") + 1);
        Start();
    }
    public void StartGame()
    {
        //SceneManager.UnloadSceneAsync("MainMenu");
        SceneManager.LoadScene("MainLevelScene");
    }
    public void OpenSettings()
    {
        Transform existingMenu = transform.Find("SettingsMenu(Clone)");
        if (existingMenu != null)
        {
            existingMenu.gameObject.SetActive(true);
        }
        else
        {
            GameObject settingsMenuObject = Instantiate(SettingsMenu);
            settingsMenuObject.transform.SetParent(transform, false);
        }
        
    }

}
