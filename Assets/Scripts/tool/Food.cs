﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    CharacterItems characterItems;
    CharacterStatus characterStatus;
    //ToolInteraction toolInteraction;
    [SerializeField]
    Text noFoodText;

    private void Start()
    {
        characterItems = GameObject.Find("Player(Clone)").GetComponent<CharacterItems>();
        characterStatus = GameObject.Find("Player(Clone)").GetComponent<CharacterStatus>();
        //toolInteraction = GameObject.Find("Canvas/ToolList").GetComponent<ToolInteraction>();
        //noFoodText = GameObject.Find("Canvas/TipsList/NoFoodText").GetComponent<Text>();
        //noFoodText.gameObject.SetActive(false);
        //Debug.Log("setfalse");
    }

    public void onClicked()
    {
        
        //Debug.Log("Sssss");
        if (characterItems.getFood() == 0)//have no food available
        {
            noFoodText.gameObject.SetActive(true);
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
            characterItems.changeFood(-1);

            characterStatus.ChangeHealth(5);
        }
    }
    public IEnumerator noFoodWait() //fade function
    {
        //yield return new WaitForSeconds(5);
        noFoodText.CrossFadeAlpha(1, 1f, false);
        yield return new WaitForSeconds(1);
        noFoodText.CrossFadeAlpha(0, 1f, false);
    }

}

