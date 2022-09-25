using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    bool isProvoked;
    [SerializeField] Transform target;
    [SerializeField][Range(1f, 30f)] float chaseRange = 15f;
    NavMeshAgent navMeshAgent;
    Animator anim;
    float distanceToTarget = Mathf.Infinity;
    // Start is called before the first frame update
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75f);
        Gizmos.DrawWireSphere(transform.position, chaseRange);

    }
    void Start()
    {
        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //Calc distance to the player
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget < chaseRange)
        {
            isProvoked = true;
        } 
    }
    void EngageTarget()
    {
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        } else {
            anim.SetBool("Attack", false);
        }

    }

    private void ChaseTarget()
    {
        anim.SetTrigger("Move");
        navMeshAgent.SetDestination(target.position);
    }
    private void AttackTarget()
    {
        anim.SetBool("Attack", true);
        Debug.Log("Attacking " + target.gameObject.name);
    }
}
