﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EDU_fireStone : MonoBehaviour
{
    [SerializeField]
    EDU_process eDU_Process;
    CharacterItems characterItems;
    //ToolInteraction toolInteraction;
    [SerializeField]
    Transform fireStoneTransform;
    GameObject player;
    public bool isClicked;
    GameObject torch;
    [SerializeField]
    ToolMenuControl toolMenuControl;
    //[SerializeField]
    //Text noFireStoneText;
    //[SerializeField]
    //GameObject bagButton;
    //[SerializeField]
    //GameObject bagPanel;
    EDU_toolSound toolSound;
    private void Start()
    {
        player = GameObject.Find("Player(Clone)");
        characterItems = GameObject.Find("Player(Clone)").GetComponent<CharacterItems>();
        //toolInteraction = GameObject.Find("Canvas/ToolList").GetComponent<ToolInteraction>();
        //fireStoneTransform = GameObject.Find("Canvas/ToolList/FireStone/FireStoneImage").GetComponent<Transform>();
        isClicked = false;
        //torch = GameObject.Find("Outside/SM_Prop_TorchStick_06/FX_Fire_01");
        //torch.GetComponent<ParticleSystem>().Stop();
        toolSound = player.GetComponent<EDU_toolSound>();
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
            //showNoFireStone();
            return;
        }
        isClicked = true;
        fireStoneTransform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        //bagPanel.SetActive(false);
        //bagButton.SetActive(true);
    }

    public void FireStoneEvent()
    {

        Debug.Log("fireStoneevent");
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 20.0f))
        {
            Debug.Log(hit.transform.gameObject.name);
            Debug.Log(hit.transform.GetChild(0));
            Debug.Log(hit.transform.GetChild(1));
            if (hit.transform.GetChild(0) && hit.transform.GetChild(1))
            {
                Debug.Log("???");
                if (hit.transform.GetChild(0).GetComponent<Light>())
                {
                    //Debug.Log("wodeid " + hit.transform.GetChild(0).GetComponent<PhotonView>().ViewID);
                    //Debug.Log("wodeid " + hit.transform.GetChild(1).tag);
                    //Debug.Log(hit.transform.gameObject.name);
                    //PhotonView.RPC("hello", RpcTarget.All);
                    toolSound.FireStone();
                    //PhotonView.RPC("lightUP", RpcTarget.All, hit.transform.GetChild(0).GetComponent<PhotonView>().ViewID, hit.transform.GetChild(1).GetComponent<PhotonView>().ViewID);
                    //Debug.Log(hit.transform.GetChild(0).name);
                    hit.transform.GetChild(0).GetComponent<Light>().range = 7;
                    hit.transform.GetChild(1).GetComponent<ParticleSystem>().Play();
                    isClicked = false;
                    fireStoneTransform.localScale = new Vector3(1f, 1f, 1f);
                    characterItems.changeFireStone(-1);
                    eDU_Process.clickTorchEvent();
                    toolMenuControl.transparent();
                }
            }
        }
    }
}
