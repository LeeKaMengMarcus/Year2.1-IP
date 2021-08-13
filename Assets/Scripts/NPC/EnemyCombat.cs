using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    //info from player
    public GameObject player;

    //set attack damage
    public int attackDamage = 5;

    //delay between attack
    public float attackRate = 2f;
    float nextAttackTime = 0f;


    //see if player in collider
    void OnCollisionEnter(Collision other)
    {
        //set delay
        if (Time.time >= nextAttackTime)
        {
            Attack();
            //delay
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    void Attack()
    {
        //deal damage
        player.GetComponent<Player>().currentHealth = player.GetComponent<Player>().currentHealth - attackDamage;


    }
}
