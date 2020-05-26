using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


namespace Com.MyCompany.MyGame
{
    public class LauncherTest : MonoBehaviourPunCallbacks
    {
        public GameObject foodPrefab;
        #region Private Serializable Fields
        [SerializeField]
        private byte maxPlayersPerRoom = 4;
        bool isConnecting;
        public string roomName;

        #endregion


        #region Private Fields


        /// <summary>
        /// This client's version number. Users are separated from each other by gameVersion (which allows you to make breaking changes).
        /// </summary>
        string gameVersion = "1";


        #endregion


        #region MonoBehaviour CallBacks


        /// <summary>
        /// MonoBehaviour method called on GameObject by Unity during early initialization phase.
        /// </summary>
        void Awake()
        {
            // #Critical
            // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
            PhotonNetwork.AutomaticallySyncScene = true;
            isConnecting = false;
            roomName = "None";
        }


        /// <summary>
        /// MonoBehaviour method called on GameObject by Unity during initialization phase.
        /// </summary>
        void Start()
        {
            //Connect();
        }


        #endregion


        #region Public Methods
        public AudioSource sound2;
        public AudioClip click;

        /// <summary>
        /// Start the connection process.
        /// - If already connected, we attempt joining a random room
        /// - if not yet connected, Connect this application instance to Photon Cloud Network
        /// </summary>
        public void Connect()
        {
            isConnecting = PhotonNetwork.ConnectUsingSettings();
            // we check if we are connected or not, we join if we are , else we initiate the connection to the server.
            if (PhotonNetwork.IsConnected)
            {
                Debug.Log("PhotonNetwork.IsConnected");
                // #Critical we need at this point to attempt joining a Random Room. If it fails, we'll get notified in OnJoinRandomFailed() and we'll create one.
                PhotonNetwork.JoinRandomRoom();
                //Debug.Log("room name is " + PhotonNetwork.CurrentRoom.Name);
            }
            else
            {
                Debug.Log("!PhotonNetwork.IsConnected");
                // #Critical, we must first and foremost connect to Photon Online Server.
                PhotonNetwork.ConnectUsingSettings();
                PhotonNetwork.GameVersion = gameVersion;
            }
        }

        public void newSound()
        {
            sound2 = gameObject.GetComponent<AudioSource>();
            click = Resources.Load<AudioClip>("music/click_2");
            sound2.clip = click;
            sound2.Play();
        }

        public void connectSound()
        {
            sound2 = gameObject.GetComponent<AudioSource>();
            click = Resources.Load<AudioClip>("music/click");
            sound2.clip = click;
            sound2.Play();
        }

        public void teachSound()
        {
            sound2 = gameObject.GetComponent<AudioSource>();
            click = Resources.Load<AudioClip>("music/click");
            sound2.clip = click;
            sound2.Play();
        }

        public void guideSound()
        {
            sound2 = gameObject.GetComponent<AudioSource>();
            click = Resources.Load<AudioClip>("music/click");
            sound2.clip = click;
            sound2.Play();
        }

        public void settingSound()
        {
            sound2 = gameObject.GetComponent<AudioSource>();
            click = Resources.Load<AudioClip>("music/click");
            sound2.clip = click;
            sound2.Play();
        }

        public void quitSound()
        {
            sound2 = gameObject.GetComponent<AudioSource>();
            click = Resources.Load<AudioClip>("music/click");
            sound2.clip = click;
            sound2.Play();
        }
        #endregion

        #region MonoBehaviourPunCallbacks Callbacks


        public override void OnConnectedToMaster()
        {
            Debug.Log("OnConnectedToMaster");
            if (isConnecting)
            {
                // #Critical: The first we try to do is to join a potential existing room. If there is, good, else, we'll be called back with OnJoinRandomFailed()
                if (roomName == "None")
                {
                    PhotonNetwork.JoinRandomRoom();
                    isConnecting = false;
                }
                else
                {
                    //PhotonNetwork.JoinOrCreateRoom(roomName, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
                    PhotonNetwork.JoinRoom(roomName);
                    isConnecting = false;
                }
            }

            Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");
        }


        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

            // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
            PhotonNetwork.CreateRoom(roomName, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            base.OnJoinRoomFailed(returnCode, message);
            PhotonNetwork.CreateRoom(roomName, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
        }

        public override void OnJoinedRoom()
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
            {
                //Debug.Log("We load the 'Room for 1' ");

                Debug.Log("room name is " + PhotonNetwork.CurrentRoom.Name);
                // #Critical
                // Load the Room Level.
                PhotonNetwork.LoadLevel(2);
                //PhotonNetwork.Instantiate(this.foodPrefab.name, new Vector3(1f, 20f, -40f), Quaternion.identity, 0);
            }
            Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
        }

        public void enterEdu()
        {
            PhotonNetwork.LoadLevel(1);
        }

        #endregion


    }
}
