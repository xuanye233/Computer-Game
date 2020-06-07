using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public int ID = 4;
    public int index;
     void Start()
    {
        index = Random.Range(0, 3);
    }
    void onTouched()
    {
        GameObject.Find("GameObject").SendMessage("addKey", index);
        this.gameObject.SetActive(false);
    }
}
