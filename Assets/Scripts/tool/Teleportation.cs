using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Teleportation : MonoBehaviourPunCallbacks
{
    // 互换位置
    Vector3 myPosition;
    Vector3 othersPosition;
    GameObject player;
    CharacterItems characterItems;
    bool isClicked;
    void Awake()
    {
        player = GameObject.Find("Player(Clone)");
        characterItems = GameObject.Find("Player(Clone)").GetComponent<CharacterItems>();
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
                    Debug.Log("wodeid " + hit.transform.gameObject.GetComponent<PhotonView>().ViewID);

                    myPosition = player.transform.position;
                    player.transform.position = hit.transform.position;
                    PhotonView.RPC("changePosition", RpcTarget.Others, hit.transform.gameObject.GetComponent<PhotonView>().ViewID, myPosition);
                    characterItems.changeTeleportation(-1);
                }
            }
        }
    }

    [PunRPC]
    public void changePosition(int viewID,Vector3 position)
    {
        PhotonView.Find(viewID).transform.position = position;
    }
}
