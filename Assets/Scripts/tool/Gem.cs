using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gem : MonoBehaviour
{
    public int gemA;
    public int gemB;
    public int gemC;
    public int gemD;
    [SerializeField]
    Text gemAtext;
    [SerializeField]
    Text gemBtext;
    [SerializeField]
    Text gemCtext;
    [SerializeField]
    Text gemDtext;
    GameObject curPlayer;
    public Text K1;
    public Text K2;
    public Text K3;
    string Playername;

    private void Start()
    {
        curPlayer = GameObject.Find("Player(Clone)");
        gemA = 0;
        gemB = 0;
        gemC = 0;
        gemD = 0;
        K1 = GameObject.Find("Canvas/Killfeed/K1/Text").GetComponent<Text>();
        K2 = GameObject.Find("Canvas/Killfeed/K2/Text").GetComponent<Text>();
        K3 = GameObject.Find("Canvas/Killfeed/K3/Text").GetComponent<Text>();
        gemAtext = GameObject.Find("Canvas/Gems/blockGemA/Gem_A_amount").GetComponent<Text>();
        gemBtext = GameObject.Find("Canvas/Gems/blockGemB/Gem_B_amount").GetComponent<Text>();
        gemCtext = GameObject.Find("Canvas/Gems/blockGemC/Gem_C_amount").GetComponent<Text>();
        gemDtext = GameObject.Find("Canvas/Gems/blockGemD/Gem_D_amount").GetComponent<Text>();
        Playername = curPlayer.GetComponent<CharacterStatus>().username;
        
    }

    private void Update()
    {
        Debug.Log("hahaha");
        Debug.Log(gameObject.name);
    }

    public void changeA(int num)
    {
        gemA += num;
        gemAtext.text = gemA.ToString();
    }

    public void changeB(int num)
    {
        gemB += num;
        gemBtext.text = gemB.ToString();
    }

    public void changeC(int num)
    {
        gemC += num;
        gemCtext.text = gemC.ToString();
    }

    public void changeD(int num)
    {
        gemD += num;
        gemDtext.text = gemD.ToString();
    }

    public bool useA()
    {
        if(gemA < 1)
        {
            //宝石不足
            return false;
        }
        else
        {
            changeA(-1);
            //比如开门之类的函数
            return true;
        }
    }

    public bool useB()
    {
        if (gemB < 1)
        {
            //宝石不足
            return false;
        }
        else
        {
            changeB(-1);
            //比如开门之类的函数
            return true;
        }
    }

    public bool useC()
    {
        if (gemC < 1)
        {
            //宝石不足
            return false;
        }
        else
        {
            changeC(-1);
            //比如开门之类的函数
            return true;
        }
    }

    public bool useD()
    {
        if (gemD < 1)
        {
            //宝石不足
            return false;
        }
        else
        {
            changeD(-1);
            //比如开门之类的函数
            return true;
        }
    }
}
