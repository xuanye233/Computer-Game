using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TakeAndDrop : MonoBehaviourPun
{
    public GameObject preFabCube;
    private GameObject newCube;
    public Camera cam;
    public int equipNum = 0;
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
        //cam = gameObject.GetComponent<Camera>();
        characterItems = GameObject.Find("Player(Clone)").GetComponent<CharacterItems>();
        //toolInteraction = GameObject.Find("Canvas/BagPanel/ToolList").GetComponent<ToolInteraction>();

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
                //no using tool
                timeHit = 0f;
                RaycastHit hit;
                bool isHit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 10f);

                if (isHit)
                {
                    string itemTag = hit.transform.gameObject.tag;
                    if (itemTag == "food" || itemTag == "blindDrug" || itemTag == "key" || itemTag == "fireStone")
                    {
                        
                        //PhotonNetwork.Destroy(hit.transform.gameObject);
                        PhotonView.RPC("destroyFood", RpcTarget.MasterClient, hit.transform.gameObject.GetComponent<PhotonView>().ViewID);                       
                        if (PhotonView.IsMine && itemTag == "food")
                        {
                            //Destroy(hit.transform.gameObject);
                            //Debug.Log("add 1");
                            characterItems.changeFood(1);
                        }
                        else if (itemTag == "blindDrug")
                        {
                            characterItems.changeBlindDrug(1);
                        }
                        //Debug.Log("hit");
                        //Debug.Log(characterItems.menuControl.num);
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

    [PunRPC]
    public void destroyFood(int viewID)
    {
        //Debug.Log(this.name);
        PhotonNetwork.Destroy(PhotonView.Find(viewID));
    }

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //等待之后执行的动作
    }
}
