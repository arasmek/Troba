using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //[SerializeField]
    //private int damage = 1;
    [SerializeField]
    private float speed = 1.5f;

    [SerializeField]
    private EnemyData data;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        swarm();
    }

    private void swarm()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    //private void OnTriggerEnter2D(Collider2D collider)
    //{
    //    if (collider.CompareTag("Player"))
    //    {
    //        if (collider.GetComponent<Health>()! = null)
    //        {
    //            collider.GetComponent<Health>().Damage(damage);
    //            this.GetComponent<Health>().Damage(100);
    //        }
    //    }
    //}
}