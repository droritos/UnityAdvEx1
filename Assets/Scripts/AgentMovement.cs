using System;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class AgentMovement : MonoBehaviour
{
    public event UnityAction OnAgentReachDestinationActionEvent; // Also getting the passed time

    [SerializeField] private NavMeshAgent agent;
    public NavMeshAgent Agent { get { return agent; } }
    private float _originalSpeed;

    [SerializeField] private Animator animator;
    [SerializeField] private Camera camera;
    [SerializeField] private LayerMask layerMask;
    private bool reached = true;


    void Start()
    {

        //OnEventSurfaceEnterEvent.AddListener(HandleSpeed);
        _originalSpeed = agent.speed;
        SetAreasCosts();
    }

    void Update()
    {
        
        Clicked();
        HasArrived();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Final"))
        {
            OnAgentReachDestinationActionEvent?.Invoke();
        }
    }

    public void Clicked()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out RaycastHit rayHit,Mathf.Infinity, layerMask))
            {
                agent.SetDestination(rayHit.point);
                animator.SetBool("playRunning", true);
                animator.SetBool("playIdle", false);
                reached = false;
                agent.isStopped = false;
            }
        }
    }

    public void HasArrived()
    {
        if (agent != null && !reached && agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            reached = true;
            agent.isStopped = true;
            animator.SetBool("playRunning", false);
            animator.SetBool("playIdle", true);
        }
    }

    public void SetAreasCosts()
    {
        if (agent != null && agent.agentTypeID == -334000983) // ID 2 = Elf but for some reason it goes into this number when checked.
        {
            agent.SetAreaCost(6,1);
        }
        else if (agent != null && agent.agentTypeID == 0) // ID 0 = Human
        {
            agent.SetAreaCost(6,6);
        }
    }

    public void ResetSpeed()
    {
        agent.speed = _originalSpeed;
    }
}
