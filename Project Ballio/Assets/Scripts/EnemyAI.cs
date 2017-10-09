using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent navAgent;
    private GameObject target;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();    //prepares use of the Nav Mesh agent for movement.
        target = GameObject.FindGameObjectWithTag("Player");    //Defines the player as target.
    }

    void Update()
    {
        if (target != null)
            navAgent.SetDestination(target.transform.position); //moves towards player each frame.
    }
}
