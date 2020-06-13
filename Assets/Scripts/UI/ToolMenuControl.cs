
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolMenuControl : MonoBehaviour
{
    toolImageControl toolimgcontrol;
    public bool isQuit;
    [SerializeField]
    FireStoneControl fireStoneControl;
    [SerializeField]
    EDU_firestonecontrol eDU_Firestonecontrol;
    public List<Image> bgImages;

    private void Start()
    {
        isQuit = false;
        bgImages = new List<Image>();
        bgImages.Add(GameObject.Find("Canvas/ToolsBar/Tool_0_firestone").GetComponent<Image>());
        bgImages.Add(GameObject.Find("Canvas/ToolsBar/Tool_1").GetComponent<Image>());
        bgImages.Add(GameObject.Find("Canvas/ToolsBar/Tool_2").GetComponent<Image>());
        bgImages.Add(GameObject.Find("Canvas/ToolsBar/Tool_3").GetComponent<Image>());
        bgImages.Add(GameObject.Find("Canvas/ToolsBar/Tool_4").GetComponent<Image>());
        bgImages.Add(GameObject.Find("Canvas/ToolsBar/Tool_5").GetComponent<Image>());
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Sprite loadImage = Resources.Load("Picture/Tool_selected", typeof(Sprite)) as Sprite;
            bgImages[1].sprite = loadImage;
            Debug.Log("anle1");
            toolimgcontrol = GameObject.Find("Canvas/ToolsBar/Tool_1/Image").GetComponent<toolImageControl>();
            toolimgcontrol.onClick();
            //transparent();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Sprite loadImage = Resources.Load("Picture/Tool_selected", typeof(Sprite)) as Sprite;
            bgImages[2].sprite = loadImage;
            toolimgcontrol = GameObject.Find("Canvas/ToolsBar/Tool_2/Image").GetComponent<toolImageControl>();
            toolimgcontrol.onClick();
            //transparent();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Sprite loadImage = Resources.Load("Picture/Tool_selected", typeof(Sprite)) as Sprite;
            bgImages[3].sprite = loadImage;
            toolimgcontrol = GameObject.Find("Canvas/ToolsBar/Tool_3/Image").GetComponent<toolImageControl>();
            toolimgcontrol.onClick();
            //transparent();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Sprite loadImage = Resources.Load("Picture/Tool_selected", typeof(Sprite)) as Sprite;
            bgImages[4].sprite = loadImage;
            toolimgcontrol = GameObject.Find("Canvas/ToolsBar/Tool_4/Image").GetComponent<toolImageControl>();
            toolimgcontrol.onClick();
            //transparent();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Sprite loadImage = Resources.Load("Picture/Tool_selected", typeof(Sprite)) as Sprite;
            bgImages[5].sprite = loadImage;
            toolimgcontrol = GameObject.Find("Canvas/ToolsBar/Tool_5/Image").GetComponent<toolImageControl>();
            toolimgcontrol.onClick();
            //transparent();
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            if(GameObject.Find("Cellar") == null)
            {
                fireStoneControl.onClick();
            }
            else
            {
                eDU_Firestonecontrol.onClick();
            }
            
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

    public void transparent()
    {
        //把图片修改回原来的背景图片
        for(int i = 0;i <= 5; i++)
        {
            Sprite loadImage = Resources.Load("Picture/Tool_backcolor", typeof(Sprite)) as Sprite;
            bgImages[i].sprite = loadImage;
        }
    }
}
