using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
public class ThunderstormStone : MonoBehaviourPunCallbacks
{
    CharacterItems characterItems;
    public bool isThunderstormStoneClick;
    [SerializeField]
    GameObject bagButton;
    [SerializeField]
    GameObject bagPanel;
    GameObject curPlayer;
    ToolSound toolSound;
    public Text K1;
    public Text K2;
    public Text K3;
    string Playername;
    GameObject k1;
    GameObject k2;
    GameObject k3;
    Killfeed killfeed;
    GameObject achieve;
    [SerializeField]
    ToolMenuControl toolMenuControl;
    //public Text SliderText;
    private void Start()
    {
        curPlayer = GameObject.Find("Player(Clone)");
        toolSound = curPlayer.GetComponent<ToolSound>();
        characterItems = GameObject.Find("Player(Clone)").GetComponent<CharacterItems>();
        isThunderstormStoneClick = false;
        Debug.Log(" isThunderstormStoneClick = false;");
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

    void Update()
    {
        //Debug.Log(isThunderstormStoneClick && Input.GetMouseButtonDown(0));
        //noTrapText.gameObject.SetActive(false);
        if (isThunderstormStoneClick && Input.GetMouseButtonDown(0) && characterItems.getThunderstormStone() > 0)
        {
            Debug.Log("3");
            ThunderstormStoneClickEvent();
        }
    }

    public void onClicked()
    {
        //Debug.Log("1");
        if (characterItems.getThunderstormStone() == 0)
        {
            //showNoTrap();
            return;
        }
        else
        {
            //Debug.Log("2");
            isThunderstormStoneClick = true;
            //trapTransform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }
    }

    public void ThunderstormStoneClickEvent()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 10.0f))
        {
            //Debug.Log("4");
            //GameObject newTrap = (GameObject)GameObject.Instantiate(Resources.Load("SM_Prop_Bricks_04"));
            //create the object in the scene
            //newTrap.transform.position = hit.point;
            PhotonView.RPC("showThunderTips", RpcTarget.All, Playername);
            PhotonView.RPC("createThunderstorm", RpcTarget.MasterClient, hit.point);
            curPlayer.GetComponent<ToolSound>().Set(curPlayer.GetComponent<PhotonView>().ViewID);
            achieve.GetComponent<SimpleAchievements.Main.AchievementsControl>().AddProgressAchievementByID(1, 1);
            isThunderstormStoneClick = false;
            //reset the flag
            //Debug.Log(hit.point);
            //Debug.DrawRay(hit.point, hit.normal, Color.green);

            //update the num of the traps
            //trapTransform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            characterItems.changeThunderstormStone(-1);
            toolMenuControl.transparent();
        }
    }



    [PunRPC]
    public void createThunderstorm(Vector3 position)
    {
        PhotonNetwork.Instantiate("Thunderstorm2", position, Quaternion.identity, 0);
    }

    [PunRPC]
    public void showThunderTips(string name)
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
            K1.text = "<i>" + name + "</i> 放置了 <color=#73ccd5ff>雷暴石</color> ";
        }
        else if (K2.text == "")
        {
            K2.text = "<i>" + name + "</i> 放置了 <color=#73ccd5ff>雷暴石</color> ";
        }
        else if (K3.text == "")
        {
            K3.text = "<i>" + name + "</i> 放置了 <color=#73ccd5ff>雷暴石</color> ";
        }
        else
        {
            K1.text = K2.text;
            K2.text = K3.text;
            K3.text = "<i>" + name + "</i> 放置了 <color=#73ccd5ff>雷暴石</color> ";
        }
        killfeed.textcount++;
    }
    //void exposure()
    //{
    //    PhotonNetwork.Instantiate("PlayerCube", GameObject.Find("MapCamera/PlayerCube").transform.position, Quaternion.identity, 0);

    //}


}
