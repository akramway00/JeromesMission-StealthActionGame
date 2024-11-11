using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drone : MonoBehaviour
{
    [SerializeField] private Transform[] pointsNavigation = new Transform[3];
    private UnityEngine.AI.NavMeshAgent agentIA;
    private int destination;



    void Start()
    {
        agentIA = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agentIA.SetDestination(pointsNavigation[0].position);
    }


    void Update()
    {
        if (!agentIA.pathPending && (agentIA.remainingDistance <= agentIA.stoppingDistance))
        {

            destination++;
            if (destination == pointsNavigation.Length)
            {
                destination = 0;
            }

            agentIA.SetDestination(pointsNavigation[destination].position);
        }
    }
}
