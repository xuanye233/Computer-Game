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
    }

    public void onClick()
    {
        if (toolMenuControl.isQuit && name != "None")
        {
            quitTool();
        }
        else if(name == "food")
        {
            food.onClicked();
        }
    } 

    private void quitTool()
    {
        //toolMenuControl.delete(1);
        GameObject obj = this.gameObject.transform.parent.gameObject;
        string changename = obj.name;
        changename = changename.Substring(changename.Length - 1, 1);//显示1
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
