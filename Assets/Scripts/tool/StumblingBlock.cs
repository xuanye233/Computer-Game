using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//绊脚石：降低敌人生命值

public class StumblingBlock : MonoBehaviour
{
    [SerializeField] private float minDis = 3.0f; //在这个距离内才能影响到敌人
    [SerializeField] private float deVal = 20.0f; //减少的生命值
    private GameObject[] players;

    public void onClicked()
    {
        //现在的设定是只要是一定范围内的敌人都会被影响
        players = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < players.Length; i++)
        {
            float dis = Vector3.Distance(players[i].transform.position, transform.position);

            if (dis < minDis && dis > 0.01f)
            {
                players[i].GetComponent<CharacterStatus>().ChangeHealth(-deVal);
            }
        }
    }
}
