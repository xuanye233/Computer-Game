using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Photon.Pun;

using System.Collections;
using Photon.Pun.Demo.PunBasics;

public class CharacterStatus : MonoBehaviourPunCallbacks, IPunObservable
{
    //[SerializeField] GameObject healthUI; //show the current health
    float health; //Character HP
    CharacterItems items;
    GameObject mainCamera;
    CapsuleCollider capsuleCol;

    #region Public Fields
    [Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]
    public static GameObject LocalPlayerInstance;
    #endregion

   void Awake()
    {
        if (PhotonView.IsMine)
        {
            PlayerManager.LocalPlayerInstance = this.gameObject;           
        }
        // #Critical
        // we flag as don't destroy on load so that instance survives level synchronization, thus giving a seamless experience when levels load.
        DontDestroyOnLoad(this.gameObject);
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
        items = GetComponent<CharacterItems>();
        capsuleCol = GetComponent<CapsuleCollider>();
        health = 50f;
        if (mainCamera == null)
        {
            mainCamera = GameObject.Find("Camera");
        }
    }

    void Update()
    {
        if (!PhotonView.IsMine && PhotonNetwork.IsConnected)
        {
            return;
        }
        if (health <= 0)
        {
            //GameObject.Find("GameManager").SendMessage("LeaveRoom()");
            GameObject.Find("GameManager").GetComponent<GameManager>().LeaveRoom();
            //GameManager.
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("fallPlane"))
        {
            StartCoroutine(ChangePosWhileBlack());//黑屏时改变人物和相机的位置
        }

        //#if false
        //        if (other.gameObject.CompareTag("Food"))
        //        {
        //            //碰到食物后增加一些体力
        //            /*------------------------*/
        //            //IncreaseHealth(10f);
        //            //healthUI.GetComponent<IncreaseHealth>().increaseScore(10);
        //            Debug.Log("体力增加了");
        //            other.gameObject.SetActive(false);
        //        }


        //        else if (other.gameObject.CompareTag("Sewage"))
        //        {
        //            //碰到污水减少体力
        //            //------------------------
        //            //DecreaseHealth(10f)
        //            //healthUI.GetComponent<DecreaseHealth>().decreaseScore(10);
        //            Debug.Log("碰到污水体力减少");
        //        }

        //        else if (other.gameObject.CompareTag("Mice"))
        //        {
        //            //碰到鼠群减少体力
        //            //-------------------------
        //            //DecreaseHealth(10f)
        //            //healthUI.GetComponent<DecreaseHealth>().decreaseScore(10);
        //            Debug.Log("碰到老鼠群体力减少");
        //        }

        //        else if (other.gameObject.CompareTag("Key"))
        //        {
        //            //碰到钥匙后增加钥匙（不是碰到就能捡起来，应该还要加一些交互操作
        //            //-----------------------------
        //            int index = -1;
        //            //index=other的钥匙index值
        //            items.addKey(index);
        //            Debug.Log("捡到了钥匙" + index);
        //        }

        //        else if (other.gameObject.CompareTag("Firestone"))
        //        {
        //            //捡到打火石，需要补充交互操作
        //            //-----------------------------
        //            items.increaseFirestone(1);
        //            Debug.Log("捡到一个打火石");
        //        }

        //        else if (other.gameObject.CompareTag("Player"))
        //        {
        //            //偷钥匙？？
        //            //加一些玩家交互操作---------------------------------
        //            //-----------------------------
        //            //偷钥匙成功
        //            List<int> oppKeys = other.GetComponent<CharacterItems>().getKeys();
        //            for (int i = 0; i < oppKeys.Count; i++)
        //            {
        //                items.addKey(oppKeys[i]);
        //            }

        //        }

        //        else if (other.gameObject.CompareTag("Door"))
        //        {
        //            //开门
        //            int index = 0;
        //            //index = 门的index
        //            if (items.getKeys().Contains(index))
        //            {
        //                Debug.Log("开门成功");
        //            }
        //            else
        //            {
        //                Debug.Log("你没有符合条件的钥匙");
        //            }
        //        }
        //#endif
    }

    IEnumerator ChangePosWhileBlack()
    {
        yield return new WaitForSeconds(0.5f);
        transform.position = new Vector3(0f, 10f, -42f);
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
            PhotonView.RPC("ThunderStormEvent", RpcTarget.MasterClient,viewID, position);
        }

        if (collision.collider.tag == "StumblingBlock")
        {
            PhotonView.RPC("showStumblingEffect", RpcTarget.MasterClient);
            int viewID = collision.collider.gameObject.GetComponent<PhotonView>().ViewID;            
            PhotonView.RPC("StumblingBlockEvent", RpcTarget.MasterClient, viewID);
            ChangeHealth(-20f);
        }
    }

    [PunRPC]
    public void ThunderStormEvent(int viewID, Vector3 position)
    {
        PhotonNetwork.Destroy(PhotonView.Find(viewID));
        StartCoroutine(Wait(position));
    }

    [PunRPC]
    public void StumblingBlockEvent(int viewID)
    {
        PhotonNetwork.Destroy(PhotonView.Find(viewID));
    }

    IEnumerator Wait(Vector3 position) //fade function
    {
        Time.timeScale = 1;
        GameObject gameobj;
        gameobj = PhotonNetwork.Instantiate("PlayerCube", position + new Vector3(0, -9, 0), Quaternion.identity, 0);
        //gameobj.transform.position = position + new Vector3(0,-5,0);
        yield return new WaitForSeconds(5);
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
