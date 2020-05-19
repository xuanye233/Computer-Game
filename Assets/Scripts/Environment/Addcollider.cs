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
        buildArray.Add(GameObject.Find("Outside"));
        buildArray.Add(GameObject.Find("Crystal_Caves"));
        buildArray.Add(GameObject.Find("Torture_Room"));
        buildArray.Add(GameObject.Find("Entrance"));
        buildArray.Add(GameObject.Find("Goblin_Cave"));
        buildArray.Add(GameObject.Find("Laboratory"));
        buildArray.Add(GameObject.Find("Cellar"));
        buildArray.Add(GameObject.Find("Furnace"));
        buildArray.Add(GameObject.Find("Barracks"));
        buildArray.Add(GameObject.Find("Long_Hall"));
        buildArray.Add(GameObject.Find("Cells"));
        buildArray.Add(GameObject.Find("Sewer"));
        buildArray.Add(GameObject.Find("Center_Hall"));
        buildArray.Add(GameObject.Find("Ritual"));

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
                //foreach(Transform child in outside.GetComponentsInChildren<Transform>(true))
                //{
                //    outsideArray.Add(child);
                //}

                ////只遍历所有的子物体，没有孙物体  ，遍历不包含本身
                foreach (Transform child in buildArray[i].transform)
                {
                    //outsideArray.Add(child);
                    //Destroy(child.gameObject.GetComponent<BoxCollider>());
                    if (child.gameObject.GetComponent<MeshCollider>() == null)
                    {
                        child.gameObject.AddComponent<MeshCollider>();
                        //Debug.Log("add ok");
                    }
                    //Debug.Log(child.gameObject.name);
                }
            }
        }
        
    }
}
