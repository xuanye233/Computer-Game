using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

//定位药水：静止不动

public class FixPotion : MonoBehaviourPunCallbacks
{
    [SerializeField] private float minDis = 3.0f; //在这个距离内才能影响到敌人
    [SerializeField] private float fixTime = 5.0f; //静止的时间
    private GameObject[] players;
    ThirdPersonUserControl thirdPersonUserControl;
    CharacterItems characterItems;
    GameObject curPlayer;
    ToolSound toolSound;
    public Text K1;
    public Text K2;
    public Text K3;
    string Playername;
    GameObject k1;
    GameObject k2;
    GameObject k3;
    GameObject achieve;
    Killfeed killfeed;
    [SerializeField]
    ToolMenuControl toolMenuControl;
    //public Text SliderText;
    public void Start()
    {
        curPlayer = GameObject.Find("Player(Clone)");
        toolSound = curPlayer.GetComponent<ToolSound>();
        thirdPersonUserControl = curPlayer.GetComponent<ThirdPersonUserControl>();
        characterItems = curPlayer.GetComponent<CharacterItems>();
        K1 = GameObject.Find("Canvas/Killfeed/K1/Text").GetComponent<Text>();
        K2 = GameObject.Find("Canvas/Killfeed/K2/Text").GetComponent<Text>();
        K3 = GameObject.Find("Canvas/Killfeed/K3/Text").GetComponent<Text>();
        Playername = curPlayer.GetComponent<CharacterStatus>().username;
        k1 = GameObject.Find("Canvas/Killfeed/K1");
        k2 = GameObject.Find("Canvas/Killfeed/K2");
        k3 = GameObject.Find("Canvas/Killfeed/K3");
        achieve = GameObject.Find("AchievementManager");
        killfeed = GameObject.Find("Canvas").GetComponent<Killfeed>();
        //SliderText = GameObject.Find("Canvas/slider/SliderImage/SliderText").GetComponent<Text>();
    }
    public void onClicked()
    {
        Debug.Log("click");
        //现在的设定是只要是一定范围内的敌人都会被影响
        //
        Debug.Log("click2");
        toolSound.NotMove();
        toolSound.LetNotMove(curPlayer.GetComponent<PhotonView>().ViewID);
        PhotonView.RPC("showFixEffect", RpcTarget.MasterClient, curPlayer.transform.position, curPlayer.GetComponent<CapsuleCollider>().center, curPlayer.transform.localScale.y);
        PhotonView.RPC("showFixTips", RpcTarget.All, Playername);
        achieve.GetComponent<SimpleAchievements.Main.AchievementsControl>().AddProgressAchievementByID(2, 1);
        players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 1; i < players.Length; i++)
        {
            //float dis = Vector3.Distance(players[i].transform.position, transform.position);

            //if (dis < minDis && dis > 0.01f)
            //{
            //    players[i].GetComponent<ThirdPersonUserControl>().ForbidMove(fixTime);
            //}
            //PhotonView.RPC("ForbidMove", RpcTarget.All, players[i].GetComponent<PhotonView>().ViewID, 5.0f);
            PhotonView.RPC("ForbidMove", RpcTarget.All, players[i].GetComponent<PhotonView>().ViewID);
            //执行函数  执行服务器  函数的参数
        }
        characterItems.changeFixPotion(-1);
        toolMenuControl.transparent();
    }

    [PunRPC]
    public void ForbidMove(int ViewID)
    {
        float fixTime;
        float testID = PhotonView.Find(ViewID).GetComponent<CharacterItems>().getID();
        if (testID == 1)
        {
            fixTime = 2.5f;
        }
        else
        {
            fixTime = 5.0f;
        }
        PhotonView.Find(ViewID).GetComponent<ThirdPersonUserControl>().canMove = false;
        //Invoke("RecoverMove", fixTime);
        StartCoroutine(Wait(fixTime, ViewID));
    }

    IEnumerator Wait(float waitTime, int ViewID)
    {
        yield return new WaitForSeconds(waitTime);
        PhotonView.Find(ViewID).GetComponent<ThirdPersonUserControl>().canMove = true;
        //等待之后执行的动作
    }

    [PunRPC]
    public void showFixEffect(Vector3 position, Vector3 center, float scale)
    {
        Vector3 centerPos = position + center * scale * 1.5f;
        PhotonNetwork.Instantiate("Effects/FixEffect", centerPos, Quaternion.identity, 0);
    }

    [PunRPC]
    public void showFixTips(string name)
    {
        if (killfeed.textcount == 0)
        {
            k1.SetActive(true);
        }
        else if (killfeed.textcount == 1)
        {
            k2.SetActive(true);
        }
        else if (killfeed.textcount == 2)
        {
            k3.SetActive(true);
        }
        if (K1.text == "")
        {
            K1.text = "<i>" + name + "</i> 使用了 <color=#73ccd5ff>定位药水</color> ";
        }
        else if (K2.text == "")
        {
            K2.text = "<i>" + name + "</i> 使用了 <color=#73ccd5ff>定位药水</color> ";
        }
        else if (K3.text == "")
        {
            K3.text = "<i>" + name + "</i> 使用了 <color=#73ccd5ff>定位药水</color> ";
        }
        else
        {
            K1.text = K2.text;
            K2.text = K3.text;
            K3.text = "<i>" + name + "</i> 使用了 <color=#73ccd5ff>定位药水</color> ";
        }
        killfeed.textcount++;
    }
}
