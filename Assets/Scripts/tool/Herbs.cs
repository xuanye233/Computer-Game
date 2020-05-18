using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herbs : MonoBehaviour
{

    CharacterItems characterItems;
    CharacterStatus characterStatus;
    ThirdPersonUserControl thirdPersonUserControl;
    private void Start()
    {
        characterItems = GameObject.Find("Player(Clone)").GetComponent<CharacterItems>();
        characterStatus = GameObject.Find("Player(Clone)").GetComponent<CharacterStatus>();
        thirdPersonUserControl = GameObject.Find("Player(Clone)").GetComponent<ThirdPersonUserControl>();
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
            characterItems.changeHerb(-1);
            thirdPersonUserControl.canMove = true;
            thirdPersonUserControl.canSee = true;
            //float hp = characterStatus.GetHealth();
            //characterStatus.ChangeHealth((float)(100 - hp > 0.5 * hp ? 0.5 * hp : 100 - hp));

            //PhotonView.RPC("showFoodEffect", RpcTarget.MasterClient, curPlayer.transform.position, curPlayer.GetComponent<CapsuleCollider>().center, curPlayer.transform.localScale.y);
        }
    }
}
