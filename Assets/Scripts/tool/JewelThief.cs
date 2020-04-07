using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class JewelThief : MonoBehaviourPunCallbacks
{
    private GameObject player;//自身
    CharacterItems characterItems;
    bool isClicked;

    private void Start()
    {
        characterItems = GameObject.Find("Player(Clone)").GetComponent<CharacterItems>();
        player = GameObject.Find("Player(Clone)");
        isClicked = false;//设置为点击玩家进行偷窃
    }

    private void Update()
    {
        if (isClicked && Input.GetMouseButtonDown(0))
        {
            jewelThiefEvent();
            isClicked = false;
        }
    }

    public void onClicked()
    {
        if (characterItems.getJewelThief() == 0)
        {
            //之后加一个文字提示
            return;
        }
        isClicked = true;
    }

    private void jewelThiefEvent()
    {
        Debug.Log("my jewel " + characterItems.getJewel());
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f)) //作用距离为5.0f
        {
            if (hit.transform)
            {
                if (hit.transform.gameObject.tag == "Player")
                {
                    //Debug.Log("wodeid " + hit.transform.gameObject.GetComponent<PhotonView>().ViewID);
                    //Debug.Log("his jewel " + PhotonView.Find(hit.transform.gameObject.GetComponent<PhotonView>().ViewID).GetComponent<CharacterItems>().getJewel());
                    PhotonView.RPC("useJewelThief", RpcTarget.Others, hit.transform.gameObject.GetComponent<PhotonView>().ViewID);
                    
                    characterItems.changeJewelThief(-1);
                }
            }
        }
    }

    [PunRPC]
    public void useJewelThief(int viewID)
    {
        //int totalJewelNum = 3;//假设一共有三种宝石
        //int index = Random.Range(0, totalJewelNum);//随机指定偷取某种颜色的宝石

        int p1 = Random.Range(0, 100);
        int p2 = Random.Range(0, 100);
        //int jewelNum = PhotonView.Find(viewID).getJewelNum(index);
        int jewelNum = PhotonView.Find(viewID).GetComponent<CharacterItems>().getJewel();

        if (jewelNum > 0)//可以被偷
        {
            Debug.Log("keyitoua");
            if (-1 <= p1)//偷成功的概率设置为大于一半
            {
                //PhotonView.Find(viewID).changeJewel(index, -1);
                PhotonView.Find(viewID).GetComponent<CharacterItems>().changeJewel(-1);
                //Debug.Log("his jewel " + PhotonView.Find(viewID).GetComponent<CharacterItems>().getJewel());
                //characterItems.changeJewel(index,1);
                characterItems.changeJewel(1);
                //己方文字提示“偷取成功！”
                //对方文字提示“您的宝石被偷了！”
            }
        }
    }
}
