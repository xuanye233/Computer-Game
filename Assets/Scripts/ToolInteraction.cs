using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ToolInteraction : MonoBehaviour
{
    Player player;
    Text noFoodText;
    Text noTrapText;
    float duration = 5.0f;
    Boolean isTrapClick;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        noFoodText = GameObject.Find("Canvas/TipsList/NoFoodText").GetComponent<Text>();
        noFoodText.gameObject.SetActive(false);
        noTrapText = GameObject.Find("Canvas/TipsList/NoTrapText").GetComponent<Text>();
        noTrapText.gameObject.SetActive(false);
        isTrapClick = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(isTrapClick && Input.GetMouseButtonDown(0) && player.tool.trap > 0)
        {
            trapEvent();
        }
        else if(isTrapClick && Input.GetMouseButtonDown(0))
        {
            showNoTrap();
        }
    }

    public void foodClick()//food interaction
    {
        //Debug.Log("Sssss");
        if (player.tool.food == 0)//have no food available
        {
            noFoodText.gameObject.SetActive(true);//display the tips
            Debug.Log("nofood");

            //StartCoroutine(wait1());
            StartCoroutine(noFoodWait());//disappear smothly
            
            //double currentTime = 0;

            ////Debug.Log("current" + currentTime);
            //Color newColor = foodText.material.color;
            //float proportion;

            //while (currentTime <= duration)
            //{

            //    proportion = ((float)currentTime / duration);
            //    newColor.a = Mathf.Lerp(1, 0, proportion);
            //    foodText.material.color = newColor;

            //    //if (Time.time > duration)
            //    //{
            //    //    foodText.gameObject.SetActive(false);

            //    //}
            //    currentTime += Convert.ToDouble(Time.deltaTime.ToString());
            //    Debug.Log("current" + currentTime);
            //}
            //foodText.gameObject.SetActive(false);

        }
        else//have enough food
        {
            player.tool.food--;
            if (player.blood <= 90)//not reach the maxmum
            {
                player.blood += 10;
            }
            else//reach the maxmum
            {
                player.blood = 100;
            }

            //player
        }

    }

    public void trapClick()
    {
        
        if(player.tool.trap == 0)
        {
            //没有陷阱 需要弹窗
            showNoTrap();
        }
        else
        {
            isTrapClick = true;
        }
    }

    public void trapEvent()
    {
        Debug.Log("trapevent");
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit,float.MaxValue))
        {
            GameObject newTrap = (GameObject)GameObject.Instantiate(Resources.Load("SM_Prop_Bricks_04"));
            //create the object in the scene
            newTrap.transform.position = hit.point;
            isTrapClick = false;
            //reset the flag
            //Debug.Log(hit.point);
            //Debug.DrawRay(hit.point, hit.normal, Color.green);

            //update the num of the traps
            player.tool.trap--;
        }
        
    }

    public void showNoTrap()
    {
        noTrapText.gameObject.SetActive(true);//display the tips
        Debug.Log("notrap");

        //StartCoroutine(wait1());
        StartCoroutine(noTrapWait());//disappear smothly
    }

    IEnumerator noFoodWait() //fade function
    {
        //yield return new WaitForSeconds(5);
        noFoodText.CrossFadeAlpha(1, 1f, false);
        yield return new WaitForSeconds(1);
        noFoodText.CrossFadeAlpha(0, 1f, false);
    }

    IEnumerator noTrapWait() //fade function
    {
        //yield return new WaitForSeconds(5);
        noTrapText.CrossFadeAlpha(1, 1f, false);
        yield return new WaitForSeconds(1);
        noTrapText.CrossFadeAlpha(0, 1f, false);
    }
}
