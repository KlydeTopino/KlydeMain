using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent Agent;

    public Transform Player;

    public LayerMask WhatIsGround, WhatIsPlayer;

    //Patroling

    public Vector3 WalkPoint;
    public bool WalkPointSet;
    public float WalkPointRange;


    //Attacking
    public float TimeBetweenAttacks;
    public bool AlreadyAttacked;




    //States
    public float SightRange, AttackRange;
    public bool PlayerInSightRange, PlayerInAttackRange;



    private void Awake()
    {
        Player = GameObject.Find("Player").transform;
        Agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        PlayerInSightRange = Physics.CheckSphere(transform.position, SightRange, WhatIsPlayer);
        PlayerInAttackRange = Physics.CheckSphere(transform.position, AttackRange, WhatIsPlayer);

        if (!PlayerInSightRange && !PlayerInAttackRange) Patroling();
        if (PlayerInSightRange && !PlayerInAttackRange) ChasePlayer();
        if (PlayerInAttackRange && PlayerInAttackRange) AttackPlayer();
    }
    

    private void Patroling()
    {
        if (!WalkPointSet) SearchWalkPoint();

        if (WalkPointSet)
            Agent.SetDestination(WalkPoint);

        Vector3 DistanceToWalkPoint = transform.position - WalkPoint;

        if (DistanceToWalkPoint.magnitude < 1f)
            WalkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float RandomRangeOne = Random.Range(-WalkPointRange, WalkPointRange);
        float RandomRangeTwo = Random.Range(-WalkPointRange, WalkPointRange);

        WalkPoint = new Vector3(transform.position.x + RandomRangeOne, transform.position.y, transform.position.z + RandomRangeTwo);

        if (Physics.Raycast(WalkPoint, -transform.up, 2f, WhatIsGround))
            WalkPointSet = true;

    }

    private void ChasePlayer()
    {
        Agent.SetDestination(Player.position);

    }

    private void AttackPlayer()
    {
        Agent.SetDestination(transform.position);

        transform.LookAt(Player); 

        if (!AlreadyAttacked)
        {

            AlreadyAttacked = true;
            Invoke(nameof(ResetAttack), TimeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        AlreadyAttacked = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, SightRange);

    }

}
