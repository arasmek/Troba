using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Enemy", order = 1)]

public class EnemyManager : ScriptableObject
{
    public int health;
    public double damage;
    public float speed;
}
