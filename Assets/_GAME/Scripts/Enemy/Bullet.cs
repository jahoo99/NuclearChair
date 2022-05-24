using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]private float speed = 200f;
    private Rigidbody _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        _rb.AddForce(transform.up * speed);
    }
    private void Start()
    {
        Destroy(this.gameObject, 5);
    }
    private int _dmg = 5;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        ITakeDamage mb = other.transform.GetComponent<ITakeDamage>();
        Debug.Log(mb);
        if (mb != null)
        {
            mb.GetDMG(_dmg);
            Destroy(this.gameObject);
        }
    }

}
