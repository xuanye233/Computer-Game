using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerControl : MonoBehaviour
{
    [SerializeField]
    public Text timeText;
    private int hour0;
    private int minute0;
    private int second0;

    private int hour;
    private int minute;
    private int second;

    private int deltahour;
    private int deltaminute;
    private int deltasecond;

    private void Start()
    {
        hour0 = DateTime.Now.Hour;
        minute0 = DateTime.Now.Minute;
        second0 = DateTime.Now.Second;
    }

    void FixedUpdate()
    {
        hour = DateTime.Now.Hour;
        minute = DateTime.Now.Minute;
        second = DateTime.Now.Second;

        deltahour = ((3600 * (hour - hour0)) + (60 * (minute - minute0)) + second - second0) / 3600;
        deltaminute = (((3600 * (hour - hour0)) + (60 * (minute - minute0)) + second - second0) - deltahour * 3600) / 60;
        deltasecond = ((3600 * (hour - hour0)) + (60 * (minute - minute0)) + second - second0) % 60;

        //timeText.text = string.Format("{0:D2}:{0:D2}:{0:D2}", deltahour.ToString(), deltaminute.ToString(), deltasecond.ToString());
        //timeText.text = deltaminute.ToString() + ":" + deltasecond.ToString();
        string str = string.Format("{0:D2}:{1:D2}:{2:D2}", deltahour, deltaminute, deltasecond);
        timeText.text = str;
        //Debug.Log("hour" + deltahour.ToString());
        //Debug.Log("minute" + deltaminute.ToString());
        //Debug.Log("second" + deltasecond.ToString());
        //Debug.Log(str);
    }
}
