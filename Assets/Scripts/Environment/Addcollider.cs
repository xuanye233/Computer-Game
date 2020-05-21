using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Addcollider : MonoBehaviour
{
    private GameObject outside;                 //需要遍历子物体的母体
    public List<GameObject> buildArray;       //遍历的结果数组
                                          
    void Awake()
    {
        buildArray.Add(GameObject.Find("Map_other_part"));
        buildArray.Add(GameObject.Find("Map_route_1"));
        buildArray.Add(GameObject.Find("Map_route_2"));
        buildArray.Add(GameObject.Find("Map_route_3"));
        buildArray.Add(GameObject.Find("Map_route_4"));

        for (int i = 0;i < buildArray.Count; i++)
        {
            if (buildArray[i] != null)
            {
                //Debug.Log(outside.name);

                //遍历所有的子物体以及孙物体，并且遍历包含本身
                //for (int i = 0; i < outside.GetComponentsInChildren<Transform>(true).Length; i++)
                //{
                //    outsideArray.Add(outside.GetComponentsInChildren<Transform>()[i]);
                //}

                //作用同上
                foreach (Transform child in buildArray[i].transform.GetComponentsInChildren<Transform>(true))
                {
                    if (child.gameObject.GetComponent<MeshCollider>() == null)
                    {
                        child.gameObject.AddComponent<MeshCollider>();
                        //Debug.Log("add ok");
                        child.gameObject.GetComponent<MeshCollider>().convex = true;
                    }
                }

                ////只遍历所有的子物体，没有孙物体  ，遍历不包含本身
                //foreach (Transform child in buildArray[i].transform)
                //{
                //    //outsideArray.Add(child);
                //    //Destroy(child.gameObject.GetComponent<BoxCollider>());
                //    if (child.gameObject.GetComponent<MeshCollider>() == null)
                //    {
                //        child.gameObject.AddComponent<MeshCollider>();
                //        //Debug.Log("add ok");
                //    }
                //    //Debug.Log(child.gameObject.name);
                //}
            }
        }
        
    }
}
