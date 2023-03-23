using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public PlayerManager Player {get; private set;} 
    
    public float ArenaRadius = 0f;
    [SerializeField] private BulletManager bulletManager;
    [HideInInspector] public BulletManager BulletManager => bulletManager;

    [SerializeField] private Button RestartButton;
    [SerializeField] private GameObject PauseMenu;
    

    public GameState CurrentState {get; private set;}

    void Awake()
    {
        instance = this;
        Init();
    }

    private void Init()
    {
        CurrentState = GameState.Game;
        RestartButton.onClick.AddListener(() => Restart());
        RestartButton.gameObject.SetActive(false);
        PauseMenu.gameObject.SetActive(false);
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
    }

    //TODO: GameOver implementation
    public void GameOver()
    {
        CurrentState = GameState.GameOver;
        RestartButton.gameObject.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        CurrentState = GameState.Paused;
        PauseMenu.gameObject.SetActive(true);
    }

    //TODO: When checkpoints are implemented, this should do more functionality
    private void Restart()
    {
        SceneManager.LoadScene("MainLevelScene");
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Vector3.zero, ArenaRadius);
        Gizmos.DrawWireCube(playerSpawn.position, playerSpawn.localScale);
    }

    

}
