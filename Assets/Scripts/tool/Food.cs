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
    string Playername;
    //ToolInteraction toolInteraction;
    [SerializeField]
    Text noFoodText;
    GameObject curPlayer;
    GameObject canvas;
    public Text K1;
    public Text K2;
    public Text K3;
    public EDU_process eDU_Process;
    GameObject k1;
    GameObject k2;
    GameObject k3;
    Killfeed killfeed;
    GameObject achieve;
    //public Text SliderText;
    [SerializeField]
    ToolMenuControl toolMenuControl;
    private void Start()
    {
        curPlayer = GameObject.Find("Player(Clone)");
        characterItems = curPlayer.GetComponent<CharacterItems>();
        characterStatus = curPlayer.GetComponent<CharacterStatus>();
        toolSound = curPlayer.GetComponent<ToolSound>();
        //SliderText = GameObject.Find("Canvas/slider/SliderImage/SliderText").GetComponent<Text>();
        //print(SliderText);
        Playername = curPlayer.GetComponent<CharacterStatus>().username;
        canvas = GameObject.Find("Canvas");
        K1 = GameObject.Find("Canvas/Killfeed/K1/Text").GetComponent<Text>();
        K2 = GameObject.Find("Canvas/Killfeed/K2/Text").GetComponent<Text>();
        K3 = GameObject.Find("Canvas/Killfeed/K3/Text").GetComponent<Text>();
        k1 = GameObject.Find("Canvas/Killfeed/K1");
        k2 = GameObject.Find("Canvas/Killfeed/K2");
        k3 = GameObject.Find("Canvas/Killfeed/K3");
        achieve = GameObject.Find("AchievementManager");
        killfeed = GameObject.Find("Canvas").GetComponent<Killfeed>();
        //toolInteraction = GameObject.Find("Canvas/ToolList").GetComponent<ToolInteraction>();
        //noFoodText = GameObject.Find("Canvas/TipsList/NoFoodText").GetComponent<Text>();
        //noFoodText.gameObject.SetActive(false);
        //Debug.Log("setfalse");
        
    }

    public void onClicked()
    {

        //Debug.Log("Sssss");
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

            characterItems.changeFood(-1);
            characterStatus.ChangeHealth(5);
            if(GameObject.Find("Crystal_Caves") != null)
            {
                eDU_Process.eat2Event();
                toolMenuControl.transparent();
            }
            else
            {
                toolSound.Eat(curPlayer.GetComponent<PhotonView>().ViewID);
                achieve.GetComponent<SimpleAchievements.Main.AchievementsControl>().AddProgressAchievementByID(7, 1);
                PhotonView.RPC("showFoodEffect", RpcTarget.MasterClient, curPlayer.transform.position, curPlayer.GetComponent<CapsuleCollider>().center, curPlayer.transform.localScale.y);
                PhotonView.RPC("showFoodTips", RpcTarget.All, Playername);
            }
            
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

    [PunRPC]
    public void showFoodTips(string name)
    {
        if (killfeed.textcount == 0)
        {
            k1.SetActive(true);
        }
        else if (killfeed.textcount == 1)
        {
            k2.SetActive(true);
        }
        else if (killfeed.textcount == 2)
        {
            k3.SetActive(true);
        }
        if (K1.text == "")
        {
            K1.text = "<i>" + name + "</i> 使用了 <color=#73ccd5ff>魔法鸡腿</color> ";
        }
        else if (K2.text == "")
        {
            K2.text = "<i>" + name + "</i> 使用了 <color=#73ccd5ff>魔法鸡腿</color> ";
        }
        else if (K3.text == "")
        {
            K3.text = "<i>" + name + "</i> 使用了 <color=#73ccd5ff>魔法鸡腿</color> ";
        }
        else
        {
            K1.text = K2.text;
            K2.text = K3.text;
            K3.text = "<i>" + name + "</i> 使用了 <color=#73ccd5ff>魔法鸡腿</color> ";
        }
        killfeed.textcount++;
    }
}

