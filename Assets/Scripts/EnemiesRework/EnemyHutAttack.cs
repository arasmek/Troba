using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHutAttack : MonoBehaviour
{
    public float damage = 1.0f;
    public float damageInterval = 3.0f;
    public string targetTag = "Hut";

    private float nextDamageTime = 0.0f;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(targetTag) && Time.time > nextDamageTime)
        {
            HutManager hut = other.gameObject.GetComponent<HutManager>();

            if (hut != null)
            {
                hut.TakeDamage(damage);
            }

            nextDamageTime = Time.time + damageInterval;
        }
    }
}

