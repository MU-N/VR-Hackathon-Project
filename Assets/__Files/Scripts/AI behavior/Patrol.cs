// Patrol.cs
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

[RequireComponent(typeof(Animator), typeof(NavMeshAgent))]

public class Patrol : MonoBehaviour
{
    public bool stop_Rest;
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private bool animationCorotineIsWorking;
    
    private Animator animator;
    private readonly int IsWalkingHash = Animator.StringToHash("isWalking");
    WaitForSeconds animationCorotineWaitObject;
    public float animationCheckerDelay = .2f;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        animationCorotineWaitObject = new WaitForSeconds(animationCheckerDelay);
      

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        if (!agent.isOnNavMesh)
            return;
        agent.autoBraking = stop_Rest;
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;
        if (!animationCorotineIsWorking)
        {
            StartCoroutine(Walk_Stop_Animation());
        }
        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        if (!agent.isOnNavMesh)
            return;
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();

    
    }


    private IEnumerator Walk_Stop_Animation()
    {
        animationCorotineIsWorking = true;
        animator.SetBool(IsWalkingHash, true);
        while (agent.remainingDistance > agent.stoppingDistance)
        {
            yield return animationCorotineWaitObject;
        }
        animator.SetBool(IsWalkingHash, false);
        animationCorotineIsWorking = false;
    }

}