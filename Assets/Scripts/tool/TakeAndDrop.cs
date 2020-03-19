using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeAndDrop : MonoBehaviour
{
    public GameObject preFabCube;
    private GameObject newCube;
    public Camera cam;
    public  int equipNum =0;
    private float timeHit = 0f;         //用于点击的时间间隔,每次点击时间间隔应大于0.2秒 

    CharacterItems characterItems;
    ToolInteraction toolInteraction;



    void Start()
    {
        //do
        //{
        //    StartCoroutine(Wait(5.0f));
        //} while (!GameObject.Find("Player(Clone)"));
        GameObject gameObject = GameObject.Find("Camera");
        cam = gameObject.GetComponent<Camera>();
        characterItems = GameObject.Find("Player(Clone)").GetComponent<CharacterItems>();
        toolInteraction = GameObject.Find("Canvas/ToolList").GetComponent<ToolInteraction>();
        
    }
    void Update()
    {
        PickUpTool();
    }  


    public void PickUpTool()
    {
        //点击捡起物体
        timeHit += Time.deltaTime;
        if (timeHit > 0.2f)
        {
            if (Input.GetMouseButton(0) && !toolInteraction.isTrapClick && !toolInteraction.isFireStoneClick)
            {
                //no using tool
                timeHit = 0f;
                RaycastHit hit;
                bool isHit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 10f);
                
                if (isHit)
                {
                    string itemTag = hit.transform.gameObject.tag;
                    if (itemTag == "food" || itemTag == "trap" || itemTag == "key" || itemTag == "fireStone")
                    {
                        Destroy(hit.transform.gameObject);
                        if (itemTag == "food")
                        {
                            characterItems.changeFood(1);
                        }
                        else if (itemTag == "trap")
                        {
                            characterItems.changeTrap(1);
                        }
                    }
                        
                    //update relative data                   
                }
            }
        }
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
    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //等待之后执行的动作
    }
}
