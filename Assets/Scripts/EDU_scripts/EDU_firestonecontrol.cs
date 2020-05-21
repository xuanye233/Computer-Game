using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EDU_firestonecontrol : MonoBehaviour
{
    public string name;
    [SerializeField]
    ToolMenuControl toolMenuControl;
    CharacterItems characterItems;

    [SerializeField]
    EDU_fireStone fireStone;

    [SerializeField]
    Text fireStoneText;
    [SerializeField]
    EDU_process eDU_Process;


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
        Debug.Log("anle");
        fireStone.onClicked();
        eDU_Process.fireStoneEvent();
    }
}
