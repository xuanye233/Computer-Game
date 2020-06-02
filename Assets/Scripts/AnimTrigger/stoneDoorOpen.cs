using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneDoorOpen : MonoBehaviour
{
    private Animation animation;  //动画播放控制

    void Start()
    {
        animation = gameObject.GetComponent<Animation>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            animation.Play("Door_Open");
            Debug.Log("Player entered the door");
        }
    }
}
