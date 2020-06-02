using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEditor;

public class Herbs : MonoBehaviourPunCallbacks
{

    CharacterItems characterItems;
    CharacterStatus characterStatus;
    ThirdPersonUserControl thirdPersonUserControl;
    GameObject curPlayer;
    ToolSound toolSound;
    //public Text SliderText;
    public Text K1;
    public Text K2;
    public Text K3;
    string Playername;
    [SerializeField]
    ToolMenuControl toolMenuControl;
    private void Start()
    {
        curPlayer = GameObject.Find("Player(Clone)");
        toolSound = curPlayer.GetComponent<ToolSound>();
        characterItems = GameObject.Find("Player(Clone)").GetComponent<CharacterItems>();
        characterStatus = GameObject.Find("Player(Clone)").GetComponent<CharacterStatus>();
        thirdPersonUserControl = GameObject.Find("Player(Clone)").GetComponent<ThirdPersonUserControl>();
        //SliderText = GameObject.Find("Canvas/slider/SliderImage/SliderText").GetComponent<Text>();
        K1 = GameObject.Find("Canvas/Killfeed/K1/Text").GetComponent<Text>();
        K2 = GameObject.Find("Canvas/Killfeed/K2/Text").GetComponent<Text>();
        K3 = GameObject.Find("Canvas/Killfeed/K3/Text").GetComponent<Text>();
        Playername = curPlayer.GetComponent<CharacterStatus>().username;
    }

    public void onClicked()
    {

        //Debug.Log("Sssss");
        if (characterItems.getFood() == 0)//have no food available
        {
            //显示无草药

        }
        else//have enough food
        {
            PhotonView.RPC("showHealTips", RpcTarget.All, Playername);
            toolSound.Heal(curPlayer.GetComponent<PhotonView>().ViewID);
            characterItems.changeHerb(-1);
            thirdPersonUserControl.canMove = true;
            thirdPersonUserControl.canSee = true;
            toolMenuControl.transparent();
            //float hp = characterStatus.GetHealth();
            //characterStatus.ChangeHealth((float)(100 - hp > 0.5 * hp ? 0.5 * hp : 100 - hp));

            //PhotonView.RPC("showFoodEffect", RpcTarget.MasterClient, curPlayer.transform.position, curPlayer.GetComponent<CapsuleCollider>().center, curPlayer.transform.localScale.y);
        }
    }

    [PunRPC]
    public void showHealTips(string name)
    {
        if (K1.text == "")
        {
            K1.text = "<i>" + name + "</i> 使用了 <color=#73ccd5ff>神秘草药</color> ";
        }
        else if (K2.text == "")
        {
            K2.text = "<i>" + name + "</i> 使用了 <color=#73ccd5ff>神秘草药</color> ";
        }
        else if (K3.text == "")
        {
            K3.text = "<i>" + name + "</i> 使用了 <color=#73ccd5ff>神秘草药</color> ";
        }
        else
        {
            K1.text = K2.text;
            K2.text = K3.text;
            K3.text = "<i>" + name + "</i> 使用了 <color=#73ccd5ff>神秘草药</color> ";
        }
    }
}
