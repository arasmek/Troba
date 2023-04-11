using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 3; // The health points of the enemy.

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the enemy collided with a gameobject with the tag "Bullet".
        if (other.CompareTag("Bullet"))
        {
            // Reduce the health points of the enemy.
            health -= 1;

            // Check if the enemy has no health points left.
            if (health <= 0)
            {
                // Destroy the enemy gameobject.
                Destroy(gameObject);
            }
        }
    }
}
