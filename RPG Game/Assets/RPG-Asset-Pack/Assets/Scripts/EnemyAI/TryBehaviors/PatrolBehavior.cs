using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;


public class PatrolBehavior : StateMachineBehaviour
{
    float Timer;
    List<Transform> WayPoints = new List<Transform>();
    NavMeshAgent Agent;

    Transform Player;
    float ChaseRange = 10;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Timer = 0;
        Transform WayPointsObjects = GameObject.FindGameObjectWithTag("WayPoints").transform;
        foreach (Transform t in WayPointsObjects)
            WayPoints.Add(t);

        Agent = animator.GetComponent<NavMeshAgent>();
        Agent.SetDestination(WayPoints[Random.Range(0, WayPoints.Count)].position);

        Player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Agent.remainingDistance <= Agent.stoppingDistance)
            Agent.SetDestination(WayPoints[Random.Range(0, WayPoints.Count)].position);

        Timer += Time.deltaTime;
        if (Timer > 10)
            animator.SetBool("IsPatrolling", false);

        float Distance = Vector3.Distance(animator.transform.position, Player.position);
        if (Distance < ChaseRange)
            animator.SetBool("IsChasing", true);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Agent.SetDestination(Agent.transform.position);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
