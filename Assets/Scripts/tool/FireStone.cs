using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class FireStone : MonoBehaviourPunCallbacks
{
    CharacterItems characterItems;
    ToolInteraction toolInteraction;
    Transform fireStoneTransform;
    GameObject player;
    bool isClicked;
    GameObject torch;

    private void Start()
    {
        player = GameObject.Find("Player(Clone)");
        characterItems = GameObject.Find("Player(Clone)").GetComponent<CharacterItems>();
        toolInteraction = GameObject.Find("Canvas/ToolList").GetComponent<ToolInteraction>();
        fireStoneTransform = GameObject.Find("Canvas/ToolList/FireStone/FireStoneImage").GetComponent<Transform>();
        isClicked = false;
        torch = GameObject.Find("Outside/SM_Prop_TorchStick_06/FX_Fire_01");
        torch.GetComponent<ParticleSystem>().Stop();
    }

    private void Update()
    {
        if (isClicked && Input.GetMouseButtonDown(0))
        {
            FireStoneEvent();
        }
    }

    public void onClicked()
    {
        if (characterItems.getFireStone() == 0)
        {
            toolInteraction.showNoFireStone();
            return;
        }
        isClicked = true;
        fireStoneTransform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
    }

    public void FireStoneEvent()
    {

        //Debug.Log("fireStoneevent");
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 20.0f))
        {
            if (hit.transform.GetChild(0) && hit.transform.GetChild(1))
            {
                if (hit.transform.GetChild(0).GetComponent<Light>())
                {
                    Debug.Log("wodeid " + hit.transform.GetChild(0).GetComponent<PhotonView>().ViewID);
                    //Debug.Log("wodeid " + hit.transform.GetChild(1).tag);
                    PhotonView.RPC("lightUP", RpcTarget.All, hit.transform.GetChild(0).GetComponent<PhotonView>().ViewID, hit.transform.GetChild(1).GetComponent<PhotonView>().ViewID);
                    //Debug.Log(hit.transform.GetChild(0).name);
                    isClicked = false;
                    fireStoneTransform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                    characterItems.changeFireStone(-1);
                }
            }
        }
    }

    [PunRPC]
    public void lightUP(int viewID_1, int viewID_2)
    {
        PhotonView.Find(viewID_1).GetComponent<Light>().range = 7;
        Debug.Log("111" + PhotonView.Find(viewID_2).name);
        PhotonView.Find(viewID_2).GetComponent<ParticleSystem>().Play();
        //Debug.Log(tag);
        //Debug.Log(GameObject.FindGameObjectWithTag(tag).name);
        //GameObject.FindGameObjectWithTag(tag).SetActive(true);
    }
}

