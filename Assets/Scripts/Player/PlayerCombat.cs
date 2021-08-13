using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //animaion for sword
    public Animator swordSwing;

    //set attack point
    public Transform attackPoint;
    //identify enemy lyer
    public LayerMask enemyLayers;

    //set attack range
    public float attackRange = 0.5f;
    //set attack damage
    public int attackDamage = 40;

    //attack delay
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    //public AudioSource swordSound;

    // Update is called once per frame
    void Update()
    {
        //see if over delay
        if (Time.time >= nextAttackTime)
        {

            //attack trigger
            if (Input.GetMouseButtonDown(0))
            {
                //trigger sword swing animation
                swordSwing.SetTrigger("swing");
                Attack();
                //swordSound.Play();
                //delay
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        
    }

    void Attack()
    {
        // Attack Animation
        // animator.SetTrigger("Attack");

        // Detect enemy in range of attack
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        // Apply Damage
        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }


    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
