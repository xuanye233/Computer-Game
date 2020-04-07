using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

//绊脚石：降低敌人生命值

public class StumblingBlock : MonoBehaviourPunCallbacks
{
    [SerializeField] private float minDis = 3.0f; //在这个距离内才能影响到敌人
    [SerializeField] private float deVal = 20.0f; //减少的生命值
    [SerializeField] private int life = 5; //石头的生命周期
    public bool isTrapClick;
    Transform trapTransform;
    GameObject tempPlayer;
    CharacterItems characterItems;
    Text noTrapText;

    void Start()
    {
        characterItems = GameObject.Find("Player(Clone)").GetComponent<CharacterItems>();
        trapTransform = GameObject.Find("Canvas/ToolList/Trap/TrapImage").GetComponent<Transform>();
        noTrapText = GameObject.Find("Canvas/TipsList/NoTrapText").GetComponent<Text>();
        isTrapClick = false;
        noTrapText.gameObject.SetActive(false);
    }

    void Update()
    {
        noTrapText.gameObject.SetActive(false);
        if (isTrapClick && Input.GetMouseButtonDown(0) && characterItems.getStumblingBlock() > 0)
        {
            trapEvent();
        }
    }

    public void onClicked()
    {
        if (characterItems.getStumblingBlock() == 0)
        {
            showNoTrap();
            return;
        }
        else
        {
            isTrapClick = true;
            trapTransform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        //如果人碰到了绊脚石
    //        tempPlayer = other.gameObject;
    //        PhotonView.RPC("deleteStumblingBlock", RpcTarget.MasterClient, tempPlayer.GetComponent<PhotonView>().ViewID);
    //        //life--;
    //        //if (life <= 0)
    //        //{
    //        //    Destroy(gameObject);
    //        //}
    //    }
    //}

    public void showNoTrap()
    {
        noTrapText.gameObject.SetActive(true);//display the tips
        Debug.Log("notrap");

        //StartCoroutine(wait1());
        StartCoroutine(noTrapWait());//disappear smothly
    }

    IEnumerator noTrapWait() //fade function
    {
        //yield return new WaitForSeconds(5);
        noTrapText.CrossFadeAlpha(1, 1f, false);
        yield return new WaitForSeconds(1);
        noTrapText.CrossFadeAlpha(0, 1f, false);
    }

    public void trapEvent()
    {
        //Debug.Log("trapevent");
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 10.0f))
        {
            //GameObject newTrap = (GameObject)GameObject.Instantiate(Resources.Load("SM_Prop_Bricks_04"));
            //create the object in the scene
            //newTrap.transform.position = hit.point;
            PhotonView.RPC("createStumblingBlock", RpcTarget.MasterClient, hit.point);
            isTrapClick = false;
            //reset the flag
            //Debug.Log(hit.point);
            //Debug.DrawRay(hit.point, hit.normal, Color.green);

            //update the num of the traps
            trapTransform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            characterItems.changeTrap(-1);
        }
    }

    [PunRPC]
    public void createStumblingBlock(Vector3 position)
    {
        PhotonNetwork.Instantiate("Tool_Stumbling_Block", position, Quaternion.identity, 0);
    }


    //[PunRPC]
    //public void deleteStumblingBlock(int ViewID)
    //{
        
    //}
}
