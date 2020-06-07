using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterName : MonoBehaviour
{
    public GameObject targets;
    private GameObject sceneCamera;
    // Update is called once per frame
    void Update()
    {
        if (sceneCamera == null)
        {
            sceneCamera = GameObject.Find("Camera");
        }
        targets.transform.rotation = sceneCamera.transform.rotation;
    }
}
