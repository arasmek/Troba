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
    
    void Update()
    {
        if(transform.position.magnitude > GameManager.Instance.ArenaRadius)
        {
            Die();
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Wall")
        {
            Die();
        }
    }
    //TODO: Update when enemies are implemented
    private void Die()
    {
        deathAction.Invoke(this);
    }
}
