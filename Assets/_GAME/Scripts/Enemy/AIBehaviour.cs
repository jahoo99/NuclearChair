using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

    }
    private void Start()
    {
        Patrolling();
    }
    private void Patrolling()
    {
        FindWalkPoint();
        Debug.Log(_walkPoint);
        
        agent.SetDestination(_walkPoint);
        //agent.SetDestination(new Vector3(0,0,0));
        //Vector3 distanceToWalkPoint = transform.position - _walkPoint;
        //if (distanceToWalkPoint.magnitude < 2f)
        //{
        //    _walkPointSet = false;
        //}
    }
    private Vector3 _walkPoint;
    [SerializeField]private float _walkPointRange;
    private LayerMask _groundLayer;
    private bool _walkPointSet;
    private void FindWalkPoint()
    {
        float randomX = Random.Range(-_walkPointRange, _walkPointRange);
        float randomZ = Random.Range(-_walkPointRange, _walkPointRange);

        _walkPoint = new Vector3(transform.position.x + randomX, 0, transform.position.z + randomZ);
        if (Physics.Raycast(_walkPoint, -transform.up, _groundLayer))
        {
            _walkPointSet = true;
        }
    }


}
