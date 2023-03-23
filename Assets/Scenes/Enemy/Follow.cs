using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // if no target specified, assume the player
        if (target == null)
        {
            if (GameObject.FindWithTag("Player") != null)
            {
                target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
        }
    }

    public GameObject Player;
    public bool Speed;

    //public float speed = 20.0f;
    public float minDist = 1f;
    //public Transform target;
    // Use t$$anonymous$$s for initialization

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;
        // face the target
        transform.LookAt(target);
        //get the distance between the chaser and the target
        float distance = Vector3.Distance(transform.position, target.position);
        //so long as the chaser is farther away than the minimum distance, move towards it at rate speed.
        if (distance > minDist)
            transform.position += transform.forward * speed * Time.deltaTime;
    }


    //I first start getting the transform (position) of my player
    public Transform target;
    //Then I set up the speed of the enemy, that I can edit later
    public float speed = 2f;
    //Lastly, I added the enemy a rigidbody
    public Rigidbody rb;

    //First t$$anonymous$$ng, I will create a function that follows the player
    void FollowPlayer()
    {
        //I will create a vector 3 called pos that stores the movement that I want my player to do
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        //I will use these two built-in functions to follow the player
        rb.MovePosition(pos);
        transform.LookAt(target);
    }

    //Finally, I add a collider function that calls the FollowPlayer() function when it is wit$$anonymous$$n its range
    void OnTriggerStay(Collider player)
    {
        if (player.tag == "Player")
        {
            FollowPlayer();
        }
    }
}
