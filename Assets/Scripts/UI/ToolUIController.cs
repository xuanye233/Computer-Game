using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolUIController : MonoBehaviour
{
    //Player player;
    CharacterItems characterItems;
    Text foodNumText;
    Text trapNumText;
    Text fireStoneNumText;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player").GetComponent<Player>();
        characterItems = GameObject.Find("Player/Player").GetComponent<CharacterItems>();
        foodNumText = GameObject.Find("Canvas/ToolList/Food/FoodNum").GetComponent<Text>();
        trapNumText = GameObject.Find("Canvas/ToolList/Trap/TrapNum").GetComponent<Text>();
        fireStoneNumText = GameObject.Find("Canvas/ToolList/FireStone/FireStoneNum").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        upDateTool();
    }

    void upDateTool()
    {
        //Debug.Log(foodNum);
        foodNumText.text = "X " + characterItems.getFood().ToString();
        trapNumText.text = "X " + characterItems.getTrap().ToString();
        fireStoneNumText.text = "X " + characterItems.getFireStone().ToString();
    }

}
