using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class toolImageControl : MonoBehaviour
{
    public string name;
    ToolMenuControl toolMenuControl;
    CharacterItems characterItems;
    Food food;
    [SerializeField]
    FireStone fireStone;
    [SerializeField]
    BlindDrug blindDrug;
    [SerializeField]
    OriginStone originStone;
    [SerializeField]
    StumblingBlock stumblingBlock;
    [SerializeField]
    FixPotion fixPotion;
    [SerializeField]
    ThunderstormStone thunderstormStone;
    [SerializeField]
    Teleportation teleportation;
    [SerializeField]
    JewelThief jewelThief;
    [SerializeField]
    Herbs herbs;
    //[SerializeField]
    //MoonStone mooonStone;

    private void Start()
    {
        name = "None";
        food = GameObject.Find("Canvas/ToolsBar").GetComponent<Food>();
        toolMenuControl = GameObject.Find("Canvas/ToolsBar").GetComponent<ToolMenuControl>();
        characterItems = GameObject.Find("Player(Clone)").GetComponent<CharacterItems>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            toolMenuControl.isQuit = true;
        }
        //Debug.Log(name);
    }

    public void onClick()
    {
        GameObject obj = this.gameObject.transform.parent.gameObject;
        string changename = obj.name;//点击图标的物体名字
        changename = changename.Substring(changename.Length - 1, 1);
     
        Sprite loadImage = Resources.Load("Picture/Tool_selected", typeof(Sprite)) as Sprite;
        toolMenuControl.bgImages[int.Parse(changename)].sprite = loadImage;
        //Debug.LogError(name);
        if (toolMenuControl.isQuit && name != "None")
        {
            quitTool();
        }
        else if(name == "food")
        {
            food.onClicked();
        }
        else if(name == "fireStone")
        {
            fireStone.onClicked();
        }
        else if(name == "blindDrug")
        {
            blindDrug.onClick();
        }
        else if (name == "originStone")
        {
            originStone.onClicked();
        }
        else if (name == "stumblingBlock")
        {
            stumblingBlock.onClicked();
        }
        else if (name == "fixPotion")
        {
            fixPotion.onClicked();
        }
        else if (name == "thunderstormStone")
        {
            thunderstormStone.onClicked();
        }
        else if (name == "teleportation")
        {
            teleportation.onClicked();
        }
        else if (name == "jewelThief")
        {
            jewelThief.onClicked();
        }
        else if (name == "herb")
        {
            herbs.onClicked();
        }
        //else if (name == "moonStone")
        //{
        //    moonStone.onClicked();
        //}
        toolMenuControl.transparent();
    } 

    private void quitTool()
    {
        //toolMenuControl.delete(1);
        GameObject obj = this.gameObject.transform.parent.gameObject;
        string changename = obj.name;//点击图标的物体名字
        changename = changename.Substring(changename.Length - 1, 1);
        //修改菜单
        //从菜单中删除
        characterItems.deleteMenu(characterItems.menuControl.toolMenu[int.Parse(changename) - 1].name, characterItems.menuControl);
        //该格子名字初始化
        name = "None";

        toolMenuControl.updateNum(int.Parse(changename), 0);
        toolMenuControl.delete(int.Parse(changename));

        toolMenuControl.isQuit = false;
    }
}
