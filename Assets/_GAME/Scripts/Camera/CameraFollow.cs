using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]private GameObject _player;
    private Vector3 _difference; //Oblicza r�nice pomi�dzy graczem a kamer� 
    private void Awake()
    {
        Vector3 Difference = new Vector3(0,0,0);   
    }

    // Update is called once per frame
    void Update()
    {
         
    }
}
