using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;

using Photon.Pun.Demo.PunBasics;

public class CharacterStatus : MonoBehaviourPunCallbacks, IPunObservable
{
    //[SerializeField] GameObject healthUI; //show the current health
    float health; //Character HP
    public string username;
    CharacterItems items;
    GameObject mainCamera;
    CapsuleCollider capsuleCol;

    RawImage rawImage;

    private int lastSecond;

    #region Public Fields
    [Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]
    public static GameObject LocalPlayerInstance;
    #endregion

   void Awake()
    {
        if (PhotonView.IsMine)
        {
            UILabel lbl = this.gameObject.transform.Find("NamePanel").GetComponentInChildren<UILabel>();
            lbl.text = PhotonNetwork.NickName;
            Debug.Log("lbl.text=" + lbl.text);
            PlayerManager.LocalPlayerInstance = this.gameObject;          
        }
        else
        {
            UILabel lbl = this.gameObject.transform.Find("NamePanel").GetComponentInChildren<UILabel>();
            lbl.text = PhotonView.Owner.NickName;
            Debug.Log("lbl.text=" + lbl.text);
            PlayerManager.LocalPlayerInstance = this.gameObject;
        }
        // #Critical
        // we flag as don't destroy on load so that instance survives level synchronization, thus giving a seamless experience when levels load.
        DontDestroyOnLoad(this.gameObject);
        username = GlobalData.playerName;
        Debug.Log("your name:" + username);
    }

    void Start()
    {
        //CameraWork _cameraWork = this.gameObject.GetComponent<CameraWork>();


        //if (_cameraWork != null)
        //{
        //    if (photonView.IsMine)
        //    {
        //        _cameraWork.OnStartFollowing();
        //    }
        //}
        //else
        //{
        //    Debug.LogError("<Color=Red><a>Missing</a></Color> CameraWork Component on playerPrefab.", this);
        //}
        rawImage = GameObject.Find("GameManager").GetComponent<Com.MyCompany.MyGame.GameManager>().blackScreen;

        lastSecond = DateTime.Now.Second;
        items = GetComponent<CharacterItems>();
        capsuleCol = GetComponent<CapsuleCollider>();
        health = 50f;
        if (mainCamera == null)
        {
            mainCamera = GameObject.Find("Camera");
        }
    }

    void FixedUpdate()
    {
        if (!PhotonView.IsMine && PhotonNetwork.IsConnected)
        {
            return;
        }
        if (health <= 0 /*&& aliveFlag==true*/)
        {
            rawImage.gameObject.SetActive(true);
            rawImage.CrossFadeAlpha(1, 0.5f, false);
            StartCoroutine(getBlack(1.0f));//页面变黑
            return;
        }

        if (DateTime.Now.Second != lastSecond)
        {
            lastSecond = DateTime.Now.Second;
            if(GlobalData.characterIndex == 2)//如果当前角色为石头人则血量流失速度减半
            {
                ChangeHealth(-0.5f);
            }
            else
            {
                ChangeHealth(-1f);
            }
            
        }
      
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("fallPlane"))
        {
            StartCoroutine(ChangePosWhileBlack());//黑屏时改变人物和相机的位置
        }
        if (other.gameObject.CompareTag("Thunderstorm2"))
        {
            //Debug.Log("huaweihuawei");
            PhotonNetwork.Destroy(other.gameObject);
            PhotonView.RPC("createPlayerCube", RpcTarget.MasterClient);
        }
        if (other.gameObject.CompareTag("Stumbling2"))
        {
            //Debug.Log("huaweihuawei");
            health -= 30;
            PhotonView.RPC("deleteStumblingBlock", RpcTarget.MasterClient, other.gameObject.GetComponent<PhotonView>().ViewID);
        }
    }

    IEnumerator getBlack(float waitTime) //新增，页面渐变成黑色
    {
        Debug.Log("???");
        yield return new WaitForSeconds(waitTime);
        //rawImage.gameObject.SetActive(false);
        GameObject.Find("GameManager").GetComponent<Com.MyCompany.MyGame.GameManager>().LeaveRoom();
    }

    IEnumerator ChangePosWhileBlack()
    {
        yield return new WaitForSeconds(0.5f);
        transform.position = new Vector3(0f, 5f, -52f);
        if (PhotonView.IsMine)
        {
            mainCamera.transform.position = new Vector3(0f, 10f, -4f);
        }
    }

    public void ChangeHealth(float increaseNum)
    {
        health = health + increaseNum > 100 ? 100 : health + increaseNum;
        if(health < 0)
        {
            health = 0;
        }
    }


    public float GetHealth()
    {
        return health;
    }


    //public void destroyFood(int viewID)
    //{
    //    PhotonNetwork.Destroy(PhotonView.Find(viewID));
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "ThunderStorm")
        {
            //Destroy(collision.collider.gameObject);
            PhotonView.RPC("showThunderEffect", RpcTarget.MasterClient);
            int viewID = collision.collider.gameObject.GetComponent<PhotonView>().ViewID;
            Vector3 position = GameObject.Find("MapCamera/PlayerCube").transform.position;
            Debug.Log(position);
            float time = 2.0f;
            if (GlobalData.characterIndex == 1)//第一个人物受道具负面影响降低50%
            {
                time = 1.0f;
            }
            PhotonView.RPC("ThunderStormEvent", RpcTarget.MasterClient, viewID, position, time);
        }

        if (collision.collider.tag == "StumblingBlock")
        {
            PhotonView.RPC("showStumblingEffect", RpcTarget.MasterClient);
            int viewID = collision.collider.gameObject.GetComponent<PhotonView>().ViewID;            
            PhotonView.RPC("StumblingBlockEvent", RpcTarget.MasterClient, viewID);
            if (GlobalData.characterIndex == 1)//第一个人物受道具负面影响降低50%
            {
                ChangeHealth(-10f);
            }
            else ChangeHealth(-20f);
        }
    }

    [PunRPC]
    public void ThunderStormEvent(int viewID, Vector3 position, float time)
    {
        PhotonNetwork.Destroy(PhotonView.Find(viewID));
        StartCoroutine(Wait(position, time));
    }

    [PunRPC]
    public void StumblingBlockEvent(int viewID)
    {
        PhotonNetwork.Destroy(PhotonView.Find(viewID));
    }

    IEnumerator Wait(Vector3 position, float time) //fade function
    {
        Time.timeScale = 1;
        GameObject gameobj;
        gameobj = PhotonNetwork.Instantiate("PlayerCube", position + new Vector3(0, -9, 0), Quaternion.identity, 0);
        //gameobj.transform.position = position + new Vector3(0,-5,0);
        yield return new WaitForSeconds(time);
        PhotonNetwork.Destroy(gameobj);
        //PhotonNetwork.
    }

    [PunRPC]
    public void showStumblingEffect()
    {
        Vector3 centerPos = transform.position + capsuleCol.center * transform.localScale.y * 1.5f;
        PhotonNetwork.Instantiate("Effects/StumblingEffect", centerPos, Quaternion.identity, 0);
    }

    [PunRPC]
    public void showThunderEffect()
    {
        Vector3 centerPos = transform.position + capsuleCol.center * transform.localScale.y * 1.5f;
        PhotonNetwork.Instantiate("Effects/ThunderEffect", centerPos, Quaternion.identity, 0);
    }

    [PunRPC]
    public void ThunderStormSound(int viewID)
    {
        PhotonView.Find(viewID).GetComponent<ToolSound>().Thunder();
    }

    [PunRPC]
    public void StumblingBlockSound(int viewID)
    {
        PhotonView.Find(viewID).GetComponent<ToolSound>().Hurt();
    }

    [PunRPC]
    public void deleteStumblingBlock(int ViewID)
    {
        PhotonNetwork.Destroy(PhotonView.Find(ViewID));
    }

    [PunRPC]
    public void createPlayerCube()
    {
        StartCoroutine(Wait());
    }

    public IEnumerator Wait() //fade function
    {
        GameObject obj;
        obj = PhotonNetwork.Instantiate("PlayerCube", GameObject.Find("MapCamera/PlayerCube").transform.position, Quaternion.identity, 0);
        yield return new WaitForSeconds(5);
        PhotonNetwork.Destroy(obj);
        Debug.Log("qwer");
    }

    #region IPunObservable implementation


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //using network to send and receive message

        //if (stream.IsWriting)
        //{
        //    // We own this player: send the others our data
        //    stream.SendNext(IsFiring);
        //}
        //else
        //{
        //    // Network player, receive data
        //    this.IsFiring = (bool)stream.ReceiveNext();
        //}
    }


    #endregion
}
