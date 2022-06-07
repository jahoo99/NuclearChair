using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerScriptDestroyer : MonoBehaviourPun
{
    public Movement _movement;
    private void Start()
    {
        if (!photonView.IsMine)
        {
            Destroy(_movement);
        }
    }
}
