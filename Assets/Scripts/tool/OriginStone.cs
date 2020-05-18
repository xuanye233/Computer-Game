using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

//原生之石：使敌人回到出发点

public class OriginStone : MonoBehaviourPunCallbacks
{
    CharacterItems characterItems;
    CharacterStatus characterStatus;
    GameObject curPlayer;
    [SerializeField] private float minDis = 3.0f; //在这个距离内才能影响到敌人
    private GameObject[] players;
    ToolSound toolSound;
    private void Start()
    {
        curPlayer = GameObject.Find("Player(Clone)");
        characterItems = curPlayer.GetComponent<CharacterItems>();
        characterStatus = curPlayer.GetComponent<CharacterStatus>();
        toolSound = curPlayer.GetComponent<ToolSound>();
    }


    public void onClicked()
    {
        if(characterItems.getOriginStone() == 0)
        {
            //执行文字提示
            //
            return;
        }
        Debug.Log("222 " + curPlayer.transform.position);
        PhotonView.RPC("showOriginEffect", RpcTarget.MasterClient, curPlayer.transform.position, curPlayer.GetComponent<CapsuleCollider>().center, curPlayer.transform.localScale.y);
        //现在的设定是只要是一定范围内的敌人都会被影响
        players = GameObject.FindGameObjectsWithTag("Player");
        Vector3 position = (players[0].transform.position);
        for(int i = 1; i < players.Length; i++)
        {
            Debug.Log(players[i].name);
            
            float dis = Vector3.Distance(players[i].transform.position, position);

            if (dis < minDis)
            {
                Debug.Log(players[i].GetComponent<PhotonView>().ViewID);
                //if (gameObject.Equals(players[i]))
                //{
                //    break;
                //}
                toolSound.Teleport(curPlayer.GetComponent<PhotonView>().ViewID);
                PhotonView.RPC("BackToOrigin", RpcTarget.All, players[i].GetComponent<PhotonView>().ViewID);
                //players[i].GetComponent<CharacterStatus>().BackToOrigin();
            }
        }
        
        characterItems.changeOriginStone(-1);
    }

    [PunRPC]
    public void BackToOrigin(int viewID)
    {
        Debug.Log("origin rpc");
        //当受到对手的原生之石的影响后，回到出发点
        PhotonView.Find(viewID).transform.position = new Vector3(0f, 10f, -42f);
        //PhotonNetwork.Destroy(PhotonView.Find(viewID));
    }

    [PunRPC]
    public void showOriginEffect(Vector3 position, Vector3 center, float scale)
    {
        Vector3 centerPos = position + center * scale * 1.5f;
        PhotonNetwork.Instantiate("Effects/OriginEffect", centerPos, Quaternion.identity, 0);
    }
}
