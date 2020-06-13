using System.Collections;
using System.Collections.Generic;
using UnityEditor.Android;
using UnityEngine.UI;
using UnityEngine;
using Photon.Pun;

public class FinalDoorOpen : MonoBehaviourPunCallbacks
{
    CharacterItems characterItems;
    public Text K1;
    public Text K2;
    public Text K3;
    GameObject k1;
    GameObject k2;
    GameObject k3;
    Killfeed killfeed;
    private GameObject curPlayer;
    public string Playername;   
    ToolSound toolSound;

    private void Start()
    {
        curPlayer = GameObject.Find("Player(Clone)");
        characterItems = curPlayer.GetComponent<CharacterItems>();
        K1 = GameObject.Find("Canvas/Killfeed/K1/Text").GetComponent<Text>();
        K2 = GameObject.Find("Canvas/Killfeed/K2/Text").GetComponent<Text>();
        K3 = GameObject.Find("Canvas/Killfeed/K3/Text").GetComponent<Text>();
        Playername = curPlayer.GetComponent<CharacterStatus>().username;
        toolSound = curPlayer.GetComponent<ToolSound>();
        k1 = GameObject.Find("Canvas/Killfeed/K1");
        k2 = GameObject.Find("Canvas/Killfeed/K2");
        k3 = GameObject.Find("Canvas/Killfeed/K3");
        killfeed = GameObject.Find("Canvas").GetComponent<Killfeed>();
    }

    public void doopMove()
    {
        gameObject.transform.GetChild(0).GetComponent<Animation>().Play("Final_Door_1");
        gameObject.transform.GetChild(1).GetComponent<Animation>().Play("Final_Door_2");
        showOpenDoor(Playername);
        toolSound.Opensmalldoor(curPlayer.GetComponent<PhotonView>().ViewID);
    }

    public void doorEvent()
    {
        Debug.Log("Moonstone num:" + characterItems.getMoonStone());
        if (characterItems.getMoonStone() == 0)
        {
            showMoonStoneInsufficient(1);   //缺少一个月光石
            return;
        }
        else if (characterItems.getMoonStone() > 0)
        {   //月光石充足
            characterItems.changeMoonStone(-1);  //消耗一个月光石            
            doopMove(); //开门
        }
    }
    
    void showOpenDoor(string name)
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
            K1.text = "<i> " + name + " </i> 打开了 <color=#73ccd5ff>终点之门</color> ";
        }
        else if (K2.text == "")
        {
            K2.text = "<i> " + name + " </i> 打开了 <color=#73ccd5ff>终点之门</color> ";
        }
        else if (K3.text == "")
        {
            K3.text = "<i> " + name + " </i> 打开了 <color=#73ccd5ff>终点之门</color> ";
        }
        else
        {
            K1.text = K2.text;
            K2.text = K3.text;
            K3.text = "<i> " + name + " </i> 打开了 <color=#73ccd5ff>终点之门</color> ";
        }
        killfeed.textcount++;
    }

    void showMoonStoneInsufficient(int num)
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
            K1.text = "<i> 你 </i> 拥有的 <color=#e43b72ff>月亮石</color> 不足" + num.ToString() + "个来打开<color=#73ccd5ff>终点之门</color>";
        }
        else if (K2.text == "")
        {
            K2.text = "<i> 你 </i> 拥有的 <color=#e43b72ff>月亮石</color> 不足" + num.ToString() + "个来打开<color=#73ccd5ff>终点之门</color>";
        }
        else if (K3.text == "")
        {
            K3.text = "<i> 你 </i> 拥有的 <color=#e43b72ff>月亮石</color> 不足" + num.ToString() + "个来打开<color=#73ccd5ff>终点之门</color>";
        }
        else
        {
            K1.text = K2.text;
            K2.text = K3.text;
            K3.text = "<i> 你 </i> 拥有的 <color=#e43b72ff>月光石</color> 不足" + num.ToString() + "个来打开<color=#73ccd5ff>终点之门</color>";
        }
        killfeed.textcount++;
        toolSound.Opendoorerror();
    }
    
}
