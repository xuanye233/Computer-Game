using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gem : MonoBehaviour
{
    int gemA;
    int gemB;
    int gemC;
    int gemD;
    [SerializeField]
    Text gemAtext;
    [SerializeField]
    Text gemBtext;
    [SerializeField]
    Text gemCtext;
    [SerializeField]
    Text gemDtext;


    private void Start()
    {
        gemA = 0;
        gemB = 0;
        gemC = 0;
        gemD = 0;
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
