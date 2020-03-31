using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackFadeInOut : MonoBehaviour
{
    public float fadeSpeed = 1.5f;
    private RawImage rawImage;
    bool toBlack;
    bool toClear;
    void Awake()
    {
        rawImage = GetComponent<RawImage>();
        rawImage.color = Color.clear;
        toBlack = false;
        toClear = true;
    }
    
    void Update()
    {
        if (toBlack)
        {
            fadeToBlack();
        }
        if(toClear)
        {
            fadeToClear();
        }
    }

    private void fadeToClear()
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.clear, fadeSpeed * Time.deltaTime);
        if (rawImage.color.a < 0.05f)
        {
            rawImage.color = Color.clear;
            rawImage.enabled = false;
            toClear = false;
        }
    }

    private void fadeToBlack()
    {
        rawImage.enabled = true;
        rawImage.color = Color.Lerp(rawImage.color, Color.black, fadeSpeed * Time.deltaTime);
        if (rawImage.color.a > 0.95f)
        {
            toBlack = false;
            toClear = true;
        }
    }

    public void fallScreenEffect()
    {
        toBlack = true;
    }
}
