using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Addcollider : MonoBehaviour
{
    private GameObject outside;                 //需要遍历子物体的母体
    public List<Transform> outsideArray;       //遍历的结果数组
                                           // Use this for initialization
    void Start()
    {
        outside = GameObject.Find("Outside");   //查找物体
        if (outside != null)
        {
            //Debug.Log(outside.name);

            //遍历所有的子物体以及孙物体，并且遍历包含本身
            //for (int i = 0; i < outside.GetComponentsInChildren<Transform>(true).Length; i++)
            //{
            //    outsideArray.Add(outside.GetComponentsInChildren<Transform>()[i]);
            //}

            //作用同上
            //foreach(Transform child in outside.GetComponentsInChildren<Transform>(true))
            //{
            //    outsideArray.Add(child);
            //}

            ////只遍历所有的子物体，没有孙物体  ，遍历不包含本身
            foreach (Transform child in outside.transform)
            {
                outsideArray.Add(child);
                Destroy(child.gameObject.GetComponent<BoxCollider>());
                if(child.gameObject.GetComponent<MeshCollider>() == null)
                {
                    child.gameObject.AddComponent<MeshCollider>();
                }
                //Debug.Log(child.gameObject.name);
            }
        }
    }
}
