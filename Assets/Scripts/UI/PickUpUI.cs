using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpUI : MonoBehaviour
{  
    public GameObject pickUpItem;
    GameObject player;

    void Start()
    {
        pickUpItem.SetActive(false);
        player = GameObject.Find("Player(Clone)");
    }

    [System.Obsolete]
    private void Update()
    {
        if(pickUpItem.active == true)
        {
            return;
        }
        RaycastHit hit1, hit2, hit3, hit4;
        bool isHit1 = Physics.Raycast(player.transform.position,new Vector3(1,0,0), out hit1, 10f);
        bool isHit2 = Physics.Raycast(player.transform.position, new Vector3(-1, 0, 0), out hit2, 10f);
        bool isHit3 = Physics.Raycast(player.transform.position, new Vector3(0, 0, 1), out hit3, 10f);
        bool isHit4 = Physics.Raycast(player.transform.position, new Vector3(0, 0, -1), out hit4, 10f);
        Debug.Log(hit1.transform.tag);
        Debug.DrawRay(player.transform.position, new Vector3(1, 0, 0), Color.green, 20.0f);
        if (isHit1 || isHit2 || isHit3 || isHit4)
        {
            if((isHit1 && hit1.transform.tag == "Thunderstorm") || (isHit2 && hit2.transform.tag == "Thunderstorm") || (isHit1 && hit1.transform.tag == "Thunderstorm") || (isHit4 && hit4.transform.tag == "Thunderstorm"))
            {
                pickUpItem.SetActive(true);
                Sprite loadImage = Resources.Load("Picture/thunderstormStone", typeof(Sprite)) as Sprite;
                GameObject.Find("Canvas/PickupItem/image").GetComponent<Image>().sprite = loadImage;
                GameObject.Find("Canvas/PickupItem/name").GetComponent<Text>().text = "雷暴石";
                StartCoroutine(Wait());
            }
            else if ((isHit1 && hit1.transform.tag == "Stumbling") || (isHit2 && hit2.transform.tag == "Stumbling") || (isHit1 && hit1.transform.tag == "Stumbling") || (isHit4 && hit4.transform.tag == "Stumbling"))
            {
                pickUpItem.SetActive(true);
                Sprite loadImage = Resources.Load("Picture/stumblingBlock", typeof(Sprite)) as Sprite;
                GameObject.Find("Canvas/PickupItem/image").GetComponent<Image>().sprite = loadImage;
                GameObject.Find("Canvas/PickupItem/name").GetComponent<Text>().text = "绊脚石";
                StartCoroutine(Wait());
            }
            else if ((isHit1 && hit1.transform.tag == "food") || (isHit2 && hit2.transform.tag == "food") || (isHit1 && hit1.transform.tag == "food") || (isHit4 && hit4.transform.tag == "food"))
            {
                pickUpItem.SetActive(true);
                Sprite loadImage = Resources.Load("Picture/food", typeof(Sprite)) as Sprite;
                GameObject.Find("Canvas/PickupItem/image").GetComponent<Image>().sprite = loadImage;
                GameObject.Find("Canvas/PickupItem/name").GetComponent<Text>().text = "魔法鸡腿";
                StartCoroutine(Wait());
            }
            else if ((isHit1 && hit1.transform.tag == "blindDrug") || (isHit2 && hit2.transform.tag == "blindDrug") || (isHit1 && hit1.transform.tag == "blindDrug") || (isHit4 && hit4.transform.tag == "blindDrug"))
            {
                pickUpItem.SetActive(true);
                Sprite loadImage = Resources.Load("Picture/blindDrug", typeof(Sprite)) as Sprite;
                GameObject.Find("Canvas/PickupItem/image").GetComponent<Image>().sprite = loadImage;
                GameObject.Find("Canvas/PickupItem/name").GetComponent<Text>().text = "失明药水";
                StartCoroutine(Wait());
            }
            else if ((isHit1 && hit1.transform.tag == "fireStone") || (isHit2 && hit2.transform.tag == "fireStone") || (isHit1 && hit1.transform.tag == "fireStone") || (isHit4 && hit4.transform.tag == "fireStone"))
            {
                pickUpItem.SetActive(true);
                Sprite loadImage = Resources.Load("Picture/fireStone", typeof(Sprite)) as Sprite;
                GameObject.Find("Canvas/PickupItem/image").GetComponent<Image>().sprite = loadImage;
                GameObject.Find("Canvas/PickupItem/name").GetComponent<Text>().text = "打火石";
                StartCoroutine(Wait());
            }
            else if ((isHit1 && hit1.transform.tag == "BirthStone") || (isHit2 && hit2.transform.tag == "BirthStone") || (isHit1 && hit1.transform.tag == "BirthStone") || (isHit4 && hit4.transform.tag == "BirthStone"))
            {
                pickUpItem.SetActive(true);
                Sprite loadImage = Resources.Load("Picture/OriginStone", typeof(Sprite)) as Sprite;
                GameObject.Find("Canvas/PickupItem/image").GetComponent<Image>().sprite = loadImage;
                GameObject.Find("Canvas/PickupItem/name").GetComponent<Text>().text = "原生石";
                StartCoroutine(Wait());
            }
            else if ((isHit1 && hit1.transform.tag == "Still") || (isHit2 && hit2.transform.tag == "Still") || (isHit1 && hit1.transform.tag == "Still") || (isHit4 && hit4.transform.tag == "Still"))
            {
                pickUpItem.SetActive(true);
                Sprite loadImage = Resources.Load("Picture/fixPotion", typeof(Sprite)) as Sprite;
                GameObject.Find("Canvas/PickupItem/image").GetComponent<Image>().sprite = loadImage;
                GameObject.Find("Canvas/PickupItem/name").GetComponent<Text>().text = "静止药水";
                StartCoroutine(Wait());
            }
            else if ((isHit1 && hit1.transform.tag == "Teleportation") || (isHit2 && hit2.transform.tag == "Teleportation") || (isHit1 && hit1.transform.tag == "Teleportation") || (isHit4 && hit4.transform.tag == "Teleportation"))
            {
                pickUpItem.SetActive(true);
                Sprite loadImage = Resources.Load("Picture/teleportation", typeof(Sprite)) as Sprite;
                GameObject.Find("Canvas/PickupItem/image").GetComponent<Image>().sprite = loadImage;
                GameObject.Find("Canvas/PickupItem/name").GetComponent<Text>().text = "移形换位";
                StartCoroutine(Wait());
            }
            else if ((isHit1 && hit1.transform.tag == "JewelThief") || (isHit2 && hit2.transform.tag == "JewelThief") || (isHit1 && hit1.transform.tag == "JewelThief") || (isHit4 && hit4.transform.tag == "JewelThief"))
            {
                pickUpItem.SetActive(true);
                Sprite loadImage = Resources.Load("Picture/jewelThief", typeof(Sprite)) as Sprite;
                GameObject.Find("Canvas/PickupItem/image").GetComponent<Image>().sprite = loadImage;
                GameObject.Find("Canvas/PickupItem/name").GetComponent<Text>().text = "宝石大盗";
                StartCoroutine(Wait());
            }
            else if ((isHit1 && hit1.transform.tag == "Herbs") || (isHit2 && hit2.transform.tag == "Herbs") || (isHit1 && hit1.transform.tag == "Herbs") || (isHit4 && hit4.transform.tag == "Herbs"))
            {
                pickUpItem.SetActive(true);
                Sprite loadImage = Resources.Load("Picture/herb", typeof(Sprite)) as Sprite;
                GameObject.Find("Canvas/PickupItem/image").GetComponent<Image>().sprite = loadImage;
                GameObject.Find("Canvas/PickupItem/name").GetComponent<Text>().text = "神秘草药";
                StartCoroutine(Wait());
            }
            else if ((isHit1 && hit1.transform.tag == "MoonStone") || (isHit2 && hit2.transform.tag == "MoonStone") || (isHit1 && hit1.transform.tag == "MoonStone") || (isHit4 && hit4.transform.tag == "MoonStone"))
            {
                pickUpItem.SetActive(true);
                Sprite loadImage = Resources.Load("Picture/moonStone", typeof(Sprite)) as Sprite;
                GameObject.Find("Canvas/PickupItem/image").GetComponent<Image>().sprite = loadImage;
                GameObject.Find("Canvas/PickupItem/name").GetComponent<Text>().text = "月光石";
                StartCoroutine(Wait());
            }
            else if ((isHit1 && hit1.transform.tag == "chest") || (isHit2 && hit2.transform.tag == "chest") || (isHit1 && hit1.transform.tag == "chest") || (isHit4 && hit4.transform.tag == "chest"))
            {
                pickUpItem.SetActive(true);
                Sprite loadImage = Resources.Load("Picture/chest", typeof(Sprite)) as Sprite;
                GameObject.Find("Canvas/PickupItem/image").GetComponent<Image>().sprite = loadImage;
                GameObject.Find("Canvas/PickupItem/name").GetComponent<Text>().text = "宝箱";
                StartCoroutine(Wait());
            }
            


        }
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        pickUpItem.SetActive(false);
    }

}
