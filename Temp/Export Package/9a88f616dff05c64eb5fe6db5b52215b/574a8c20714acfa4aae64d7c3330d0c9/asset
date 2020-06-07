using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class chestOpen : MonoBehaviourPunCallbacks
{
    private Animation animation;  //动画播放控制

    void Start()
    {
        animation = gameObject.GetComponent<Animation>();
    }

    //void Update()
    //{
    //    Debug.Log("111");
    //    if (Input.GetKeyDown(KeyCode.O))
    //    {
    //        animation.Play("Chest_Open");
    //        Debug.Log("Chest opened");
    //    }
    //}

    public void chestOpenEvent()
    {
        //需要添加选择打开方式界面
        PhotonView.RPC("chestopen", RpcTarget.All);
    }

    [PunRPC]
    public void chestopen()
    {
        animation.Play("Chest_Open");
        Debug.Log("Chest opened");
    }
}
