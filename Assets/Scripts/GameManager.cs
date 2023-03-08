using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance => instance;
    [SerializeField] private CinemachineVirtualCamera playerCam;
    [SerializeField] private PlayerManager playerPrefab;
    [SerializeField] private Transform playerSpawn;
    public PlayerManager Player {get; private set;} 
    
    public float arenaRadius = 0f;
    [SerializeField] private BulletManager bulletManager;
    [HideInInspector] public BulletManager BulletManager => bulletManager;

    void Start()
    {
        Init();
    }

    void Awake()
    {
        instance = this;
    }

    private void Init()
    {
        Player = Instantiate(playerPrefab);
        Player.transform.position = playerSpawn.position;
        playerCam.Follow = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Vector3.zero, arenaRadius);
    }
}
