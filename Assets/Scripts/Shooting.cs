using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.J))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hitData;
            Physics.Raycast(ray, out hitData);
            Debug.Log(hitData.distance);
        }


    }
}



