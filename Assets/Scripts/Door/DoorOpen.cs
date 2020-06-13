using System.Collections;
using System.Collections.Generic;
using UnityEditor.Android;
using UnityEngine.UI;
using UnityEngine;
using Photon.Pun;

public class DoorOpen : MonoBehaviourPunCallbacks
{
    public Text K1;
    public Text K2;
    public Text K3;
    GameObject k1;
    GameObject k2;
    GameObject k3;
    Killfeed killfeed;
    private GameObject curPlayer;
    public string Playername;
    Gem gem;
    ToolSound toolSound;
    private void Start()
    {
        gem = GameObject.Find("Canvas/Gems").GetComponent<Gem>();
        curPlayer = GameObject.Find("Player(Clone)");
        K1 = GameObject.Find("Canvas/Killfeed/K1/Text").GetComponent<Text>();
        K2 = GameObject.Find("Canvas/Killfeed/K2/Text").GetComponent<Text>();
        K3 = GameObject.Find("Canvas/Killfeed/K3/Text").GetComponent<Text>();
        Playername = curPlayer.GetComponent<CharacterStatus>().username;
        toolSound = curPlayer.GetComponent<ToolSound>();
        gem = GameObject.Find("Canvas/Gems").GetComponent<Gem>();
        k1 = GameObject.Find("Canvas/Killfeed/K1");
        k2 = GameObject.Find("Canvas/Killfeed/K2");
        k3 = GameObject.Find("Canvas/Killfeed/K3");
        killfeed = GameObject.Find("Canvas").GetComponent<Killfeed>();
    }
    
    public void doopMove()
    {   
        gameObject.transform.GetChild(0).GetComponent<Animation>().Play("Door_Open");
        gameObject.transform.GetChild(1).GetComponent<Animation>().Play("Door_Open_2");
        showOpenDoor(Playername);
        toolSound.Opensmalldoor(curPlayer.GetComponent<PhotonView>().ViewID);
    }

    public void doorEvent11()
    {
        if(gem.gemD >= 1 && gem.gemB >= 1 && gem.gemA >= 2)
        {
            //宝石充足
            doopMove();
            gem.changeA(-2);
            gem.changeB(-1);
            gem.changeD(-1);
        }
        else if(gem.gemA < 2)
        {
            showGemaInsurfficient(2);
        }
        else if(gem.gemB <= 1)
        {
            showGembInsurfficient(1);
        }
        else if(gem.gemD <= 1)
        {
            showGemdInsurfficient(1);
        }
    }

    public void doorEvent12()
    {
        if (gem.gemD >= 1 && gem.gemB >= 2)
        {
            //宝石充足
            doopMove();
            gem.changeB(-2);
            gem.changeD(-1);
        }
        else if (gem.gemB <= 2)
        {
            showGembInsurfficient(2);
        }
        else if (gem.gemD <= 1)
        {
            showGemdInsurfficient(1);
        }
    }

    public void doorEvent13()
    {
        if (gem.gemD >= 2 && gem.gemB >= 1)
        {
            //宝石充足
            doopMove();
            gem.changeB(-1);
            gem.changeD(-2);
        }
        else if (gem.gemB <= 1)
        {
            showGembInsurfficient(1);
        }
        else if (gem.gemD <= 2)
        {
            showGemdInsurfficient(2);
        }
    }

    public void doorEvent31()
    {
        if (gem.gemA >= 1 && gem.gemB >= 1 && gem.gemC >= 2)
        {
            //宝石充足
            doopMove();
            gem.changeA(-1);
            gem.changeB(-1);
            gem.changeC(-2);
        }
        else if (gem.gemC < 2)
        {
            showGemcInsurfficient(2);
        }
        else if (gem.gemB <= 1)
        {
            showGembInsurfficient(1);
        }
        else if (gem.gemA <= 1)
        {
            showGemaInsurfficient(1);
        }
    }

    public void doorEvent32()
    {
        if (gem.gemC >= 1 && gem.gemB >= 1 && gem.gemA >= 2)
        {
            //宝石充足
            doopMove();
            gem.changeA(-2);
            gem.changeB(-1);
            gem.changeC(-1);
        }
        else if (gem.gemA < 2)
        {
            showGemaInsurfficient(2);
        }
        else if (gem.gemB <= 1)
        {
            showGembInsurfficient(1);
        }
        else if (gem.gemC <= 1)
        {
            showGemcInsurfficient(1);
        }
    }

    public void doorEvent33()
    {
        if (gem.gemD >= 1 && gem.gemB >= 1 && gem.gemC >= 2)
        {
            //宝石充足
            doopMove();
            gem.changeC(-2);
            gem.changeB(-1);
            gem.changeD(-1);
        }
        else if (gem.gemC < 2)
        {
            showGemcInsurfficient(2);
        }
        else if (gem.gemB <= 1)
        {
            showGembInsurfficient(1);
        }
        else if (gem.gemD <= 1)
        {
            showGemdInsurfficient(1);
        }
    }

    public void doorEvent41()
    {
        if (gem.gemC >= 1 && gem.gemA >= 1)
        {
            //宝石充足
            doopMove();
            gem.changeA(-2);
            gem.changeC(-1);
        }
        else if (gem.gemA < 2)
        {
            showGemaInsurfficient(2);
        }
        else if (gem.gemC <= 1)
        {
            showGemcInsurfficient(1);
        }
    }

    public void doorEvent42()
    {
        if (gem.gemC >= 1 && gem.gemB >= 1 && gem.gemA >= 1)
        {
            //宝石充足
            doopMove();
            gem.changeA(-1);
            gem.changeB(-1);
            gem.changeC(-1);
        }
        else if (gem.gemA < 1)
        {
            showGemaInsurfficient(1);
        }
        else if (gem.gemB <= 1)
        {
            showGembInsurfficient(1);
        }
        else if (gem.gemC <= 1)
        {
            showGemcInsurfficient(1);
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
            K1.text = "<i> " + name + " </i> 打开了 <color=#73ccd5ff>一扇门</color> ";
        }
        else if (K2.text == "")
        {
            K2.text = "<i> " + name + " </i> 打开了 <color=#73ccd5ff>一扇门</color> ";
        }
        else if (K3.text == "")
        {
            K3.text = "<i> " + name + " </i> 打开了 <color=#73ccd5ff>一扇门</color> ";
        }
        else
        {
            K1.text = K2.text;
            K2.text = K3.text;
            K3.text = "<i> " + name + " </i> 打开了 <color=#73ccd5ff>一扇门</color> ";
        }
        killfeed.textcount++;
    }

    void showGemaInsurfficient(int num)
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
            K1.text = "<i> 你 </i> 拥有的 <color=#e43b72ff>宝石A</color> 不足" + num.ToString() + "个来打开<color=#73ccd5ff>这扇门</color>";
        }
        else if (K2.text == "")
        {
            K2.text = "<i> 你 </i> 拥有的 <color=#e43b72ff>宝石A</color> 不足" + num.ToString() + "个来打开<color=#73ccd5ff>这扇门</color>";
        }
        else if (K3.text == "")
        {
            K3.text = "<i> 你 </i> 拥有的 <color=#e43b72ff>宝石A</color> 不足" + num.ToString() + "个来打开<color=#73ccd5ff>这扇门</color>";
        }
        else
        {
            K1.text = K2.text;
            K2.text = K3.text;
            K3.text = "<i> 你 </i> 拥有的 <color=#e43b72ff>宝石A</color> 不足" + num.ToString() + "个来打开<color=#73ccd5ff>这扇门</color>";
        }
        killfeed.textcount++;
        toolSound.Opendoorerror();
    }

    void showGembInsurfficient(int num)
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
            K1.text = "<i> 你 </i> 拥有的 <color=#e43b72ff>宝石B</color> 不足" + num.ToString() + "个来打开<color=#73ccd5ff>这扇门</color>";
        }
        else if (K2.text == "")
        {
            K2.text = "<i> 你 </i> 拥有的 <color=#e43b72ff>宝石B</color> 不足" + num.ToString() + "个来打开<color=#73ccd5ff>这扇门</color>";
        }
        else if (K3.text == "")
        {
            K3.text = "<i> 你 </i> 拥有的 <color=#e43b72ff>宝石B</color> 不足" + num.ToString() + "个来打开<color=#73ccd5ff>这扇门</color>";
        }
        else
        {
            K1.text = K2.text;
            K2.text = K3.text;
            K3.text = "<i> 你 </i> 拥有的 <color=#e43b72ff>宝石B</color> 不足" + num.ToString() + "个来打开<color=#73ccd5ff>这扇门</color>";
        }
        killfeed.textcount++;
        toolSound.Opendoorerror();
    }

    void showGemcInsurfficient(int num)
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
            K1.text = "<i> 你 </i> 拥有的 <color=#e43b72ff>宝石C</color> 不足" + num.ToString() + "个来打开<color=#73ccd5ff>这扇门</color>";
        }
        else if (K2.text == "")
        {
            K2.text = "<i> 你 </i> 拥有的 <color=#e43b72ff>宝石C</color> 不足" + num.ToString() + "个来打开<color=#73ccd5ff>这扇门</color>";
        }
        else if (K3.text == "")
        {
            K3.text = "<i> 你 </i> 拥有的 <color=#e43b72ff>宝石C</color> 不足" + num.ToString() + "个来打开<color=#73ccd5ff>这扇门</color>";
        }
        else
        {
            K1.text = K2.text;
            K2.text = K3.text;
            K3.text = "<i> 你 </i> 拥有的 <color=#e43b72ff>宝石C</color> 不足" + num.ToString() + "个来打开<color=#73ccd5ff>这扇门</color>";
        }
        killfeed.textcount++;
        toolSound.Opendoorerror();
    }

    void showGemdInsurfficient(int num)
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
            K1.text = "<i> 你 </i> 拥有的 <color=#e43b72ff>宝石D</color> 不足" + num.ToString() + "个来打开<color=#73ccd5ff>这扇门</color>";
        }
        else if (K2.text == "")
        {
            K2.text = "<i> 你 </i> 拥有的 <color=#e43b72ff>宝石D</color> 不足" + num.ToString() + "个来打开<color=#73ccd5ff>这扇门</color>";
        }
        else if (K3.text == "")
        {
            K3.text = "<i> 你 </i> 拥有的 <color=#e43b72ff>宝石D</color> 不足" + num.ToString() + "个来打开<color=#73ccd5ff>这扇门</color>";
        }
        else
        {
            K1.text = K2.text;
            K2.text = K3.text;
            K3.text = "<i> 你 </i> 拥有的 <color=#e43b72ff>宝石D</color> 不足" + num.ToString() + "个来打开<color=#73ccd5ff>这扇门</color>";
        }
        killfeed.textcount++;
        toolSound.Opendoorerror();
    }
}
