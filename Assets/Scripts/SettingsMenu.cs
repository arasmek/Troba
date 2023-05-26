using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public TextMeshProUGUI screentext;
    public GameObject Settings;

    

    public void HideSettings()
    {
        Settings.SetActive(false);
    }


}
