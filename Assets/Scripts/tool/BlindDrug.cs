using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class BlindDrug : MonoBehaviourPunCallbacks
{
    private GameObject[] players;
    CharacterItems characterItems;
    //[SerializeField] GameObject blackScreen;//这个blackScreen应该是对手UI界面里的黑屏？
    [SerializeField] RawImage rawImage;
    GameObject curPlayer;
    ThirdPersonUserControl thirdPersonUserControl;
    ToolSound toolSound;
    private void Awake()
    {
        curPlayer = GameObject.Find("Player(Clone)");
        characterItems = curPlayer.GetComponent<CharacterItems>();
        //blackScreen = GameObject.Find("Canvas/BlackScreen");
        //rawImage = GameObject.Find("Canvas/BlackScreen").GetComponent<RawImage>();
        rawImage.CrossFadeAlpha(0, 1f, false);
        rawImage.gameObject.SetActive(false);
        //rawImage.color = Color.clear;
        toolSound = curPlayer.GetComponent<ToolSound>();
        thirdPersonUserControl = GameObject.Find("Player(Clone)").GetComponent<ThirdPersonUserControl>();
    }

    private void Update()
    {
        if (thirdPersonUserControl.canSee)
        {
            StopAllCoroutines();
        }
    }
    public void onClick()
    {
        if (characterItems.getBlindDrug() == 0)
        {
            return;
        }
        PhotonView.RPC("showBlindEffect", RpcTarget.MasterClient, curPlayer.transform.position, curPlayer.GetComponent<CapsuleCollider>().center, curPlayer.transform.localScale.y);

        players = GameObject.FindGameObjectsWithTag("Player");

        //toolSound.Blind(curPlayer.GetComponent<PhotonView>().ViewID);

        //toolSound.Blinded();
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
        //blackScreen = GameObject.Find("Canvas/BlackScreen");
        //blackScreen.GetComponent<LoseSight>().beBlind();    
        thirdPersonUserControl.canSee = false;
        StartCoroutine(Wait());
    }

    IEnumerator Wait() //fade function
    {
        Time.timeScale = 1;
        rawImage.CrossFadeAlpha(0, 0.1f, false);
        yield return new WaitForSeconds(0.1f);
        rawImage.gameObject.SetActive(true);
        rawImage.CrossFadeAlpha(1, 1f, false);
        yield return new WaitForSeconds(5);
        rawImage.CrossFadeAlpha(0, 2f, false);
        rawImage.gameObject.SetActive(false);
        thirdPersonUserControl.canSee = true;
    }

    [PunRPC]
    public void showBlindEffect(Vector3 position, Vector3 center, float scale)
    {
        Vector3 centerPos = position + center * scale * 1.5f;
        PhotonNetwork.Instantiate("Effects/BlindEffect", centerPos, Quaternion.identity, 0);
    }
}
