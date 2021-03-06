using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class MoveDestination : MonoBehaviour
{

    public Transform goal;

    void Start()
    {
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal.position;
    }
}