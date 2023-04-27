using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Upgrade();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Upgrade()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("UpgradeMenu");
    }
}
