using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField]private LayerMask _playerLayer;
    [SerializeField]private float _radius;

    [SerializeField] private float _timeBetweenAttacks = 1;
    private bool _alreadyAttacked;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

    }
    private void Update()
    {
        Debug.Log(Physics.OverlapSphere(transform.position, _radius, _playerLayer).Length);
        if (Physics.OverlapSphere(transform.position, _radius, _playerLayer).Length>0)
        {
            Chase();
            Attack();

        }
        else
        {
            Patrolling();
        }
    }

    private Collider[] _players;
    private void Chase()
    {
        _players = Physics.OverlapSphere(transform.position, _radius, _playerLayer);
        agent.SetDestination(_players[0].transform.position);
    }
    [SerializeField]private GameObject _bullet;

    private void Attack()
    {
        if (!_alreadyAttacked)
        {
            //attack
            Instantiate(_bullet, transform);
            _alreadyAttacked = true;
            Invoke(nameof(Reset), _timeBetweenAttacks);
        }
    }
    private void Reset()
    {
        _alreadyAttacked = false;
    }

    private Vector3 _walkPoint;
    [SerializeField] private float _walkPointRange;
    [SerializeField] private LayerMask _groundLayer;
    private bool _walkPointSet;

    private void Patrolling()
    {
        Debug.Log(_walkPointSet);
        //Debug.Log(_walkPoint);
        //Debug.Log();
        if (!_walkPointSet)
        {
            FindWalkPoint();
        }
        else
        {
            agent.SetDestination(_walkPoint);
        }
        Vector3 distanceToWalkPoint = transform.position - _walkPoint;
        if (distanceToWalkPoint.magnitude < 2f)
        {
            _walkPointSet = false;
        }
    }
    
    private void FindWalkPoint()
    {
        float randomX = Random.Range(-_walkPointRange, _walkPointRange);
        float randomZ = Random.Range(-_walkPointRange, _walkPointRange);

        _walkPoint = new Vector3(transform.position.x + randomX,transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(_walkPoint, -transform.up, _groundLayer))
        {
            _walkPointSet = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

}
