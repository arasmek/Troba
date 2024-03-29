using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 3; // The health points of the enemy.
    private EnemySprite sprite;
    WaveManager waveManager;
    private void Start()
    {
        sprite = GetComponent<EnemySprite>();
        waveManager = GameObject.Find("WaveManager")?.GetComponent<WaveManager>();
        if(waveManager.WaveType == 2 || waveManager.WaveType == 3) health += 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the enemy collided with a gameobject with the tag "Bullet".
        if (other.CompareTag("Bullet"))
        {
            // Reduce the health points of the enemy.
            health -= 1;
            StartCoroutine(sprite.DamageSprite());
            // Check if the enemy has no health points left.
            if (health <= 0)
            {
                Death();                
            }
        }
    }

    public GameObject coinPrefab;
    public float coinSpawnChance = 0.5f;
    public GameObject heartPrefab;
    public float heartSpawnChance = 0.1f;
    public void Death()
    {
        Destroy(gameObject);
        // Spawn a coin with a random chance
        float randomValue = Random.value;
        if (randomValue <= coinSpawnChance)
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }
        else if (randomValue <= coinSpawnChance + heartSpawnChance)
        {
            Instantiate(heartPrefab, transform.position, Quaternion.identity);
        }
    }
}
