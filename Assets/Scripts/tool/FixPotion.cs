using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

//定位药水：静止不动

public class FixPotion : MonoBehaviourPunCallbacks
{    
    [SerializeField] private float minDis = 3.0f; //在这个距离内才能影响到敌人
    [SerializeField] private float fixTime = 5.0f; //静止的时间
    private GameObject[] players;
    ThirdPersonUserControl thirdPersonUserControl;
    CharacterItems characterItems;
    GameObject curPlayer;

    public void Awake()
    {
        curPlayer = GameObject.Find("Player(Clone)");
        thirdPersonUserControl = curPlayer.GetComponent<ThirdPersonUserControl>();
        characterItems = curPlayer.GetComponent<CharacterItems>();
    }
    public void onClicked()
    {
        Debug.Log("click");
        if(characterItems.getFixPotion() == 0)
        {
            return;
            //显示没有的文本
        }
        //现在的设定是只要是一定范围内的敌人都会被影响
        //
        Debug.Log("click2");
        PhotonView.RPC("showFixEffect", RpcTarget.MasterClient, curPlayer.transform.position, curPlayer.GetComponent<CapsuleCollider>().center, curPlayer.transform.localScale.y);
        players = GameObject.FindGameObjectsWithTag("Player");        
        for (int i = 0; i < players.Length; i++)
        {
            //float dis = Vector3.Distance(players[i].transform.position, transform.position);

            //if (dis < minDis && dis > 0.01f)
            //{
            //    players[i].GetComponent<ThirdPersonUserControl>().ForbidMove(fixTime);
            //}
            PhotonView.RPC("ForbidMove", RpcTarget.All, players[i].GetComponent<PhotonView>().ViewID, 5.0f);
            //执行函数  执行服务器  函数的参数
        }
    }

    [PunRPC]
    public void ForbidMove(int ViewID, float fixTime)
    {
        PhotonView.Find(ViewID).GetComponent<ThirdPersonUserControl>().canMove = false;
        //Invoke("RecoverMove", fixTime);
        StartCoroutine(Wait(fixTime, ViewID));
    }

    IEnumerator Wait(float waitTime, int ViewID)
    {
        yield return new WaitForSeconds(waitTime);
        PhotonView.Find(ViewID).GetComponent<ThirdPersonUserControl>().canMove = true;
        //等待之后执行的动作
    }
    
    [PunRPC]
    public void showFixEffect(Vector3 position, Vector3 center, float scale)
    {
        Vector3 centerPos = position + center * scale * 1.5f;
        PhotonNetwork.Instantiate("Effects/FixEffect", centerPos, Quaternion.identity, 0);
    }
}
