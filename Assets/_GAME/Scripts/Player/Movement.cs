using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Movement : MonoBehaviourPun
{ 
    private CharacterController controller;
    private Vector3 playerVelocity;
    private float _turnSmoothTime = 0.1f; 
    private float _turnSmoothVelocity; 
    
    [SerializeField]private float playerSpeed = 6.0f;
    
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
   

    void Update()
    {
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targAngle, ref _turnSmoothVelocity, _turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(direction * playerSpeed * Time.deltaTime);
        }

        
    }
}
