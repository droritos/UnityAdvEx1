using System;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject finalDestination;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Animator animator;
    [SerializeField] private Camera camera;
    [SerializeField] private LayerMask layerMask;
    private bool reached = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetAreasCosts();
    }

    // Update is called once per frame
    void Update()
    {
        Clicked();
        HasArrived();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == finalDestination)
            TextShow();
    }

    public void Clicked()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out RaycastHit rayHit,Mathf.Infinity, layerMask))
            {
                agent.SetDestination(rayHit.point);
                animator.SetTrigger("Play_Running");
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
            animator.SetTrigger("Play_Idle");
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

    public void TextShow()
    {
        if (text != null)
        {
            text.enabled = true;
        }
    }
}
