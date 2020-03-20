using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ToolUIController : MonoBehaviourPun
{
    //Player player;
    CharacterItems characterItems;
    Text foodNumText;
    Text trapNumText;
    Text fireStoneNumText;
    // Start is called before the first frame update
    void Start()
    {
        //do
        //{
        //    StartCoroutine(Wait(5.0f));
        //} while (!GameObject.Find("Player(Clone)"));
        //player = GameObject.Find("Player").GetComponent<Player>();

        characterItems = GameObject.Find("Player(Clone)").GetComponent<CharacterItems>();
        foodNumText = GameObject.Find("Canvas/ToolList/Food/FoodNum").GetComponent<Text>();
        trapNumText = GameObject.Find("Canvas/ToolList/Trap/TrapNum").GetComponent<Text>();
        fireStoneNumText = GameObject.Find("Canvas/ToolList/FireStone/FireStoneNum").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!photonView.IsMine && PhotonNetwork.IsConnected)
        //{
        //    return;
        //}
        upDateTool();
    }

    void upDateTool()
    {
        //Debug.Log(foodNum);
        foodNumText.text = "X " + characterItems.getFood().ToString();
        trapNumText.text = "X " + characterItems.getTrap().ToString();
        fireStoneNumText.text = "X " + characterItems.getFireStone().ToString();
    }

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //等待之后执行的动作
    }
}
