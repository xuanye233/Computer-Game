using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolUIController : MonoBehaviour
{
    Player player;
    Text foodNumText;
    Text trapNumText;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        foodNumText = GameObject.Find("Canvas/ToolList/Food/FoodNum").GetComponent<Text>();
        trapNumText = GameObject.Find("Canvas/ToolList/Trap/TrapNum").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        upDateTool();
    }

    void upDateTool()
    {
        //Debug.Log(foodNum);
        foodNumText.text = "X " + player.tool.food.ToString();
        trapNumText.text = "X " + player.tool.trap.ToString();
    }

}
