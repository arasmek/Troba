using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySprite : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite enemy;
    public Sprite damage;

    public bool takingDamage = false;

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (takingDamage == true)
            spriteRenderer.sprite = damage;
        else spriteRenderer.sprite = enemy;
    }
    public IEnumerator DamageSprite()
    {
        takingDamage = true;
        yield return new WaitForSeconds(0.5f);
        takingDamage = false;
    }
}
