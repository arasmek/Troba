using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public TextMeshProUGUI screentext;
    public GameObject Settings;

    public void ScreenMode()
    {
        if(screentext.text == "Full screen")
        {
            Screen.fullScreen = false;
            screentext.text = "Window";
        }
        else
        {
            Screen.fullScreen = true;
            screentext.text = "Full screen";
        }
    }

    public void HideSettings()
    {
        Settings.SetActive(false);
    }


}
