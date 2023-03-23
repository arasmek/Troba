using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;

    private ObjectPool<Bullet> bulletPool;

    void Start()
    {
        bulletPool = new ObjectPool<Bullet>(() => { 
            return Instantiate(bulletPrefab);
        }, bullet => {
            bullet.gameObject.SetActive(true);
        }, bullet => {
            bullet.gameObject.SetActive(false);
        }, bullet => {
            Destroy(bullet.gameObject);
        }, false, 10, 20);
    }

    public void SpawnBullet(Vector2 position, Vector2 dirSpeed, float size)
    {
        Bullet bullet = bulletPool.Get();
        bullet.transform.position = position;
        bullet.transform.localScale = new Vector3(size, size, 1);
        bullet.Init(KillBullet, dirSpeed);
    }

    private void KillBullet(Bullet bullet)
    {
        bulletPool.Release(bullet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
