using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class MenuControl
{
    public MenuControl()
    {
        num = 0;
        toolMenu = new List<Item>();
    }
    public int num;
    public List<Item> toolMenu;
}

public class Item
{
    public Item(int id)
    {
        this.id = id;
        num = 0;
        name = "None";
    }
    public int id;
    public int num;
    public string name;
}

public class CharacterItems : MonoBehaviour
{
    public MenuControl menuControl;
    ToolMenuControl toolMenuControl;
    toolImageControl toolimgcontrol;
    //ArrayList toolMenu;
    //Dictionary<string, int> toolAmount;
    int fireStone;
    int food;
    int trap;
    int originStone;
    int stumblingBolack;
    int fixPotion;
    int blindDrug;
    int teleportation;
    int stumblingBlock;
    int thunderstormStone;
    int herb;
    int moonStone;
    int id;
    List<int> key;

    int jewelThief;//jewelthief的数量
    int jewel;//后续改成list，现在先用单个测试

    Text fireStoneText;

    void Start()
    {
        fireStoneText = GameObject.Find("Canvas/ToolsBar/Tool_0_firestone/Tool_0_amount").GetComponent<Text>();
        toolMenuControl = GameObject.Find("Canvas/ToolsBar").GetComponent<ToolMenuControl>();
        fireStone = 5;
        food = 0;
        trap = 0;
        originStone = 0;
        stumblingBolack = 0;
        fixPotion = 0;
        blindDrug = 0;
        teleportation = 0;
        stumblingBlock = 0;
        thunderstormStone = 0;
        herb = 0;
        moonStone = 0;
        id = GlobalData.characterIndex;

        jewelThief = 0;
        jewel = 0;
        key = new List<int>();
        menuControl = new MenuControl();
        for(int i = 1;i <= 5; i++)
        {
            Item item = new Item(i);
            menuControl.toolMenu.Add(item);
        }

        //if (id == 4)
        //{
        //    jewel = 1;
        //}
        //changeFood(10);
        //changeBlindDrug(5);
    }
    public int getID()
    {
        return id;
    }

    public int getOriginStone()
    {
        return originStone;
    }

    public int getMoonStone()
    {
        return moonStone;
    }

    public int getFixPotion()
    {
        return fixPotion;
    }

    public int getStumblingBolack()
    {
        return stumblingBolack;
    }

    public int getFood()
    {
        return food;
    }

    public int getTrap()
    {
        return trap;
    }

    public int getFireStone()
    {
        return fireStone;
    }

    public int getBlindDrug()
    {
        return blindDrug;
    }

    public int getTeleportation()
    {
        return teleportation;
    }

    public int getStumblingBlock()
    {
        return stumblingBlock;
    }

    public int getThunderstormStone()
    {
        return thunderstormStone;
    }

    public int getJewelThief()//新增
    {
        return jewelThief;
    }

    public int getJewel()//新增
    {
        return jewel;
    }

    public int getHerb()
    {
        return herb;
    }
    public void changeFireStone(int num)
    {
        if(fireStone + num < 0)
        {
            return;
            //没有打火石
        }
        else
        {
            fireStone += num;
            fireStoneText.text = fireStone.ToString();
        }
    }

    public void changeFood(int num)
    {
        //Debug.Log(menuControl.num);
        if (isInMenu("food", menuControl) != -1)
        {
            Debug.Log("yopucuo");
            food += num;
            toolMenuControl.updateNum(isInMenu("food", menuControl), food);
            if (food == 0)
            {
                Debug.Log("food=0");
                deleteMenu("food", menuControl);
            }
        }
        else if (menuControl.num < 5)
        {
            //Debug.Log(menuControl.num);
            menuControl.num++;
            //Debug.Log(menuControl.num);
            food += num;
            addMenu("food", menuControl, food);
            //Debug.Log(menuControl.num);
            toolMenuControl.updateNum(isInMenu("food", menuControl), food);
            //Debug.Log(menuControl.num);
            toolMenuControl.addPicture("food", isInMenu("food", menuControl));
            //Debug.Log(menuControl.num);
        }
        else
        {
            //道具已满
        }
    }

    public void changeTrap(int num)
    {
        if (isInMenu("trap", menuControl) != -1)
        {
            trap += num;
            if (trap == 0)
            {
                deleteMenu("trap", menuControl);
            }
        }
        else if (menuControl.num < 5)
        {
            menuControl.num++;
            trap += num;
            addMenu("trap", menuControl,num);
            
        }
        else
        {
            //道具已满
        }
    }

    public void changeOriginStone(int num)
    {
        if (isInMenu("originStone", menuControl) != -1)
        {
            Debug.Log("yopucuo");
            originStone += num;
            toolMenuControl.updateNum(isInMenu("originStone", menuControl), originStone);
            if (originStone == 0)
            {
                Debug.Log("originStone=0");
                deleteMenu("originStone", menuControl);
            }
        }
        else if (menuControl.num < 5)
        {
            //Debug.Log(menuControl.num);
            menuControl.num++;
            //Debug.Log(menuControl.num);
            originStone += num;
            addMenu("originStone", menuControl, originStone);
            //Debug.Log(menuControl.num);
            toolMenuControl.updateNum(isInMenu("originStone", menuControl), originStone);
            //Debug.Log(menuControl.num);
            toolMenuControl.addPicture("originStone", isInMenu("originStone", menuControl));
            //Debug.Log(menuControl.num);
        }
        else
        {
            //道具已满
        }
    }

    public void changeMoonStone(int num)
    {
        if (isInMenu("moonStone", menuControl) != -1)
        {
            Debug.Log("yopucuo");
            moonStone += num;
            toolMenuControl.updateNum(isInMenu("moonStone", menuControl), moonStone);
            if (moonStone == 0)
            {
                Debug.Log("moonStone=0");
                deleteMenu("moonStone", menuControl);
            }
        }
        else if (menuControl.num < 5)
        {
            //Debug.Log(menuControl.num);
            menuControl.num++;
            //Debug.Log(menuControl.num);
            moonStone += num;
            addMenu("moonStone", menuControl, moonStone);
            //Debug.Log(menuControl.num);
            toolMenuControl.updateNum(isInMenu("moonStone", menuControl), moonStone);
            //Debug.Log(menuControl.num);
            toolMenuControl.addPicture("moonStone", isInMenu("moonStone", menuControl));
            //Debug.Log(menuControl.num);
        }
        else
        {
            //道具已满
        }
    }

    public void changeStumblingBolack(int num)
    {
        if (isInMenu("stumblingBlock", menuControl) != -1)
        {
            Debug.Log("yopucuo");
            stumblingBlock += num;
            toolMenuControl.updateNum(isInMenu("stumblingBlock", menuControl), stumblingBlock);
            if (stumblingBlock == 0)
            {
                Debug.Log("stumblingBlock=0");
                deleteMenu("stumblingBlock", menuControl);
            }
        }
        else if (menuControl.num < 5)
        {
            //Debug.Log(menuControl.num);
            menuControl.num++;
            //Debug.Log(menuControl.num);
            stumblingBlock += num;
            addMenu("stumblingBlock", menuControl, stumblingBlock);
            //Debug.Log(menuControl.num);
            toolMenuControl.updateNum(isInMenu("stumblingBlock", menuControl), stumblingBlock);
            //Debug.Log(menuControl.num);
            toolMenuControl.addPicture("stumblingBlock", isInMenu("stumblingBlock", menuControl));
            //Debug.Log(menuControl.num);
        }
        else
        {
            //道具已满
        }
    }

    public void changeFixPotion(int num)
    {
        if (isInMenu("fixPotion", menuControl) != -1)
        {
            Debug.Log("yopucuo");
            fixPotion += num;
            toolMenuControl.updateNum(isInMenu("fixPotion", menuControl), fixPotion);
            if (fixPotion == 0)
            {
                Debug.Log("fixPotion=0");
                deleteMenu("fixPotion", menuControl);
            }
        }
        else if (menuControl.num < 5)
        {
            //Debug.Log(menuControl.num);
            menuControl.num++;
            //Debug.Log(menuControl.num);
            fixPotion += num;
            addMenu("fixPotion", menuControl, fixPotion);
            //Debug.Log(menuControl.num);
            toolMenuControl.updateNum(isInMenu("fixPotion", menuControl), fixPotion);
            //Debug.Log(menuControl.num);
            toolMenuControl.addPicture("fixPotion", isInMenu("fixPotion", menuControl));
            //Debug.Log(menuControl.num);
        }
        else
        {
            //道具已满
        }
    }

    public void changeBlindDrug(int num)
    {
        if (isInMenu("blindDrug", menuControl) != -1)
        {
            blindDrug += num;
            if (blindDrug == 0)
            {
                deleteMenu("blindDrug", menuControl);
            }
        }
        else if (menuControl.num < 5)
        {
            Debug.Log("hahaha");
            menuControl.num++;
            blindDrug += num;
            addMenu("blindDrug", menuControl,num);
            toolMenuControl.updateNum(isInMenu("blindDrug", menuControl), blindDrug);
            toolMenuControl.addPicture("blindDrug", isInMenu("blindDrug", menuControl));
        }
        else
        {
            //道具已满
        }
    }

    public void changeTeleportation(int num)
    {
        if (isInMenu("teleportation", menuControl) != -1)
        {
            Debug.Log("yopucuo");
            teleportation += num;
            toolMenuControl.updateNum(isInMenu("teleportation", menuControl), teleportation);
            if (teleportation == 0)
            {
                Debug.Log("teleportation=0");
                deleteMenu("teleportation", menuControl);
            }
        }
        else if (menuControl.num < 5)
        {
            //Debug.Log(menuControl.num);
            menuControl.num++;
            //Debug.Log(menuControl.num);
            teleportation += num;
            addMenu("teleportation", menuControl, teleportation);
            //Debug.Log(menuControl.num);
            toolMenuControl.updateNum(isInMenu("teleportation", menuControl), teleportation);
            //Debug.Log(menuControl.num);
            toolMenuControl.addPicture("teleportation", isInMenu("teleportation", menuControl));
            //Debug.Log(menuControl.num);
        }
        else
        {
            //道具已满
        }
    }

    public void changeStumblingBlock(int num)
    {
        if (isInMenu("stumblingBlock", menuControl) != -1)
        {
            Debug.Log("yopucuo");
            stumblingBlock += num;
            toolMenuControl.updateNum(isInMenu("stumblingBlock", menuControl), stumblingBlock);
            if (stumblingBlock == 0)
            {
                Debug.Log("stumblingBlock=0");
                deleteMenu("stumblingBlock", menuControl);
            }
        }
        else if (menuControl.num < 5)
        {
            //Debug.Log(menuControl.num);
            menuControl.num++;
            //Debug.Log(menuControl.num);
            stumblingBlock += num;
            addMenu("stumblingBlock", menuControl, stumblingBlock);
            //Debug.Log(menuControl.num);
            toolMenuControl.updateNum(isInMenu("stumblingBlock", menuControl), stumblingBlock);
            //Debug.Log(menuControl.num);
            toolMenuControl.addPicture("stumblingBlock", isInMenu("stumblingBlock", menuControl));
            //Debug.Log(menuControl.num);
        }
        else
        {
            //道具已满
        }
    }

    public void changeThunderstormStone(int num)
    {
        if (isInMenu("thunderstormStone", menuControl) != -1)
        {
            Debug.Log("yopucuo");
            thunderstormStone += num;
            toolMenuControl.updateNum(isInMenu("thunderstormStone", menuControl), thunderstormStone);
            if (thunderstormStone == 0)
            {
                Debug.Log("thunderstormStone=0");
                deleteMenu("thunderstormStone", menuControl);
            }
        }
        else if (menuControl.num < 5)
        {
            //Debug.Log(menuControl.num);
            menuControl.num++;
            //Debug.Log(menuControl.num);
            thunderstormStone += num;
            addMenu("thunderstormStone", menuControl, thunderstormStone);
            //Debug.Log(menuControl.num);
            toolMenuControl.updateNum(isInMenu("thunderstormStone", menuControl), thunderstormStone);
            //Debug.Log(menuControl.num);
            toolMenuControl.addPicture("thunderstormStone", isInMenu("thunderstormStone", menuControl));
            //Debug.Log(menuControl.num);
        }
        else
        {
            //道具已满
        }
    }

    public void changeJewelThief(int num)//新增
    {
        if (isInMenu("jewelThief", menuControl) != -1)
        {
            Debug.Log("yopucuo");
            jewelThief += num;
            toolMenuControl.updateNum(isInMenu("jewelThief", menuControl), jewelThief);
            if (jewelThief == 0)
            {
                Debug.Log("jewelThief=0");
                deleteMenu("jewelThief", menuControl);
            }
        }
        else if (menuControl.num < 5)
        {
            //Debug.Log(menuControl.num);
            menuControl.num++;
            //Debug.Log(menuControl.num);
            jewelThief += num;
            addMenu("jewelThief", menuControl, jewelThief);
            //Debug.Log(menuControl.num);
            toolMenuControl.updateNum(isInMenu("jewelThief", menuControl), jewelThief);
            //Debug.Log(menuControl.num);
            toolMenuControl.addPicture("jewelThief", isInMenu("jewelThief", menuControl));
            //Debug.Log(menuControl.num);
        }
        else
        {
            //道具已满
        }
    }


    public void changeHerb(int num)
    {
        if (isInMenu("herb", menuControl) != -1)
        {
            Debug.Log("yopucuo");
            herb += num;
            toolMenuControl.updateNum(isInMenu("herb", menuControl), herb);
            if (herb == 0)
            {
                Debug.Log("herb=0");
                deleteMenu("herb", menuControl);
            }
        }
        else if (menuControl.num < 5)
        {
            //Debug.Log(menuControl.num);
            menuControl.num++;
            //Debug.Log(menuControl.num);
            herb += num;
            addMenu("herb", menuControl, herb);
            //Debug.Log(menuControl.num);
            toolMenuControl.updateNum(isInMenu("herb", menuControl), herb);
            //Debug.Log(menuControl.num);
            toolMenuControl.addPicture("herb", isInMenu("stumblingBlock", menuControl));
            //Debug.Log(menuControl.num);
        }
        else
        {
            //道具已满
        }
    }


    public int isInMenu(string s , MenuControl menuControl)
    {
        for(int i = 0;i < 5; i++)
        {
            if(menuControl.toolMenu[i].name == s)
            {
                return menuControl.toolMenu[i].id;
            }
        }
        return -1;
    }

    public void addMenu(string s, MenuControl menuControl, int num)
    {
        for (int i = 0; i < 5; i++)
        {
            if (menuControl.toolMenu[i].num == 0)
            {
                menuControl.toolMenu[i].name = s;
                menuControl.toolMenu[i].num = num;
                //menuControl.num++;
                //添加道具图标
                break;
            }
        }
    }

    public void deleteMenu(string s, MenuControl menuControl)
    {
        int i;
        for  (i = 0; i < 5; i++)
        {
            if (menuControl.toolMenu[i].name == s)
            {
                menuControl.toolMenu[i].num = 0;
                menuControl.toolMenu[i].name = "None";
                menuControl.num--;
                break;
            }
        }
        //将本地数量改为0
        if(s == "food")
        {
            food = 0;
        }
        else if(s == "blindDrug")
        {
            blindDrug = 0;
        }

        //换回透明图片
        int id = i+1;
        string path = "Canvas/ToolsBar/Tool_" + id.ToString();
        //Debug.Log(path);
        Image image = GameObject.Find(path + "/Image").GetComponent<Image>();
        //Debug.Log(name + "/Image");
        Sprite loadImage = Resources.Load("Picture/transparent", typeof(Sprite)) as Sprite;
        image.sprite = loadImage;

        toolimgcontrol = GameObject.Find(path + "/Image").GetComponent<toolImageControl>();
        toolimgcontrol.name = "None";

        //左上角数字变为0
        Text text = GameObject.Find(path + "/Tool_" + id.ToString() + "_amount").GetComponent<Text>();
        text.text = "0";
    }
}
