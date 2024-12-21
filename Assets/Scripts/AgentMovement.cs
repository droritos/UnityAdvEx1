using System;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject wayPoint;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Animator animator;
    private bool hasArrived = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetAreasCosts();
        agent.SetDestination(wayPoint.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        HasArrived();
    }

    public void HasArrived()
    {
        if (agent != null && !hasArrived && !agent.hasPath && !agent.pathPending)
        {
            Debug.Log("The agent has arrived!");
            TextShow();
            hasArrived = true;
            agent.isStopped = true;
            animator.SetTrigger("Play_Idle");
        }
    }

    public void SetAreasCosts()
    {
        Debug.Log(agent.agentTypeID);
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
