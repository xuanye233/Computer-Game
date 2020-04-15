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
        //public GameObject mapPrefab;
        [SerializeField]
        RawImage blackScreen;

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
                    PhotonNetwork.Instantiate(this.foodPrefab.name, new Vector3(1f, 6f, -40f), Quaternion.identity, 0);
                    PhotonNetwork.Instantiate(this.foodPrefab.name, new Vector3(1f, 8f, -40f), Quaternion.identity, 0);
                    Debug.Log("ahahahaha");
                }
                if (CharacterStatus.LocalPlayerInstance == null)
                {
                    Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);
                    // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
                    PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f, 10f, -42f), Quaternion.identity, 0);
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
            //PhotonNetwork.LoadLevel("Room for " + PhotonNetwork.CurrentRoom.PlayerCount);
            PhotonNetwork.LoadLevel(1);
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


            //if (PhotonNetwork.IsMasterClient)
            //{
            //    Debug.LogFormat("OnPlayerLeftRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom


            //    LoadArena();
            //}
            LoadArena();
        }


        #endregion
    }
}