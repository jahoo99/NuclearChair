using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField]private int _dmg = 6;
    [SerializeField]private float _radius;
    [SerializeField]private LayerMask _layer;
    private void OnTriggerEnter(Collider other)
    {
        ITakeDamage mb = other.transform.GetComponent<ITakeDamage>();
        if (mb != null)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius, _layer);
            foreach (var hitCollider in hitColliders)
            {
                hitCollider.transform.GetComponent<ITakeDamage>().GetDMG(_dmg);
            }
            Destroy(this.gameObject);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
