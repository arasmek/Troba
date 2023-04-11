using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f; // The speed at which the enemy moves towards the player.
    public string playerTag = "Player"; // The tag of the player GameObject.

    private Transform playerTransform; // The transform of the player GameObject.
    private bool canMove = false; // Flag to check if the enemy can move towards the player.

    private void Start()
    {
        // Start the delay coroutine.
        StartCoroutine(StartMovementDelay());
    }

    private void Update()
    {
    if (canMove && playerTransform != null)
    {
        // Calculate the direction and distance to the player.
        Vector3 direction = playerTransform.position - transform.position;
        float distance = direction.magnitude;

        // Cast a ray towards the player to check for obstacles.
        RaycastHit hit;
        bool hitObstacle = Physics.Raycast(transform.position, direction, out hit, distance);

        // If there are no obstacles, move towards the player.
        if (!hitObstacle || hit.collider.gameObject.tag == playerTag)
        {
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
    }
}

    private IEnumerator StartMovementDelay()
    {
        // Wait for 5 seconds before finding the player GameObject.
        yield return new WaitForSeconds(5f);

        // Find the player GameObject using the tag.
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);

        // Set the playerTransform variable to the transform of the player GameObject.
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }

        // Set the flag to true to allow the enemy to move.
        canMove = true;
    }
}
