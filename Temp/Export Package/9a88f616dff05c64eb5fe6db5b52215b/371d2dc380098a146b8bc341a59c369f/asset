using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("imfirst");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("nConnectedToMaster");

        PhotonNetwork.JoinOrCreateRoom("Room",new Photon.Realtime.RoomOptions { MaxPlayers = 4 }, default);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("OnJoinedRoom");
        PhotonNetwork.Instantiate("Player", new Vector3(0, 10, -38), Quaternion.identity, 0);
        
    }
}
