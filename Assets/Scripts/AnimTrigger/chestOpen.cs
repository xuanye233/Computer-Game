using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class chestOpen : MonoBehaviourPunCallbacks
{
    private Animation animation;  //动画播放控制
    GameObject curPlayer;
    ToolSound toolSound;
    bool isOpen;
    bool isPick;
    Gem gem;
    TakeAndDrop takeAndDrop;

    void Start()
    {
        curPlayer = GameObject.Find("Player(Clone)");
        toolSound = curPlayer.GetComponent<ToolSound>();
        animation = gameObject.GetComponent<Animation>();
        isOpen = false;
        isPick = false;
        gem = GameObject.Find("Canvas/Gems").GetComponent<Gem>();
        takeAndDrop = GameObject.Find("Player(Clone)").GetComponent<TakeAndDrop>();
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
        if (isPick)
        {
            return;
        }
        else if (isOpen)
        {
            //拿宝石
            PhotonView.RPC("pickGem", RpcTarget.MasterClient);
            toolSound.Get(curPlayer.GetComponent<PhotonView>().ViewID);
            isPick = true;
            return;
        }
        else
        {
            PhotonView.RPC("chestopen", RpcTarget.All);
            toolSound.OpenCase(curPlayer.GetComponent<PhotonView>().ViewID);
            isOpen = true;
        }

    }

    [PunRPC]
    public void chestopen()
    {
        animation.Play("Chest_Open");
        Debug.Log("Chest opened");
    }

    [PunRPC]
    public void pickGem()
    {
        GameObject obj = gameObject.transform.parent.gameObject.transform.GetChild(0).gameObject;
        if (obj.tag == "gemA")
        {
            gem.changeA(1);
            takeAndDrop.showTakeGemA(takeAndDrop.Playername);
        }
        else if (obj.tag == "gemB")
        {
            gem.changeB(1);
            takeAndDrop.showTakeGemB(takeAndDrop.Playername);
        }
        else if (obj.tag == "gemC")
        {
            gem.changeC(1);
            takeAndDrop.showTakeGemC(takeAndDrop.Playername);
        }
        else if (obj.tag == "gemD")
        {
            gem.changeD(1);
            takeAndDrop.showTakeGemD(takeAndDrop.Playername);
        }
        PhotonNetwork.Destroy(obj);
    }
}
