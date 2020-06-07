using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class WalkSound : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public AudioSource sound1;
    public AudioSource sound2;
    public AudioSource sound3;
    private bool isWalking;
    bool isJumping;
    bool isQuickMove;
    bool isNormalMove;
    bool isSlowMove;
    public AudioClip jump;
    public AudioClip walk;
    GameObject player;

    void Start()
    {
        sound1 = gameObject.GetComponents<AudioSource>()[0];
        sound2 = gameObject.GetComponents<AudioSource>()[2];
        isWalking = false;
        isJumping = false;
        isQuickMove = false;
        isNormalMove = false;
        isSlowMove = false;
        player = GameObject.Find("Player(Clone)");
        jump = Resources.Load<AudioClip>("music/Jump");
        walk = Resources.Load<AudioClip>("music/Walk");
        sound1.clip = walk;
        sound2.clip = jump;

    }

    // Update is called once per frame
    void turnToWalk()
    {
        isJumping = false;
    }


    public void StartMove()
    {
        sound1.Play();
   
    }

    public void StartMove1()
    {
        isWalking = true;
    }

    public void StopMove()
    {
        sound1.Stop();
  
    }

    public void StopMove1()
    {
        isWalking = false;
        isQuickMove = false;
        isNormalMove = false;
        isSlowMove = false;
    }

    public void QuickMove()
    {
        sound1.pitch = 1.2f;
        sound1.volume = 0.8f;

    }


    public void QuickMove1()
    {

        isQuickMove = true;
        isNormalMove = false;
        isSlowMove = false;
    }

    public void SlowMove()
    {
        sound1.pitch = 0.74f;
        sound1.volume = 0.05f;

    }

    public void SlowMove1()
    {
        isQuickMove = false;
        isNormalMove = false;
        isSlowMove = true;
    }


    public void NormalMove()
    {
        sound1.pitch = 1.0f;
        sound1.volume = 0.6f;

    }

    public void NormalMove1()
    {

        isQuickMove = false;
        isNormalMove = true;
        isSlowMove = false;
    }

    public void Jumping()
    {
 
        if (sound1.isPlaying)
        {
            sound1.Stop();
            sound2.Play();
            isWalking = false;
            Invoke("turnToWalk", 0.8f);
        }
        else
        {
            sound2.Play();
            Invoke("turnToWalk", 0.8f);
        }
    }

    public void Jumping1()
    {
        isJumping = true;
        isQuickMove = false;
        isNormalMove = false;
        isSlowMove = false;
    }

    void Update()
    {
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && !isJumping&&!isWalking)
        {
            PhotonView.RPC("startMove", RpcTarget.All, player.GetComponent<PhotonView>().ViewID);
            StartMove1();
        }

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && isWalking)
        {
            PhotonView.RPC("stopMove", RpcTarget.All, player.GetComponent<PhotonView>().ViewID);
            StopMove1();
        }

        if (Input.GetKey(KeyCode.LeftShift) && isWalking&&!isQuickMove )
        {
            PhotonView.RPC("quickMove", RpcTarget.All, player.GetComponent<PhotonView>().ViewID);
            QuickMove1();
        }

        if (Input.GetKey(KeyCode.C) && isWalking&&!isSlowMove )
        {
            PhotonView.RPC("slowMove", RpcTarget.All, player.GetComponent<PhotonView>().ViewID);
            SlowMove1();
        }

        if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.C)&&isWalking&&!isNormalMove)
        {
            PhotonView.RPC("normalMove", RpcTarget.All, player.GetComponent<PhotonView>().ViewID);
            NormalMove1();
        }

        if (Input.GetKeyDown(KeyCode.Space) &&!isJumping&&!isSlowMove )
        {
            PhotonView.RPC("jumping", RpcTarget.All, player.GetComponent<PhotonView>().ViewID);
            Jumping1();
        }

    }

    [PunRPC]
    public void startMove(int viewID)
    {
        PhotonView.Find(viewID).GetComponent<WalkSound>().StartMove();
    }

    [PunRPC]
    public void stopMove(int viewID)
    {
        PhotonView.Find(viewID).GetComponent<WalkSound>().StopMove();
    }

    [PunRPC]
    public void quickMove(int viewID)
    {
        PhotonView.Find(viewID).GetComponent<WalkSound>().QuickMove();
    }

    [PunRPC]
    public void slowMove(int viewID)
    {
        PhotonView.Find(viewID).GetComponent<WalkSound>().SlowMove();
    }

    [PunRPC]
    public void normalMove(int viewID)
    {
        PhotonView.Find(viewID).GetComponent<WalkSound>().NormalMove();
    }

    [PunRPC]
    public void jumping(int viewID)
    {
        PhotonView.Find(viewID).GetComponent<WalkSound>().Jumping();
    }
}

