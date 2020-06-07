using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class LoseSight : MonoBehaviourPunCallbacks
{
    public float fadeSpeed = 5f;
    private RawImage rawImage;
    bool toBlack;
    bool toClear;
    bool stay;
    private int stayTime;

    void Awake()
    {
        rawImage = GetComponent<RawImage>();
        rawImage.color = Color.clear;
        toBlack = false;
        toClear = true;
        stay = false;
        stayTime = 0;
    }

    void Update()
    {
        if (toBlack)
        {
            getBlack();
        }
        if(stay)
        {
            getStay();
        }
        if (toClear)
        {
            getClear();
        }
    }

    private void getClear()
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.clear, fadeSpeed * Time.deltaTime);
        if (rawImage.color.a < 0.05f)
        {
            rawImage.color = Color.clear;
            rawImage.enabled = false;
            toClear = false;
        }
    }

    private void getBlack()
    {
        rawImage.enabled = true;
        rawImage.color = Color.Lerp(rawImage.color, Color.black, fadeSpeed * Time.deltaTime);
        if (rawImage.color.a > 0.95f)
        {
            toBlack = false;
            stay = true;
            toClear = true;
        }
    }

    private void getStay()
    {
        stayTime++;
        if (stayTime == 3000)//默认FPS=60?
        {
            stayTime = 0;
            stay = false;
            toClear = true;
        }
    }

    public void beBlind()
    {
        toBlack = true;
        stay = true;
    }
}
