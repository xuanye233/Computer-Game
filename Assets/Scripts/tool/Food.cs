using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Food : MonoBehaviourPunCallbacks
{
    CharacterItems characterItems;
    CharacterStatus characterStatus;
    ToolSound toolSound;
    //ToolInteraction toolInteraction;
    [SerializeField]
    Text noFoodText;
    GameObject curPlayer;

    private void Start()
    {
        if(GameObject.Find("Player(Clone)") == null){
            curPlayer = GameObject.Find("Player");
        }
        else
        {
            curPlayer = GameObject.Find("Player(Clone)");
        }
        
        characterItems = curPlayer.GetComponent<CharacterItems>();
        characterStatus = curPlayer.GetComponent<CharacterStatus>();
        toolSound = curPlayer.GetComponent<ToolSound>();
        //toolInteraction = GameObject.Find("Canvas/ToolList").GetComponent<ToolInteraction>();
        //noFoodText = GameObject.Find("Canvas/TipsList/NoFoodText").GetComponent<Text>();
        //noFoodText.gameObject.SetActive(false);
        //Debug.Log("setfalse");
    }

    public void onClicked()
    {

        Debug.Log("Sssss");
        Debug.Log(characterItems.getFood());
        if (characterItems.getFood() == 0)//have no food available
        {
            noFoodText.gameObject.SetActive(true);
            Debug.Log("nofood");

            //StartCoroutine(wait1());
            StartCoroutine(noFoodWait());//disappear smothly

            //double currentTime = 0;

            ////Debug.Log("current" + currentTime);
            //Color newColor = foodText.material.color;
            //float proportion;

            //while (currentTime <= duration)
            //{

            //    proportion = ((float)currentTime / duration);
            //    newColor.a = Mathf.Lerp(1, 0, proportion);
            //    foodText.material.color = newColor;

            //    //if (Time.time > duration)
            //    //{
            //    //    foodText.gameObject.SetActive(false);

            //    //}
            //    currentTime += Convert.ToDouble(Time.deltaTime.ToString());
            //    Debug.Log("current" + currentTime);
            //}
            //foodText.gameObject.SetActive(false);

        }
        else//have enough food
        {
            Debug.Log("chile");
            characterItems.changeFood(-1);
            characterStatus.ChangeHealth(5);
            //toolSound.Eat(curPlayer.GetComponent<PhotonView>().ViewID);
            //PhotonView.RPC("showFoodEffect", RpcTarget.MasterClient, curPlayer.transform.position, curPlayer.GetComponent<CapsuleCollider>().center, curPlayer.transform.localScale.y);

        }
    }
    public IEnumerator noFoodWait() //fade function
    {
        //yield return new WaitForSeconds(5);
        noFoodText.CrossFadeAlpha(1, 1f, false);
        yield return new WaitForSeconds(1);
        noFoodText.CrossFadeAlpha(0, 1f, false);
    }

    [PunRPC]
    public void showFoodEffect(Vector3 position, Vector3 center, float scale)
    {
        Vector3 centerPos = position + center * scale * 1.5f;
        PhotonNetwork.Instantiate("Effects/FoodEffect", centerPos, Quaternion.identity, 0);
    }

}

