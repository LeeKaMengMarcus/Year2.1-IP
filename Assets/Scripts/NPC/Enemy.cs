/******************************************************************************
Author: Meagan

Name of Class: Enemy

Description of Class: Enemy stats and slider movement.

******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //health capacity
    public int maxHealth = 100;
    public int currentHealth;

    //reference health bar
    public HealthBar healthBar;

    //get info from player
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        //set health
        currentHealth = maxHealth;
        //set health bar length
        healthBar.SetMaxHealth(maxHealth);
    }

    //take damage
    public void TakeDamage(int damage)
    {
        //taking out health
        currentHealth -= damage;

        //set new health
        healthBar.SetHealth(currentHealth);

        //check if dead
        if(currentHealth <= 0)
        {
            //trigger death things
            Die();
        }
    }

    void Die()
    {
        Debug.Log("enemy died");
        //points for player
        player.GetComponent<QuestLog>().enemyKilled += 1;

        // Disable the enemy
        GetComponent<Collider>().enabled = false;
        this.enabled = false;

    }
}
