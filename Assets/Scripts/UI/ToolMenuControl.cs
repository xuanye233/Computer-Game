
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolMenuControl : MonoBehaviour
{
    toolImageControl toolimgcontrol;
    public bool isQuit;

    private void Start()
    {
        isQuit = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("anle1");
            toolimgcontrol = GameObject.Find("Canvas/ToolsBar/Tool_1/Image").GetComponent<toolImageControl>();
            toolimgcontrol.onClick();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            toolimgcontrol = GameObject.Find("Canvas/ToolsBar/Tool_2/Image").GetComponent<toolImageControl>();
            toolimgcontrol.onClick();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            toolimgcontrol = GameObject.Find("Canvas/ToolsBar/Tool_3/Image").GetComponent<toolImageControl>();
            toolimgcontrol.onClick();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            toolimgcontrol = GameObject.Find("Canvas/ToolsBar/Tool_4/Image").GetComponent<toolImageControl>();
            toolimgcontrol.onClick();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            toolimgcontrol = GameObject.Find("Canvas/ToolsBar/Tool_5/Image").GetComponent<toolImageControl>();
            toolimgcontrol.onClick();
        }
    }

    public void updateNum(int id,int num)
    {
        string path = "Canvas/ToolsBar/Tool_" + id.ToString();
        //Debug.Log(path + "/Tool_" + id.ToString() + "_amount");
        Debug.Log(path + "/Tool_" + id.ToString() + "_amount");
        Text text = GameObject.Find(path+ "/Tool_"+id.ToString()+"_amount").GetComponent<Text>();
        text.text = num.ToString();
        //Debug.Log(text.text);
    }

    public void addPicture(string name,int id)
    {
        string path = "Canvas/ToolsBar/Tool_" + id.ToString();
        Image image = GameObject.Find(path + "/Image").GetComponent<Image>();
        //Debug.Log(name + "/Image");
        Sprite loadImage = Resources.Load("Picture/" + name, typeof(Sprite)) as Sprite;
        image.sprite = loadImage;

        toolimgcontrol = GameObject.Find(path + "/Image").GetComponent<toolImageControl>();
        toolimgcontrol.name = name;
    }

    public void delete(int id)
    {
        string path = "Canvas/ToolsBar/Tool_" + id.ToString();
        Image image = GameObject.Find(path + "/Image").GetComponent<Image>();
        //Debug.Log(name + "/Image");
        Sprite loadImage = Resources.Load("Picture/transparent", typeof(Sprite)) as Sprite;
        image.sprite = loadImage;

        toolimgcontrol = GameObject.Find(path + "/Image").GetComponent<toolImageControl>();
        toolimgcontrol.name = "None";
    }

    public void pressQ()
    {
        isQuit = true;
        //Debug.Log(isQuit);
    }
}
