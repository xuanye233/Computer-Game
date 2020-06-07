using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SightControl : MonoBehaviour
{
    public Slider sightSlider;
    public GameObject lightManager;
    void Start()
    {
        sightSlider.value = lightManager.GetComponent<LightManager>().totalLight;
    }

    void Update()
    {
        sightSlider.value = lightManager.GetComponent<LightManager>().totalLight;
        changeSliderColor();
    }

    private void changeSliderColor()
    {
        if (sightSlider.value >= 0.7)
        {
            sightSlider.fillRect.transform.GetComponent<Image>().color = new Color(255f / 255f, 235f / 255f, 167f / 255f);
        }
        else if (sightSlider.value >= 0.3)
        {
            sightSlider.fillRect.transform.GetComponent<Image>().color = new Color(255f / 255f, 194f / 255f, 167f / 255f);
        }
        else
        {
            sightSlider.fillRect.transform.GetComponent<Image>().color = new Color(197f / 255f, 114f / 255f, 98f / 255f);
        }
    }
}
