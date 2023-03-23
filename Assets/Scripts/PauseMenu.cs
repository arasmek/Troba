using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject SettingsMenu;
    public Button RestartButton;
    
    void Start()
    {
        RestartButton.interactable = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitPauseMenu();
        }
    }
    public void ExitPauseMenu()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void LeaveToMainMenu()
    {
        //SceneManager.UnloadSceneAsync("MainLevelScene");
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    //TODO: Implement this when checkpoints get added.
    public void Restart()
    {
        Debug.Log("NOT IMPLEMENTED");
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
