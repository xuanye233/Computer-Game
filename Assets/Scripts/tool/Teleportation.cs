using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Teleportation : MonoBehaviourPunCallbacks
{
    // 互换位置
    Vector3 myPosition;
    Vector3 othersPosition;
    GameObject curPlayer;
    CharacterItems characterItems;
    bool isClicked;
    [SerializeField]
    GameObject bagButton;
    [SerializeField]
    GameObject bagPanel;
    void Awake()
    {
        curPlayer = GameObject.Find("Player(Clone)");
        characterItems = curPlayer.GetComponent<CharacterItems>();
        isClicked = false;
    }

    private void Update()
    {
        if(isClicked && Input.GetMouseButtonDown(0))
        {
            TeleportationEvent();
        }
    }

    // Update is called once per frame
    public void onClicked()
    {
        if(characterItems.getTeleportation() == 0)
        {
            return;
        }
        isClicked = true;
        bagButton.SetActive(true);
        bagPanel.SetActive(false);
    }

    private void TeleportationEvent()
    {
        Debug.Log("click");
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f)) //作用距离为5.0f
        {
            if (hit.transform)
            {
                if (hit.transform.gameObject.tag == "Player")
                {
                    //othersPosition = hit.transform.position;
                    //myPosition = transform.position;
                    //hit.transform.transform.position = myPosition;
                    //transform.position = othersPosition;
                    PhotonView.RPC("showTeleEffect", RpcTarget.MasterClient, curPlayer.transform.position, curPlayer.GetComponent<CapsuleCollider>().center, curPlayer.transform.localScale.y);
                    //现在的设定是只要是一定范围内的敌人都会被影响
                    Debug.Log("wodeid " + hit.transform.gameObject.GetComponent<PhotonView>().ViewID);

                    myPosition = curPlayer.transform.position;
                    curPlayer.transform.position = hit.transform.position;
                    PhotonView.RPC("changePosition", RpcTarget.Others, hit.transform.gameObject.GetComponent<PhotonView>().ViewID, myPosition);
                    characterItems.changeTeleportation(-1);

                    isClicked = false;
                }
            }
        }
    }

    [PunRPC]
    public void changePosition(int viewID,Vector3 position)
    {
        PhotonView.Find(viewID).transform.position = position;
    }
   
    [PunRPC]
    public void showTeleEffect(Vector3 position, Vector3 center, float scale)
    {
        Vector3 centerPos = position + center * scale * 1.5f;
        PhotonNetwork.Instantiate("Effects/TeleEffect", centerPos, Quaternion.identity, 0);
    }
}
