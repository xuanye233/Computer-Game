using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelThief : MonoBehaviour
{
    [SerializeField] GameObject rival;//对手

    private int jewelNum = 3;//假设一共有三种宝石

    public void useJewelThief()
    {
        rival = GameObject.Find("Player");//人物脚本应该还要改，加一个jewel的数组？

        int index = Random.Range(0, jewelNum);//随机指定偷取某种颜色的宝石

        int p1 = Random.Range(0, 100);
        int p2 = Random.Range(0, 100);

        float distance = Vector3.Distance(rival.transform.position, transform.position);
        if (distance > 5.0)//这个距离的阈值可以重新设定
        {
            //if (rival.jewel[index] > 0)//可以被偷
            //{
            //    if (p2 <= p1)//偷成功的概率设置为大于一半
            //    {
            //        rival.jewel[index]--;
            //        jewel[index]++;
            //    }
            //}
        }
    }
}
