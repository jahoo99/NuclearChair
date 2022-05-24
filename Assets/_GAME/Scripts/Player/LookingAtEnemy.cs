using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingAtEnemy : MonoBehaviour
{
    [SerializeField]private float _radius;
    [SerializeField]private LayerMask _enemyLayer;
    private Transform _nearestEnemy;
    private bool _idented = false; //zeruje rotacje XD

    private void Update()
    {
        Collider[] _enemy = Physics.OverlapSphere(transform.position, _radius, _enemyLayer);
        
        for (int i = 0; i <= _enemy.Length; i++)
        {
            if (_enemy.Length > 0)
            {
                Debug.Log("Idented!");
                transform.LookAt(_enemy[0].transform.position);
                _idented = false;
            }
            else if(!_idented)
            {
                
                transform.parent.rotation = Quaternion.identity;
                transform.rotation = Quaternion.identity;
                _idented = true;
            }
        }
        
     
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
