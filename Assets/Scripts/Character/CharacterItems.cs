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
    List<int> key;

    int jewelThief;//jewelthief的数量
    int jewel;//后续改成list，现在先用单个测试

    void Start()
    {
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

        jewelThief = 0;
        jewel = 0;
        key = new List<int>();
        menuControl = new MenuControl();
        for(int i = 1;i <= 5; i++)
        {
            Item item = new Item(i);
            menuControl.toolMenu.Add(item);
        }
    }

    public int getOriginStone()
    {
        return originStone;
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
    public void changeFireStone(int num)
    {
        if(isInMenu("fireStone", menuControl) != -1)
        {
            fireStone += num;
            if(fireStone == 0)
            {
                deleteMenu("fireStone", menuControl);
            }
            //toolMenuControl.updateNum()
        }
        else if(menuControl.num < 5)
        {
            menuControl.num++;
            fireStone += num;
            addMenu("fireStone", menuControl, num);
        }
        else
        {
            //道具已满
        }
    }

    public void changeFood(int num)
    {
        if (isInMenu("food", menuControl) != -1)
        {
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
            menuControl.num++;
            food += num;
            addMenu("food", menuControl, food);
            toolMenuControl.updateNum(isInMenu("food", menuControl), food);
            toolMenuControl.addPicture("food", isInMenu("food", menuControl));
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
            originStone += num;
            if (originStone == 0)
            {
                deleteMenu("originStone", menuControl);
            }
        }
        else if (menuControl.num < 5)
        {
            menuControl.num++;
            originStone += num;
            addMenu("originStone", menuControl,num);
        }
        else
        {
            //道具已满
        }
    }

    public void changeStumblingBolack(int num)
    {
        if (isInMenu("stumblingBolack", menuControl) != -1)
        {
            stumblingBolack += num;
            if (stumblingBolack == 0)
            {
                deleteMenu("stumblingBolack", menuControl);
            }
        }
        else if (menuControl.num < 5)
        {
            menuControl.num++;
            stumblingBolack += num;
            addMenu("stumblingBolack", menuControl,num);
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
            fixPotion += num;
            if (fixPotion == 0)
            {
                deleteMenu("fixPotion", menuControl);
            }
        }
        else if (menuControl.num < 5)
        {
            menuControl.num++;
            fixPotion += num;
            addMenu("fixPotion", menuControl,num);
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
            menuControl.num++;
            blindDrug += num;
            addMenu("blindDrug", menuControl,num);
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
            teleportation += num;
            if (teleportation == 0)
            {
                deleteMenu("teleportation", menuControl);
            }
        }
        else if (menuControl.num < 5)
        {
            menuControl.num++;
            teleportation += num;
            addMenu("teleportation", menuControl,num);
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
            stumblingBlock += num;
            if (stumblingBlock == 0)
            {
                deleteMenu("stumblingBlock", menuControl);
            }
        }
        else if (menuControl.num < 5)
        {
            menuControl.num++;
            stumblingBlock += num;
            addMenu("stumblingBlock", menuControl,num);
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
            thunderstormStone += num;
            if (thunderstormStone == 0)
            {
                deleteMenu("thunderstormStone", menuControl);
            }
        }
        else if (menuControl.num < 5)
        {
            menuControl.num++;
            thunderstormStone += num;
            addMenu("thunderstormStone", menuControl,num);
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
            jewelThief += num;
            if (jewelThief == 0)
            {
                deleteMenu("jewelThief", menuControl);
            }
        }
        else if (menuControl.num < 5)
        {
            menuControl.num++;
            jewelThief += num;
            addMenu("jewelThief", menuControl,num);
        }
        else
        {
            //道具已满
        }
    }

    public void changeJewel(int num)//新增
    {
        if (isInMenu("jewel", menuControl) != -1)
        {
            jewel += num;
            if (jewel == 0)
            {
                deleteMenu("jewel", menuControl);
            }
        }
        else if (menuControl.num < 5)
        {
            menuControl.num++;
            jewel += num;
            addMenu("jewel", menuControl,num);
        }
        else
        {
            //道具已满
        }
    }

    public void addKey(int index)
    {
        key.Add(index);
    }


    public List<int> getKeys()
    {
        return key;
    }

    public void LostKeys()
    {
        //钥匙被偷了
        key.Clear();
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
                menuControl.num++;
                //添加道具图标
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
    }
}
