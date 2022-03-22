using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingAtEnemy : MonoBehaviour
{
    [SerializeField]private float _radius;
    [SerializeField]private LayerMask _enemyLayer;
    private Transform _nearestEnemy;
    private void Update()
    {
        Collider[] _enemy = Physics.OverlapSphere(transform.position, _radius, _enemyLayer);
        
        for (int i = 0; i <= _enemy.Length; i++)
        {
            if (_enemy.Length > 0)
            {
                transform.LookAt(_enemy[0].transform.position);
            }
            else
            {
                transform.rotation = Quaternion.identity;
            }
        }
        
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
