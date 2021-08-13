/******************************************************************************
Author: Meagan

Name of Class: EnemyController

Description of Class: Enemy movement and behaviour towards player.

******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //find player
    public float lookRadius = 10f;
    //set damage
    public int attackDamage = 5;
    //info fro player
    public GameObject player;

    //target player location
    Transform target;
    //set navmesh
    NavMeshAgent agent;
    //set player layer and ground layer
    public LayerMask whatIsGround, whatIsPlayer;

    //patrol
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //attaking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //states
    public float sightRange, attackRange;
    public bool playerInsigtRange, playerInAttackRange;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        //displacement of player
        float distance = Vector3.Distance(target.position, transform.position);

        //check if player in radius
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            //stop infront of player
            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
                AttackPlayer();
            }
        }
        else
        {
            Patrol();
        }

        //check if dead
        if (GetComponent<Enemy>().currentHealth <= 0)
        {
            this.enabled = false;
        }

    }

    public void Patrol()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //walkpoint reached
        if (distanceToWalkPoint.magnitude < 2f)
        {
            walkPointSet = false;
        }
    }

    //find a place to go
    public void SearchWalkPoint()
    {
        //randomized location
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        //set location
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        //see if location is reachable
        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    public void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        if (!alreadyAttacked)
        {
            //deal damage
            TakeDamage(attackDamage);

            //make delay
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        //deal damage
        player.GetComponent<Player>().currentHealth -= damage;
    }

    //look to player
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }


}
