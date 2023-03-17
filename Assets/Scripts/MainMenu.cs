using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button ContinueButton;
    public GameObject SettingsMenu;
    void Start()
    {
        ContinueButton.interactable = false;
    }
    public void Continue()
    {
        ContinueButton.interactable = true;
    }
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Zaidimas baigtas.");
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
