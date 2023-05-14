using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawn;
    private BulletManager bulletManager;
    
    public float fireRate;
    private float waitInterval => 1 / fireRate;
    private float timeUntilShoot = 0f;
    [SerializeField] private float bulletSpeed;

    [SerializeField] private float spreadAmount = 0f;
    private float maxSpread = 90f;
    private float realSpread => maxSpread * spreadAmount;
    [SerializeField] private float bulletSize;

    public bool CanShoot {get; private set;} = true;

    private void Awake()
    {
        bulletManager = GameManager.Instance.BulletManager;
    }

    public void Shoot(Vector2 direction)
    {
        CanShoot = false;
        timeUntilShoot = waitInterval;
        float randomSpread = 0f;
        if(spreadAmount > 0f)
        {
            randomSpread = Random.Range(-realSpread/2, realSpread/2) * Mathf.Deg2Rad;
        }

        Vector2 realDirection = Utilities.RotateVector(direction, randomSpread); 

        bulletManager.SpawnBullet(bulletSpawn.position, realDirection * bulletSpeed, bulletSize);
    }

    private void Update()
    {
        if(timeUntilShoot > 0f)
        {
            timeUntilShoot -= Mathf.Min(timeUntilShoot, Time.deltaTime);
        }
        else if(!CanShoot) 
        {
            CanShoot = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(bulletSpawn.position, bulletSize/2);
    }
}
