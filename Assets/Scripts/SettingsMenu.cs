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
        if(screentext.text == "Pilnas ekr.")
        {
            Screen.fullScreen = false;
            screentext.text = "Langas";
        }
        else
        {
            Screen.fullScreen = true;
            screentext.text = "Pilnas ekr.";
        }
    }

    public void HideSettings()
    {
        Settings.SetActive(false);
    }


}
