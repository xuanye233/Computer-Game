using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ToolSound : MonoBehaviourPunCallbacks
{
    public AudioSource sound1;
    public AudioSource sound2;
    public AudioClip bat1;
    public AudioClip bat2;
    public AudioClip bat3;
    public AudioClip blind;
    public AudioClip blinded;
    public AudioClip caveBGM;
    //public AudioClip click;
    public AudioClip discard;
    public AudioClip eat;
    public AudioClip fireStone;
    public AudioClip get;
    public AudioClip heal;
    public AudioClip heartBeat;
    public AudioClip hurt;
    public AudioClip hurtWoman;
    public AudioClip letNotMove;
    public AudioClip notMove;
    public AudioClip set;
    public AudioClip steal;
    public AudioClip talkBox;
    public AudioClip teleport;
    public AudioClip thunder;
    public AudioClip victory;
    int curViewID;
    GameObject curPlayer;
    // Start is called before the first frame update
    void Start()
    {
        sound1 = gameObject.GetComponents<AudioSource>()[0];
        sound2 = gameObject.GetComponents<AudioSource>()[1];
        bat1 = Resources.Load<AudioClip>("music/bat1");
        bat2 = Resources.Load<AudioClip>("music/bat2");
        bat3 = Resources.Load<AudioClip>("music/bat3");
        blind = Resources.Load<AudioClip>("music/useBlindDrug");
        blinded = Resources.Load<AudioClip>("music/blind");
        caveBGM = Resources.Load<AudioClip>("music/caveBGM");
        //click = Resources.Load<AudioClip>("music/click");
        discard = Resources.Load<AudioClip>("music/discard");
        eat = Resources.Load<AudioClip>("music/eat");
        fireStone = Resources.Load<AudioClip>("music/firestone");
        get = Resources.Load<AudioClip>("music/get");
        heal = Resources.Load<AudioClip>("music/heal");
        heartBeat = Resources.Load<AudioClip>("music/heartBeat");
        hurt = Resources.Load<AudioClip>("music/hurt");
        hurtWoman = Resources.Load<AudioClip>("music/hurt_woman");
        letNotMove = Resources.Load<AudioClip>("music/useBlindDrug");
        notMove = Resources.Load<AudioClip>("music/notMove");
        set = Resources.Load<AudioClip>("music/set");
        steal = Resources.Load<AudioClip>("music/steal");
        talkBox = Resources.Load<AudioClip>("music/talkBox");
        teleport = Resources.Load<AudioClip>("music/teleport");
        thunder = Resources.Load<AudioClip>("music/thunder");
        victory = Resources.Load<AudioClip>("music/victory");
        curPlayer = GameObject.Find("Player(Clone)");
        curViewID = curPlayer.GetComponent<PhotonView>().ViewID;
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void Bat1()
    {
        sound2.clip = bat1;
        sound2.Play();
    }

    public void Bat2()
    {
        sound2.clip = bat2;
        sound2.Play();
    }

    public void Bat3()
    {
        sound2.clip = bat3;
        sound2.Play();
    }

    public void Blinded()
    {
        PhotonView.RPC("BlindedRpc", RpcTarget.Others);
    }

    public void BlindedSound()
    {
        sound2.clip = blind;
        sound2.Play();
    }

    public void Blind(int viewID)
    {
        PhotonView.RPC("BlindRpc", RpcTarget.All, viewID);
    }

    public void BlindSound()
    {
        sound2.clip = blind;
        sound2.Play();
    }

    public void CaveBGM()
    {
        sound2.clip = caveBGM;
        sound2.Play();
    }

    /*public void Click()
    {
        sound2.clip = click;
        sound2.Play();
    }*/

    public void Discard()
    {
        sound2.clip = discard;
        sound2.Play();
    }

    public void Eat(int viewID)
    {
        PhotonView.RPC("EatRpc", RpcTarget.All, viewID);
    }

    public void EatSound()
    {
        sound2.clip = eat;
        sound2.Play();
    }

    public void FireStone(int viewID)
    {
        PhotonView.RPC("FireStoneRpc", RpcTarget.All, viewID);
    }

    public void FireStoneSound()
    {
        sound2.clip = fireStone;
        sound2.Play();
    }


    public void Get(int viewID)
    {
        PhotonView.RPC("GetRpc", RpcTarget.All, viewID);
    }

    public void GetSound()
    {
        sound2.clip = get;
        sound2.Play();
    }

    public void Heal(int viewID)
    {
        PhotonView.RPC("HealRpc", RpcTarget.All, viewID);
    }

    public void HealSound()
    {
        sound2.clip = heal;
        sound2.Play();
    }

    public void HeartBeat()
    {
        sound2.clip = heartBeat;
        sound2.Play(); 
    }

    public void Hurt()
    {
        sound2.clip = hurt;
        sound2.Play();
    }

    public void HurtWoman()
    {
        sound2.clip = hurtWoman;
        sound2.Play();
    }

    public void LetNotMove(int viewID)
    {
        PhotonView.RPC("LetNotMoveRpc", RpcTarget.All, viewID);
    }
    public void LetNotMoveSound()
    {
        sound2.clip = notMove;
        sound2.Play();
    }

    public void NotMove()
    {
        PhotonView.RPC("NotMoveRpc", RpcTarget.Others);
    }
    public void NotMoveSound()
    {
        sound2.clip = notMove;
        sound2.Play();
    }

    public void SetSound()
    {
        sound2.clip = set;
        sound2.Play();
    }

    public void Set(int viewID)
    {
        PhotonView.RPC("SetRpc", RpcTarget.All, viewID);
    }

    public void StealSound()
    {
        sound2.clip = steal;
        sound2.Play();
    }

    public void Steal(int viewID)
    {
        PhotonView.RPC("StealRpc", RpcTarget.All, viewID);
    }

    public void TalkBox()
    {
        sound2.clip = talkBox;
        sound2.Play();
    }

    public void Teleport(int viewID)
    {
        PhotonView.RPC("TeleportRpc", RpcTarget.All, viewID);
    }

    public void TeleportSound()
    {
        sound2.clip = teleport;
        sound2.Play();
    }

    public void Thunder()
    {
        sound2.clip = thunder;
        sound2.Play();
    }

    public void Victory()
    {
        sound2.clip = victory;
        sound2.Play();
    }

    [PunRPC]
    public void BlindRpc(int viewID)
    {
        PhotonView.Find(viewID).GetComponent<ToolSound>().BlindSound();
    }

    [PunRPC]
    public void BlindedRpc()
    {
        PhotonView.Find(curViewID).GetComponent<ToolSound>().BlindedSound();
    }

    [PunRPC]
    public void EatRpc(int viewID)
    {  
        PhotonView.Find(viewID).GetComponent<ToolSound>().EatSound();
    }

    [PunRPC]
    public void FireStoneRpc(int viewID)
    {
        PhotonView.Find(viewID).GetComponent<ToolSound>().FireStoneSound();
    }

    [PunRPC]
    public void GetRpc(int viewID)
    {
        PhotonView.Find(viewID).GetComponent<ToolSound>().GetSound();
    }

    [PunRPC]
    public void HealRpc(int viewID)
    {
        PhotonView.Find(viewID).GetComponent<ToolSound>().HealSound();
    }

    [PunRPC]
    public void NotMoveRpc()
    {
        PhotonView.Find(curViewID).GetComponent<ToolSound>().NotMoveSound();
    }

    [PunRPC]
    public void LetNotMoveRpc(int viewID)
    {
        PhotonView.Find(viewID).GetComponent<ToolSound>().LetNotMoveSound();
    }

    [PunRPC]
    public void SetRpc(int viewID)
    {
        PhotonView.Find(viewID).GetComponent<ToolSound>().SetSound();
    }

    [PunRPC]
    public void StealRpc(int viewID)
    {
        PhotonView.Find(viewID).GetComponent<ToolSound>().StealSound();
    }

    [PunRPC]
    public void TeleportRpc(int viewID)
    {
        PhotonView.Find(viewID).GetComponent<ToolSound>().TeleportSound();
    }
}
