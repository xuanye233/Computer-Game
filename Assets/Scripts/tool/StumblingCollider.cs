using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class StumblingCollider : MonoBehaviourPunCallbacks
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("111");
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("hahaha");
            //如果人碰到了绊脚石
            other.gameObject.GetComponent<CharacterStatus>().ChangeHealth(-30);
            PhotonView.RPC("deleteStumblingBlock", RpcTarget.MasterClient, gameObject.GetComponent<PhotonView>().ViewID);
            //life--;
            //if (life <= 0)
            //{
            //    Destroy(gameObject);
            //}
        }
    }

    [PunRPC]
    public void deleteStumblingBlock(int ViewID)
    {
        PhotonNetwork.Destroy(PhotonView.Find(ViewID));
    }
}
