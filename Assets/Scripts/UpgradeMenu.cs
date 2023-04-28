using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    GameManager gameManager;
    PlayerManager playerManager;

    public Button HealthButton;
    public Button SpeedButton;
    public Button BulletButton;

    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Q))
        {
            ExitUpgrade();
        }
    }
    
    void ExitUpgrade()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }


    public void SubtractCoins(int value)
    {
        gameManager.ScoreNum -= value;
    }

    public void UpdateHealth()
    {
        if (HealthButton.interactable)
        {
            if (gameManager.ScoreNum >= 10)
            {
                playerManager.maxHealth += 1;
                gameManager.ChangeHearts(true, 1);
                SubtractCoins(10);
            }
        }
    }
    public void UpdateSpeed()
    {
        if (SpeedButton.interactable)
        {
            if (gameManager.ScoreNum >= 15)
            {
                playerManager.speed += 1;
                SubtractCoins(15);
            }
        }
    }
    public void UpdateBullets()
    {
        Weapon weapon = playerManager.transform.Find("Weapon").GetComponent<Weapon>();
        if (SpeedButton.interactable)
        {
            if (gameManager.ScoreNum >= 32)
            {
                SubtractCoins(32);
            }
        }
    }
}
