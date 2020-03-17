using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int ID = 1;
    void onTouched()
    {
        //没有相应接口，先暂时这样写
        GameObject.Find("GameObject").SendMessage("get",ID);
        this.gameObject.SetActive(false);
    }
    

}

