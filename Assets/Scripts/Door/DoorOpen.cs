using System.Collections;
using System.Collections.Generic;
using UnityEditor.Android;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    Gem gem;
    private void Start()
    {
        gem = GameObject.Find("Canvas/Gems").GetComponent<Gem>();
    }
    
    public void doopMove()
    {
        gameObject.transform.GetChild(0).GetComponent<Animation>().Play("Door_Open");
        gameObject.transform.GetChild(1).GetComponent<Animation>().Play("Door_Open_2");
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
            
        }
        else if(gem.gemB <= 1)
        {

        }
        else if(gem.gemD <= 1)
        {

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

        }
        else if (gem.gemD <= 1)
        {

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

        }
        else if (gem.gemD <= 2)
        {

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

        }
        else if (gem.gemB <= 1)
        {

        }
        else if (gem.gemA <= 1)
        {

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

        }
        else if (gem.gemB <= 1)
        {

        }
        else if (gem.gemC <= 1)
        {

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

        }
        else if (gem.gemB <= 1)
        {

        }
        else if (gem.gemD <= 1)
        {

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

        }
        else if (gem.gemC <= 1)
        {

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

        }
        else if (gem.gemB <= 1)
        {

        }
        else if (gem.gemC <= 1)
        {

        }
    }
}
