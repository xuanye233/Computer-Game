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
        characterItems = GameObject.Find("Player(Clone)").GetComponent<CharacterItems>();
        fireStoneText.text = characterItems.getFireStone().ToString();
    }

    public void onClick()
    {
        Debug.Log("anle");
        fireStone.onClicked();
    }

}
