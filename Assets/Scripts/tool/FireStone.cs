using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStone: MonoBehaviour
{
    public int ID = 3;
    void onTouched()
    {
        GameObject.Find("GameObject").SendMessage("increaseFirestone", ID);
        this.gameObject.SetActive(false);
    }
}
