using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashWaitTime;
    private float timeUntilDash = 0f;
    private bool canDash = true;
    [SerializeField] private Weapon weapon;

    [SerializeField] private int maxHealth;
    private int health = 0;

    [SerializeField] private float invincibilityTime;
    private bool isInvincible;
    private float invincibilityLeft = 0f;

    private Vector2 lookDirection = new Vector2();
    [SerializeField] public TextMeshProUGUI MyscoreText;
    private int ScoreNum;

    void Start()
    {
        Init();
    }

    void Update()
    {
        lookDirection = (controller.MousePos - (Vector2)transform.position).normalized;

        if (controller.LeftMB && weapon.CanShoot)
        {
            weapon.Shoot(lookDirection);
        }
        if (timeUntilDash > 0f)
        {
            timeUntilDash -= Mathf.Min(timeUntilDash, Time.deltaTime);
        }
        else if (!canDash)
        {
            canDash = true;
        }

        if (invincibilityLeft > 0)
        {
            invincibilityLeft -= Mathf.Min(invincibilityLeft, Time.deltaTime);
        }
        else if (isInvincible)
        {
            isInvincible = false;
        }
    }
    public void Init()
    {
        controller.DashKey.SetPressedAction(Dash);
        health = maxHealth;

    }

    void FixedUpdate()
    {
        rb.AddForce(controller.Direction * speed, ForceMode2D.Force);
        float DirectionDeg = Mathf.Atan2(controller.MousePos.y - transform.position.y,
                                         controller.MousePos.x - transform.position.x) * Mathf.Rad2Deg;
        rb.MoveRotation(DirectionDeg);
    }

    private void Dash()
    {
        if (canDash && controller.Direction.magnitude != 0)
        {
            canDash = false;
            timeUntilDash = dashWaitTime;
            rb.AddForce(controller.Direction * dashSpeed, ForceMode2D.Impulse);
        }
    }

    private void TakeDamage()
    {
        GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gameManager.ChangeHearts(false, health);
        health--;
        if (health == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameManager.Instance.GameOver();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !isInvincible)
        {
            isInvincible = true;
            invincibilityLeft = invincibilityTime;
            TakeDamage();
        }
        if (collision.gameObject.tag == "MyCoin")
        {
            Destroy(collision.gameObject);
            GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
            gameManager.CollectCoin();
        }
        if (collision.gameObject.tag == "Heart")
        {
            if (health != maxHealth)
            {
                Destroy(collision.gameObject);
                GameManager gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
                gameManager.ChangeHearts(true, health);
                health++;
            }

        }

    }


}
