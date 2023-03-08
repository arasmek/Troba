using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    private BulletManager bulletManager;
    private UnityAction<Bullet> deathAction;
    [SerializeField] private Rigidbody2D rb;

    private void Awake()
    {
        bulletManager = GameManager.Instance.BulletManager;
    }

    public void Init(UnityAction<Bullet> deathAction, Vector2 speed)
    {
        this.deathAction = deathAction;
        rb.AddForce(speed, ForceMode2D.Impulse);
    }
    // Update is called once per frame
    void Update()
    {
        if(transform.position.magnitude > GameManager.Instance.arenaRadius)
        {
            Die();
        }
    }

    private void Die()
    {
        deathAction.Invoke(this);
    }
}
