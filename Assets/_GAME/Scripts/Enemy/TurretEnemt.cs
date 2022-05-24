using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemt : MonoBehaviour
{
    [SerializeField] private float _radius = 10f;
    [SerializeField] private LayerMask _targetLayerMask;
    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius, _targetLayerMask);
        
        if (hitColliders.Length>0)
        {
            transform.LookAt(hitColliders[0].gameObject.transform);
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
