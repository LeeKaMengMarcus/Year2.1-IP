using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    //public Animator animator;

    public GameObject player;

    public int attackDamage = 5;

    public float attackRate = 2f;
    float nextAttackTime = 0f;



    void OnCollisionEnter(Collision other)
    {
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
            
        }
    }

    void Attack()
    {
        player.GetComponent<Player>().currentHealth = player.GetComponent<Player>().currentHealth - attackDamage;


    }
}
