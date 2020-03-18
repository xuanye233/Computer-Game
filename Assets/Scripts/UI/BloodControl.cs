using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodControl : MonoBehaviour
{
    public Slider bloodSloder;
    //Player player;
    CharacterStatus characterStatus;


    
    void Start()
    {
        Debug.Log(!GameObject.Find("Player(Clone)")==null);
        do
        {
            StartCoroutine(Wait(5.0f));
        } while (!GameObject.Find("Player(Clone)"));
        characterStatus = GameObject.Find("Player(Clone)").GetComponent<CharacterStatus>();
        bloodSloder = FindObjectOfType<Slider>();
        //player = GameObject.Find("Player").GetComponent<Player>();
        bloodSloder.value = characterStatus.GetHealth();
    }

    
    void Update()
    {
        bloodSloder.value = characterStatus.GetHealth();
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

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //等待之后执行的动作
    }
}
