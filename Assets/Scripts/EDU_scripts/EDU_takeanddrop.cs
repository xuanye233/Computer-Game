﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EDU_takeanddrop : MonoBehaviour
{
    [SerializeField]
    EDU_process eDU_Process;
    public GameObject preFabCube;
    private GameObject newCube;
    public Camera cam;
    public int equipNum = 0;
    private float timeHit = 0f;         //用于点击的时间间隔,每次点击时间间隔应大于0.2秒 

    CharacterItems characterItems;
    ToolInteraction toolInteraction;

    EDU_toolSound toolSound;
    private GameObject curPlayer;



    void Start()
    {
        //do
        //{
        //    StartCoroutine(Wait(5.0f));
        //} while (!GameObject.Find("Player(Clone)"));
        GameObject gameObject = GameObject.Find("Camera");
        //cam = gameObject.GetComponent<Camera>();
        characterItems = GameObject.Find("Player(Clone)").GetComponent<CharacterItems>();
        //toolInteraction = GameObject.Find("Canvas/BagPanel/ToolList").GetComponent<ToolInteraction>();
        curPlayer = GameObject.Find("Player(Clone)");
        toolSound = curPlayer.GetComponent<EDU_toolSound>();
    }
    void Update()
    {
        PickUpTool();
        //this.gameObject.GetComponent<PhotonView>().RPC();
    }

    //[PunRPC]
    public void PickUpTool()
    {
        //点击捡起物体
        //timeHit += Time.deltaTime;
        //if (timeHit > 0.2f)
        //{
        if (Input.GetMouseButtonUp(0))
        {

            //Debug.LogError("hahah111");
            //no using tool
            timeHit = 0f;
            RaycastHit hit;
            bool isHit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 10f);


            if (isHit)
            {

                //Debug.Log(hit.transform.gameObject.name);
                //if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                //{
                //    Debug.Log("点击到UGUI的UI界面，会返回true");
                //}
                string itemTag = hit.transform.gameObject.tag;
                if (itemTag == "food")
                {
                    Debug.Log("haha");
                    characterItems.changeFood(1);
                    Destroy(hit.transform.gameObject);
                    eDU_Process.eatEvent();
                    toolSound.Get();
                }

                //update relative data                   
            }
        }
        //}
        //以下用于丢出物体
        //if (Input.GetKeyDown(KeyCode.G) && equipNum > 0)
        //{
        //    drop(Random.Range(1, 5));
        //}
    }


    //用于丢出物体
    //public void drop(int id)
    //{
    //    Vector3 dropPosition = cam.ScreenPointToRay(Input.mousePosition).GetPoint(2f);
    //    //动态加载预制体
    //    preFabCube = Resources.Load<GameObject>("tool" +id );
    //    newCube = GameObject.Instantiate(preFabCube, dropPosition, Quaternion.identity);
    //    equipNum--;
    //}

}