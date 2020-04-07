using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ThunderstormStone : MonoBehaviourPunCallbacks
{
    CharacterItems characterItems;
    public bool isThunderstormStoneClick;

    private void Start()
    {
        characterItems = GameObject.Find("Player(Clone)").GetComponent<CharacterItems>();
        isThunderstormStoneClick = false;
        Debug.Log(" isThunderstormStoneClick = false;");
    }

    void Update()
    {
        //Debug.Log(isThunderstormStoneClick && Input.GetMouseButtonDown(0));
        //noTrapText.gameObject.SetActive(false);
        if (isThunderstormStoneClick && Input.GetMouseButtonDown(0) && characterItems.getThunderstormStone() > 0)
        {
            Debug.Log("3");
            ThunderstormStoneClickEvent();
        }
    }

    public void onClicked()
    {
        //Debug.Log("1");
        if (characterItems.getThunderstormStone() == 0)
        {
            //showNoTrap();
            return;
        }
        else
        {
            //Debug.Log("2");
            isThunderstormStoneClick = true;
            //trapTransform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }
    }

    public void ThunderstormStoneClickEvent()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 10.0f))
        {
            //Debug.Log("4");
            //GameObject newTrap = (GameObject)GameObject.Instantiate(Resources.Load("SM_Prop_Bricks_04"));
            //create the object in the scene
            //newTrap.transform.position = hit.point;
            PhotonView.RPC("createThunderstorm", RpcTarget.MasterClient, hit.point);
            isThunderstormStoneClick = false;
            //reset the flag
            //Debug.Log(hit.point);
            //Debug.DrawRay(hit.point, hit.normal, Color.green);

            //update the num of the traps
            //trapTransform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            characterItems.changeThunderstormStone(-1);
        }
    }



    [PunRPC]
    public void createThunderstorm(Vector3 position)
    {
        PhotonNetwork.Instantiate("Tool_Thunderstorm_Stone", position, Quaternion.identity, 0);
    }

    //void exposure()
    //{
    //    PhotonNetwork.Instantiate("PlayerCube", GameObject.Find("MapCamera/PlayerCube").transform.position, Quaternion.identity, 0);

    //}

    
}
