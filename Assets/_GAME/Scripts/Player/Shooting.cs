using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private int _damage = 3;
    [SerializeField] private AudioSource _gunSound;
    private void Awake()
    {
        _gunSound = GetComponent<AudioSource>();
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.J))
        {
            GunShoot();
            GunAudio();
        }


    }
    private void GunAudio()
    {
        _gunSound.Play();
    }
    public void GunShoot()
    {

        Debug.Log("Dupa");
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        if (Physics.Raycast(transform.position, forward, out hit))
        {
            Debug.DrawRay(transform.position, forward, Color.green);
            Debug.Log(hit.transform.name);
            ITakeDamage mb = hit.transform.GetComponent<ITakeDamage>();

            if (mb != null)
            {
                mb.GetDMG(_damage);
            }
            
        }
    }

}



