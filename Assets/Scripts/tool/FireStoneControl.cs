using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireStoneControl : MonoBehaviour
{
    public string name;
    [SerializeField]
    ToolMenuControl toolMenuControl;
    CharacterItems characterItems;

    [SerializeField]
    FireStone fireStone;

    [SerializeField]
    Text fireStoneText;


    private void Start()
    {
        name = "fireStone";
        //toolMenuControl = GameObject.Find("Canvas/ToolsBar").GetComponent<ToolMenuControl>();
        //characterItems = GameObject.Find("Player(Clone)").GetComponent<CharacterItems>();
        //Debug.Log("woshi"+ characterItems.getFireStone().ToString());
        fireStoneText.text = "5";
    }

    public void onClick()
    {
        Sprite loadImage = Resources.Load("Picture/Tool_selected", typeof(Sprite)) as Sprite;
        toolMenuControl.bgImages[0].sprite = loadImage;
        //Debug.Log(toolMenuControl.bgImages.Count);
        fireStone.onClicked();
    }

}
