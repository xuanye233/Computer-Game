﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Killfeed : MonoBehaviour
{
    public Text K1;
    public Text K2;
    public Text K3;
    public int textcount;
    // Start is called before the first frame update
    void Start()
    {
        K1 = GameObject.Find("Canvas/Killfeed/K1/Text").GetComponent<Text>();
        K2 = GameObject.Find("Canvas/Killfeed/K2/Text").GetComponent<Text>();
        K3 = GameObject.Find("Canvas/Killfeed/K3/Text").GetComponent<Text>();
        //textcount = 1;
        K1.text = "";
        K2.text = "";
        K3.text = "";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //text.GetComponent<Text>().text += "11222\n";
        //SliderText.text += "ReStart\n";
        //Vector3 kk = newVector3(textssliders.transform.localPosition.x, textssliders.transform.localPosition.y + texts.GetComponent().sizeDelta.y, 0f);
        /*SliderText.text += "ReStart\n";
        SliderText.transform.localPosition = new Vector3(SliderText.transform.localPosition.x, SliderText.transform.localPosition.y + (float) 0.5, 0f);*/
        
        //test_Slider();
    }

    void test_Slider()
    {
        /*if (textcount < 10)
        {
            SliderText.text += textcount.ToString() + "RE:End";
            textcount++;
        }*/
        /*else
        {
            SliderText.text += textcount.ToString() + "RE:End";
            textcount++;
            SliderText.transform.localPosition = new Vector3(SliderText.transform.localPosition.x, SliderText.transform.localPosition.y + (float)1, 0f);
        }*/

    }
}
