using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodControl : MonoBehaviour
{
    public Slider bloodSloder;
    Player player;

    void Start()
    {
        bloodSloder = FindObjectOfType<Slider>();
        player = GameObject.Find("Player").GetComponent<Player>();
        bloodSloder.value = player.blood;

    }

    
    void Update()
    {
        bloodSloder.value = player.blood;
        changeSliderColor();
    }
    
    private void changeSliderColor()//change the value due to the blood 
    {
        if(bloodSloder.value >= 70)
        {
            bloodSloder.fillRect.transform.GetComponent<Image>().color = Color.green;
        }
        else if(bloodSloder.value >= 30)
        {
            bloodSloder.fillRect.transform.GetComponent<Image>().color = Color.yellow;
        }
        else
        {
            bloodSloder.fillRect.transform.GetComponent<Image>().color = Color.red;
        }
    }
}
