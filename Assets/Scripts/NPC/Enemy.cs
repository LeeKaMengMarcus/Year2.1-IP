using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public Animator animator;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        // Play Hurt animation
        //animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("enemy died");
        player.GetComponent<QuestLog>().enemyKilled += 1;

        // Die animation
        //animator.SetBool("IsDead", true);

        // Disable the enemy
        GetComponent<Collider>().enabled = false;
        this.enabled = false;

    }
}
