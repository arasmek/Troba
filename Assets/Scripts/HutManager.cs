using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HutManager : MonoBehaviour
{
    public GameManager gameManager;
    public float health = 10f;
    public float maxHealth;
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {           
            Destroy(gameObject);          
            GameManager.Instance.GameOver();
        }
    }
    public GameObject hintObject;  // The GameObject that displays the hint text
    public KeyCode openMenuKey = KeyCode.E;  // The key to press to open the upgrade menu

    private bool isPlayerInRange = false;  // A flag to track if the player is in range
    void Start()
    {
        hintObject.SetActive(false);
        maxHealth = health;
    }

    public TextMeshProUGUI HealthText;
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(openMenuKey))
        {
            gameManager.Upgrade();
        }
        HealthText.text = string.Format("{0}/{1}", health.ToString(), maxHealth.ToString());
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("LABAS, PLAYERI.");
            isPlayerInRange = true;
            hintObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("VISO, PLAYERI!");
            isPlayerInRange = false;
            hintObject.SetActive(false);
        }
    }
    
}
