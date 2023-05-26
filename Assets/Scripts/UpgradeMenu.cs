using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    PlayerManager playerManager;
    WaveManager waveManager;

    public Button HealthButton;
    public Button SpeedButton;
    public Button BulletButton;
    public Button NextWaveButton;
    [SerializeField] private GameManager gameManager;
    [HideInInspector] public GameManager GameManager => gameManager;
    [SerializeField] private HutManager hutManager;
    [HideInInspector] public HutManager HutManager => hutManager;

    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        waveManager = GameObject.FindObjectOfType<WaveManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.E))
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

    int healthlevel = 0;
    public Image[] healthlevelimg;
    public void UpdateHealth()
    {
        if (gameManager.ScoreNum >= 5 && healthlevel <= 2)
        {
            if(healthlevel == 0) { hutManager.health += 5f; hutManager.maxHealth += 5f;}
            if(healthlevel == 1) { hutManager.health += 10f; hutManager.maxHealth += 10f;}
            if(healthlevel == 2) { hutManager.health += 15f; hutManager.maxHealth += 15f;}
            SubtractCoins(5);
            healthlevelimg[healthlevel].GetComponent<Image>().color = Color.yellow;
            healthlevel++;
        }
    }
    public void FixHut()
    {
        if(hutManager.health != hutManager.maxHealth && gameManager.ScoreNum >= 1)
        {
            hutManager.health += 1f;
            SubtractCoins(1);
        }
    }

    int speedlevel = 0;
    public Image[] speedlevelimg;
    public void UpdateSpeed()
    {
        if (gameManager.ScoreNum >= 3 && speedlevel <= 2)
        {
            playerManager.speed += 2;
            SubtractCoins(3);
            speedlevelimg[speedlevel].GetComponent<Image>().color = Color.yellow;
            speedlevel++;
        }
    }

    int bulletlevel = 0;
    public Image[] bulletlevelimg;
    public void UpdateBullets()
    {
        Weapon weapon = playerManager.transform.Find("Weapon").GetComponent<Weapon>();
        if (gameManager.ScoreNum >= 2 && bulletlevel <= 2)
        {
            weapon.fireRate += 2;
            SubtractCoins(2);
            bulletlevelimg[bulletlevel].GetComponent<Image>().color = Color.yellow;
            bulletlevel++;
        }
    }
    public void StartNextWave()
    {
        waveManager.StartNextWave();
        ExitUpgrade();
    }
}
