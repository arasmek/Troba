using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySprite : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite enemy;
    public Sprite damage;
    private Rigidbody2D rb2D;
    public bool takingDamage = false;
    EnemyMovement movement;

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        movement = GetComponent<EnemyMovement>();
    }

    void Update()
    {
        if (takingDamage == true)
            spriteRenderer.sprite = damage;
        else spriteRenderer.sprite = enemy;

        //rb2D.velocity = new Vector2(-movement.speed, rb2D.velocity.y);

        // Check if the enemy is moving left
        if (rb2D.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (rb2D.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
    public IEnumerator DamageSprite()
    {
        takingDamage = true;
        yield return new WaitForSeconds(0.5f);
        takingDamage = false;
    }
}
