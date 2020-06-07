using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ThunderstormCollider : MonoBehaviourPunCallbacks
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("111");
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("hahaha");
            //如果人碰到了绊脚石
            //other.gameObject.GetComponent<CharacterStatus>().ChangeHealth(-30);
            PhotonView.RPC("createPlayerCube", RpcTarget.MasterClient);

        }
    }

    [PunRPC]
    public void createPlayerCube()
    {
        StartCoroutine(Wait());
    }

    public IEnumerator Wait() //fade function
    {
        PhotonNetwork.Destroy(gameObject);
        GameObject obj;
        obj = PhotonNetwork.Instantiate("PlayerCube", GameObject.Find("MapCamera/PlayerCube").transform.position, Quaternion.identity, 0);
        yield return new WaitForSeconds(5);
        PhotonNetwork.Destroy(obj);
        Debug.Log("qwer");
    }
}
