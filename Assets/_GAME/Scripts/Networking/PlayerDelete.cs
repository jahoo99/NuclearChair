using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Linq;

public class PlayerDelete : MonoBehaviour
{
    //private GameObject[] _players;
    //private GameObject _player;
    public PlayerHP[] _players;
    private int arrayID;
    private int[] ID = new int[2];
    private int secondID;
    private void Start()
    {
        StartCoroutine(Destroyerr());
    }
    public IEnumerator Destroyerr()
    {
        yield return new WaitForSeconds(3);
        _players = FindObjectsOfType<PlayerHP>();
        List<PlayerHP> _playersList = _players.ToList();

        Debug.Log(_playersList.Count);
        Debug.Log(_players);
        foreach (var player in _players.ToList())
        {
            if (player.GetComponent<PhotonView>().IsMine)
            {
                _playersList.Remove(player);
            }
        }
        if (_playersList.Count==2)
        {
            Debug.Log("Dzia³a?");
            if (_playersList[0].GetComponent<PhotonView>().ViewID > _playersList[1].GetComponent<PhotonView>().ViewID)
            {
                Destroy(_playersList[1].gameObject);
            }
            else
            {
                Destroy(_playersList[0].gameObject);
            }
        }
        
    }
    

}
