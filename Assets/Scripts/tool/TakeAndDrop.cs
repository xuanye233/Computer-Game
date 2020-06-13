using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class TakeAndDrop : MonoBehaviourPun
{
    public GameObject preFabCube;
    private GameObject newCube;
    public Camera cam;
    public int equipNum = 0;
    private float timeHit = 0f;         //用于点击的时间间隔,每次点击时间间隔应大于0.2秒 

    CharacterItems characterItems;
    ToolInteraction toolInteraction;
    public Text K1;
    public Text K2;
    public Text K3;
    public string Playername;
    ToolSound toolSound;
    private GameObject curPlayer;
    GameObject k1;
    GameObject k2;
    GameObject k3;
    Killfeed killfeed;
    Gem gem;

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
        toolSound = curPlayer.GetComponent<ToolSound>();
        K1 = GameObject.Find("Canvas/Killfeed/K1/Text").GetComponent<Text>();
        K2 = GameObject.Find("Canvas/Killfeed/K2/Text").GetComponent<Text>();
        K3 = GameObject.Find("Canvas/Killfeed/K3/Text").GetComponent<Text>();
        Playername = curPlayer.GetComponent<CharacterStatus>().username;
        gem = GameObject.Find("Canvas/Gems").GetComponent<Gem>();
        k1 = GameObject.Find("Canvas/Killfeed/K1");
        k2 = GameObject.Find("Canvas/Killfeed/K2");
        k3 = GameObject.Find("Canvas/Killfeed/K3");
        killfeed = GameObject.Find("Canvas").GetComponent<Killfeed>();
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
                Debug.Log(hit.transform.gameObject.name);
                if (itemTag == "food" || itemTag == "blindDrug" || itemTag == "key" || itemTag == "fireStone" || itemTag == "gemA" || itemTag == "gemB" || itemTag == "gemC" || itemTag == "gemD" || itemTag == "BirthStone" || itemTag == "Stumbling" || itemTag == "Thunderstorm" || itemTag == "Still" || itemTag == "Teleportation" || itemTag == "JewelThief" || itemTag == "Herbs" || itemTag == "MoonStone")
                {
                    Debug.Log("jinru");
                    toolSound.Get(curPlayer.GetComponent<PhotonView>().ViewID);
                    //PhotonNetwork.Destroy(hit.transform.gameObject);
                    PhotonView.RPC("destroyFood", RpcTarget.MasterClient, hit.transform.gameObject.GetComponent<PhotonView>().ViewID);
                    if (PhotonView.IsMine && itemTag == "food")
                    {
                        //Destroy(hit.transform.gameObject);
                        //Debug.Log("add 1");
                        characterItems.changeFood(1);
                        showTakeFood(Playername);
                        //PhotonView.RPC("showTakeFood", RpcTarget.All, Playername);
                    }
                    else if (itemTag == "blindDrug")
                    {
                        characterItems.changeBlindDrug(1);
                        showTakeBlindDrug(Playername);
                        //PhotonView.RPC("showTakeBlindDrug", RpcTarget.All, Playername);
                    }
                    else if (itemTag == "fireStone")
                    {
                        characterItems.changeBlindDrug(1);
                        showTakeFireStone(Playername);
                        //PhotonView.RPC("showTakeFireStone", RpcTarget.All, Playername);
                    }
                    else if (PhotonView.IsMine && itemTag == "gemA")
                    {
                        gem.changeA(1);
                        showTakeGemA(Playername);
                    }
                    else if (PhotonView.IsMine && itemTag == "gemB")
                    {
                        gem.changeB(1);
                        showTakeGemB(Playername);
                    }
                    else if (PhotonView.IsMine && itemTag == "gemC")
                    {
                        gem.changeC(1);
                        showTakeGemC(Playername);
                    }
                    else if (PhotonView.IsMine && itemTag == "gemD")
                    {
                        gem.changeD(1);
                        showTakeGemD(Playername);
                    }
                    else if (PhotonView.IsMine && itemTag == "BirthStone")
                    {
                        characterItems.changeOriginStone(1);
                        showTakeBirthStone(Playername);
                    }
                    else if (PhotonView.IsMine && itemTag == "Stumbling")
                    {
                        characterItems.changeStumblingBolack(1);
                        showTakeStumbling(Playername);
                    }
                    else if (PhotonView.IsMine && itemTag == "Thunderstorm")
                    {
                        characterItems.changeThunderstormStone(1);
                        showTakeThunderstorm(Playername);
                    }
                    else if (PhotonView.IsMine && itemTag == "Still")
                    {
                        characterItems.changeFixPotion(1);
                        showTakeStill(Playername);
                    }
                    else if (PhotonView.IsMine && itemTag == "Teleportation")
                    {
                        characterItems.changeThunderstormStone(1);
                        showTakeTeleportation(Playername);
                    }
                    else if (PhotonView.IsMine && itemTag == "JewelThief")
                    {
                        characterItems.changeJewelThief(1);
                        showTakeJewelThief(Playername);
                    }
                    else if (PhotonView.IsMine && itemTag == "Herbs")
                    {
                        characterItems.changeHerb(1);
                        showTakeHerbs(Playername);
                    }
                    else if (PhotonView.IsMine && itemTag == "Moonstone")
                    {
                        characterItems.changeMoonStone(1);
                        showTakeMoonstone(Playername);
                    }

                    //Debug.Log("hit");
                    //Debug.Log(characterItems.menuControl.num);
                }
                else if (PhotonView.IsMine && itemTag == "chest")
                {
                    Debug.Log("haha");
                    chestOpen chestopen = hit.transform.gameObject.GetComponentInChildren<chestOpen>();
                    chestopen.chestOpenEvent();
                }
                else if(PhotonView.IsMine && itemTag == "door1" || itemTag == "door2")
                {
                    //开门
                    DoorOpen doorOpen = hit.transform.parent.GetComponent<DoorOpen>();
                    doorOpen.doopMove();
                    /*
                    if(hit.transform.parent.tag == "door11")
                    {
                        doorOpen.doorEvent11();
                    }
                    else if (hit.transform.parent.tag == "door12")
                    {
                        doorOpen.doorEvent12();
                    }
                    else if (hit.transform.parent.tag == "door13")
                    {
                        doorOpen.doorEvent13();
                    }
                    else if (hit.transform.parent.tag == "door31")
                    {
                        doorOpen.doorEvent31();
                    }
                    else if (hit.transform.parent.tag == "door32")
                    {
                        doorOpen.doorEvent32();
                    }
                    else if (hit.transform.parent.tag == "door33")
                    {
                        doorOpen.doorEvent33();
                    }
                    else if (hit.transform.parent.tag == "door41")
                    {
                        doorOpen.doorEvent41();
                    }
                    else if (hit.transform.parent.tag == "door42")
                    {
                        doorOpen.doorEvent42();
                    }
                    */
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

    public void showTakeFood(string name)
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
            K1.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>魔法鸡腿</color> ";
        }
        else if (K2.text == "")
        {
            K2.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>魔法鸡腿</color> ";
        }
        else if (K3.text == "")
        {
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>魔法鸡腿</color> ";
        }
        else
        {
            K1.text = K2.text;
            K2.text = K3.text;
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>魔法鸡腿</color> ";
        }
        killfeed.textcount++;
    }

    public void showTakeBlindDrug(string name)
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
            K1.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>失明药水</color> ";
        }
        else if (K2.text == "")
        {
            K2.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>失明药水</color> ";
        }
        else if (K3.text == "")
        {
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>失明药水</color> ";
        }
        else
        {
            K1.text = K2.text;
            K2.text = K3.text;
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>失明药水</color> ";
        }
        killfeed.textcount++;
    }

    public void showTakeKey(string name)
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
            K1.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>钥匙</color> ";
        }
        else if (K2.text == "")
        {
            K2.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>钥匙</color> ";
        }
        else if (K3.text == "")
        {
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>钥匙</color> ";
        }
        else
        {
            K1.text = K2.text;
            K2.text = K3.text;
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>钥匙</color> ";
        }
        killfeed.textcount++;
    }

    public void showTakeFireStone(string name)
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
            K1.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>打火石</color> ";
        }
        else if (K2.text == "")
        {
            K2.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>打火石</color> ";
        }
        else if (K3.text == "")
        {
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>打火石</color> ";
        }
        else
        {
            K1.text = K2.text;
            K2.text = K3.text;
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>打火石</color> ";
        }
        killfeed.textcount++;
    }
    public void showTakeGemA(string name)
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
            K1.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>宝石A</color> ";
        }
        else if (K2.text == "")
        {
            K2.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>宝石A</color> ";
        }
        else if (K3.text == "")
        {
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>宝石A</color> ";
        }
        else
        {
            K1.text = K2.text;
            K2.text = K3.text;
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>宝石A</color> ";
        }
        killfeed.textcount++;
    }
    public void showTakeGemB(string name)
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
            K1.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>宝石B</color> ";
        }
        else if (K2.text == "")
        {
            K2.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>宝石B</color> ";
        }
        else if (K3.text == "")
        {
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>宝石B</color> ";
        }
        else
        {
            K1.text = K2.text;
            K2.text = K3.text;
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>宝石B</color> ";
        }
        killfeed.textcount++;
    }
    public void showTakeGemC(string name)
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
            K1.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>宝石C</color> ";
        }
        else if (K2.text == "")
        {
            K2.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>宝石C</color> ";
        }
        else if (K3.text == "")
        {
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>宝石C</color> ";
        }
        else
        {
            K1.text = K2.text;
            K2.text = K3.text;
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>宝石C</color> ";
        }
        killfeed.textcount++;
    }
    public void showTakeGemD(string name)
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
            K1.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>宝石D</color> ";
        }
        else if (K2.text == "")
        {
            K2.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>宝石D</color> ";
        }
        else if (K3.text == "")
        {
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>宝石D</color> ";
        }
        else
        {
            K1.text = K2.text;
            K2.text = K3.text;
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>宝石D</color> ";
        }
        killfeed.textcount++;
    }
    public void showTakeBirthStone(string name)
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
            K1.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>起源之石</color> ";
        }
        else if (K2.text == "")
        {
            K2.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>起源之石</color> ";
        }
        else if (K3.text == "")
        {
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>起源之石</color> ";
        }
        else
        {
            K1.text = K2.text;
            K2.text = K3.text;
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>起源之石</color> ";
        }
        killfeed.textcount++;
    }
    public void showTakeStumbling(string name)
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
            K1.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>绊脚石</color> ";
        }
        else if (K2.text == "")
        {
            K2.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>绊脚石</color> ";
        }
        else if (K3.text == "")
        {
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>绊脚石</color> ";
        }
        else
        {
            K1.text = K2.text;
            K2.text = K3.text;
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>绊脚石</color> ";
        }
        killfeed.textcount++;
    }
    public void showTakeThunderstorm(string name)
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
            K1.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>雷暴石</color> ";
        }
        else if (K2.text == "")
        {
            K2.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>雷暴石</color> ";
        }
        else if (K3.text == "")
        {
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>雷暴石</color> ";
        }
        else
        {
            K1.text = K2.text;
            K2.text = K3.text;
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>雷暴石</color> ";
        }
        killfeed.textcount++;
    }
    public void showTakeStill(string name)
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
            K1.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>定位药水</color> ";
        }
        else if (K2.text == "")
        {
            K2.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>定位药水</color> ";
        }
        else if (K3.text == "")
        {
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>定位药水</color> ";
        }
        else
        {
            K1.text = K2.text;
            K2.text = K3.text;
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>定位药水</color> ";
        }
        killfeed.textcount++;
    }
    public void showTakeTeleportation(string name)
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
            K1.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>移形换位</color> ";
        }
        else if (K2.text == "")
        {
            K2.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>移形换位</color> ";
        }
        else if (K3.text == "")
        {
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>移形换位</color> ";
        }
        else
        {
            K1.text = K2.text;
            K2.text = K3.text;
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>移形换位</color> ";
        }
        killfeed.textcount++;
    }
    public void showTakeJewelThief(string name)
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
            K1.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>宝石大盗</color> ";
        }
        else if (K2.text == "")
        {
            K2.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>宝石大盗</color> ";
        }
        else if (K3.text == "")
        {
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>宝石大盗</color> ";
        }
        else
        {
            K1.text = K2.text;
            K2.text = K3.text;
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>宝石大盗</color> ";
        }
        killfeed.textcount++;
    }
    public void showTakeHerbs(string name)
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
            K1.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>神秘草药</color> ";
        }
        else if (K2.text == "")
        {
            K2.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>神秘草药</color> ";
        }
        else if (K3.text == "")
        {
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>神秘草药</color> ";
        }
        else
        {
            K1.text = K2.text;
            K2.text = K3.text;
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>神秘草药</color> ";
        }
        killfeed.textcount++;
    }
    public void showTakeMoonstone(string name)
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
            K1.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>月亮石</color> ";
        }
        else if (K2.text == "")
        {
            K2.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>月亮石</color> ";
        }
        else if (K3.text == "")
        {
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>月亮石</color> ";
        }
        else
        {
            K1.text = K2.text;
            K2.text = K3.text;
            K3.text = "<i> 你 </i> 拾取了 <color=#e43b72ff>月亮石</color> ";
        }
        killfeed.textcount++;
    }
}

