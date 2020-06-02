using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


using Photon.Pun;
using Photon.Realtime;


namespace Com.MyCompany.MyGame
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        #region Public Fields
        public static GameManager Instance;
        [Tooltip("The prefab to use for representing the player")]
        public GameObject playerPrefab;
        public GameObject foodPrefab;
        public List<Transform> outsideArray;
        public GameObject blindPrefab;
        public GameObject birthStonePrefab;
        public GameObject stumblingPrefab;
        public GameObject thunderstormPrefab;
        public GameObject stillPrefab;
        public GameObject teleportationPrefab;
        public GameObject jewelThiefPrefab;
        public GameObject herbsPrefab;
        public GameObject moonstonePrefab;
        //public GameObject mapPrefab;
        public GameObject gemA;
        public GameObject gemB;
        public GameObject gemC;
        public GameObject gemD;

        public GameObject[] foodPos;
        public GameObject[] blindPos;

        [SerializeField]
        public RawImage blackScreen;

        #endregion

        #region Photon Callbacks

        /// <summary>
        /// Called when the local player left the room. We need to load the launcher scene.
        /// </summary>
        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
        }


        #endregion

        #region MonoBehaviour Callbacks
        public void Awake()
        {
            Instance = GetComponent<GameManager>();

            if (playerPrefab == null)
            {
                Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this);
            }
            else
            {
                if(PhotonNetwork.IsMasterClient)
                {
                    //PhotonNetwork.Instantiate("food", new Vector3(1f, 6f, -40f), Quaternion.identity, 0);
                    for (int i = 0; i < foodPos.Length; i++)
                    {
                        PhotonNetwork.Instantiate(this.foodPrefab.name, foodPos[i].transform.position+ new Vector3(UnityEngine.Random.Range(-5f, 5f), 0, UnityEngine.Random.Range(-5f, 5f)), Quaternion.identity, 0);
                    }
                    for (int i = 0; i < blindPos.Length; i++)
                    {
                        PhotonNetwork.Instantiate(this.blindPrefab.name, foodPos[i].transform.position + new Vector3(UnityEngine.Random.Range(-5f, 5f), 0, UnityEngine.Random.Range(-5f, 5f)), Quaternion.identity, 0);
                    }
                    //PhotonNetwork.Instantiate(this.foodPrefab.name, new Vector3(1f, 6f, -52f), Quaternion.identity, 0);
                    //PhotonNetwork.Instantiate(this.foodPrefab.name, new Vector3(1f, 8f, -52f), Quaternion.identity, 0);
                    //PhotonNetwork.Instantiate(this.blindPrefab.name, new Vector3(1f, 8f, -48f), Quaternion.identity, 0);
                    PhotonNetwork.Instantiate(this.thunderstormPrefab.name, new Vector3(1f, 4f, -48f), Quaternion.identity, 0);
                    //PhotonNetwork.Instantiate(this.teleportationPrefab.name, new Vector3(1f, 4f, -48f), Quaternion.identity, 0);
                    //PhotonNetwork.Instantiate(this.jewelThiefPrefab.name, new Vector3(1f, 4f, -48f), Quaternion.identity, 0);
                    //Debug.Log("ahahahaha");
                }
                if (CharacterStatus.LocalPlayerInstance == null)
                {
                    Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);
                    // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
                    int characterNum = GlobalData.characterIndex;
                    PhotonNetwork.Instantiate("Player" + characterNum + "/" + this.playerPrefab.name, new Vector3(0f, 5f, -52f), Quaternion.identity, 0);
                    //PhotonNetwork.Instantiate(this.foodPrefab.name, new Vector3(1f, 20f, -40f), Quaternion.identity, 0);
                    //PhotonNetwork.Instantiate(this.mapPrefab.name, new Vector3(0f, 10f, -45f), Quaternion.identity, 0);
                    Debug.Log("chuangjian");
                    //addCollider();
                }
                else
                {
                    Debug.LogFormat("Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName);
                }
            }
        }

        public void Start()
        {
            //blackScreen.CrossFadeAlpha(0, 1f, false);
            //blackScreen.gameObject.SetActive(false);
        }
        #endregion

        #region Public Methods


        public void LeaveRoom()
        {
            Debug.Log("test LeaveRoom");
            PhotonNetwork.LeaveRoom();
        }


        #endregion

        #region Private Methods


        void LoadArena()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
            }
            Debug.LogFormat("PhotonNetwork : Loading Level : {0}", PhotonNetwork.CurrentRoom.PlayerCount);
            //PhotonNetwork.LoadLevel("Room for " + PhotonNetwork.CurrentRoom.PlayerCount);//把这句删掉，有玩家退出不用重载场景
        }


        #endregion

        #region Photon Callbacks


        public override void OnPlayerEnteredRoom(Player other)
        {
            Debug.LogFormat("OnPlayerEnteredRoom() {0}", other.NickName); // not seen if you're the player connecting


            //if (PhotonNetwork.IsMasterClient)
            //{
            //    Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom


            //    LoadArena();
            //}
            //LoadArena();
        }


        public override void OnPlayerLeftRoom(Player other)
        {
            Debug.LogFormat("OnPlayerLeftRoom() {0}", other.NickName); // seen when other disconnects


            if (PhotonNetwork.IsMasterClient)
            {
                Debug.LogFormat("OnPlayerLeftRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom


                LoadArena();
            }
            //LoadArena();
            //改动：本来上面那段if是被注释掉的，保留下面的LoadArena()
        }


        #endregion
    }
}