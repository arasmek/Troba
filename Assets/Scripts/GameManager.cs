using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public enum GameState
{
    GameOver,
    Game,
    Paused
}

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance => instance;
    [SerializeField] private CinemachineVirtualCamera playerCam;
    [SerializeField] private PlayerManager playerPrefab;
    [SerializeField] private Transform playerSpawn;
    //[SerializeField] private EnemyManager enemyPrefab;
    //[SerializeField] private Transform enemySpawn;
    public PlayerManager Player {get; private set;} 
    
    public float ArenaRadius = 0f;
    [SerializeField] private BulletManager bulletManager;
    [HideInInspector] public BulletManager BulletManager => bulletManager;



    [SerializeField] private GameObject RestartMenu;
    [SerializeField] private Button RestartButton;
    
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject UpgradeScreen;

    [SerializeField] private AudioSource GameOverSound;
    [SerializeField] private AudioSource TakeDamageSound;
    [SerializeField] private AudioSource StopBGMusic;


    public GameState CurrentState {get; private set;}

    void Awake()
    {
        instance = this;
        Init();
    }

    private void Init()
    {
        CurrentState = GameState.Game;
        Time.timeScale = 1;
        PauseMenu.gameObject.SetActive(false);
        UpgradeScreen.gameObject.SetActive(false);
        RestartMenu.gameObject.SetActive(false);
        Player = Instantiate(playerPrefab);
        Player.transform.position = playerSpawn.position;
        playerCam.Follow = Player.transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        MyscoreText.text = ScoreNum.ToString();
    }

    public void GameOver()
    {
        
        GameOverSound.Play();
        StopBGMusic.Pause();
        Time.timeScale = 0;
        CurrentState = GameState.GameOver;
        RestartMenu.gameObject.SetActive(true);
    }

    public void PauseGame()
    {
        if(!UpgradeScreen.gameObject.activeSelf)
        {
            Time.timeScale = 0;
            CurrentState = GameState.Paused;
            PauseMenu.gameObject.SetActive(true);
        }
    }
    public void Upgrade()
    {
        if(!UpgradeScreen.gameObject.activeSelf && !PauseMenu.gameObject.activeSelf)
        {
            Time.timeScale = 0;
            CurrentState = GameState.Paused;
            UpgradeScreen.gameObject.SetActive(true);
        }
        
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainLevelScene");
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Vector3.zero, ArenaRadius);
        Gizmos.DrawWireCube(playerSpawn.position, playerSpawn.localScale);
    }
    
    public TextMeshProUGUI MyscoreText;
    public int ScoreNum = 0;
    public void CollectCoin()
    {
        ScoreNum++;
    }
    public Image[] hearts;
    public void ChangeHearts(bool add, int health)
    {
        if(!add)
        {
            TakeDamageSound.Play();
            hearts[health - 1].enabled = false;
        }
        else
        {
            hearts[health].enabled = true;
        }
    }

}
