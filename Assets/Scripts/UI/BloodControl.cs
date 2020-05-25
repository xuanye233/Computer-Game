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
        if (GameObject.Find("Player(Clone)") == null)
        {
            characterStatus = GameObject.Find("Player").GetComponent<CharacterStatus>();
        }
        else
        {
            characterStatus = GameObject.Find("Player(Clone)").GetComponent<CharacterStatus>();
        }
        //do
        //{
        //    StartCoroutine(Wait(5.0f));
        //} while (!GameObject.Find("Player(Clone)"));
        //bloodSloder = FindObjectOfType<Slider>();
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
            bloodSloder.fillRect.transform.GetComponent<Image>().color = new Color(98f / 255f, 197f / 255f, 179f / 255f);
        }
        else if(bloodSloder.value >= 30)
        {
            bloodSloder.fillRect.transform.GetComponent<Image>().color = new Color(197f / 255f, 194f / 255f, 98f / 255f);
        }
        else
        {
            bloodSloder.fillRect.transform.GetComponent<Image>().color = new Color(197f / 255f, 114f / 255f, 98f / 255f);
        }
    }

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //等待之后执行的动作
    }
}
