using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class BlindDrug : MonoBehaviourPunCallbacks
{
    private GameObject[] players;
    CharacterItems characterItems;
    [SerializeField] GameObject blackScreen;//这个blackScreen应该是对手UI界面里的黑屏？
    [SerializeField] RawImage rawImage;
    private void Awake()
    {
        characterItems = GameObject.Find("Player(Clone)").GetComponent<CharacterItems>();
        //blackScreen = GameObject.Find("Canvas/BlackScreen");
        //rawImage = GameObject.Find("Canvas/BlackScreen").GetComponent<RawImage>();
        rawImage.CrossFadeAlpha(0, 1f, false);
        //rawImage.color = Color.clear;
    }
    public void onClick()
    {
        if(characterItems.getBlindDrug() == 0)
        {
            return;
        }
        players = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 1; i < players.Length; i++)
        {
            PhotonView.RPC("useBlindDrug", RpcTarget.Others);
            //players[i].GetComponent<CharacterStatus>().BackToOrigin();

        }
        characterItems.changeBlindDrug(-1);
        //blackScreen.GetComponent<LoseSight>().beBlind();
    }

    [PunRPC]
    public void useBlindDrug()
    {
        blackScreen = GameObject.Find("Canvas/BlackScreen");
        //blackScreen.GetComponent<LoseSight>().beBlind();
        
        StartCoroutine(Wait());
    }

    IEnumerator Wait() //fade function
    {
        RawImage rawImage;
        rawImage = GameObject.Find("Canvas/BlackScreen").GetComponent<RawImage>();
        Time.timeScale = 1;
        //Debug.Log("yyyyes");
        //yield return new WaitForSeconds(5);
        rawImage.CrossFadeAlpha(1, 1f, false);
        yield return new WaitForSeconds(5);
        rawImage.CrossFadeAlpha(0, 2f, false);
    }
}
