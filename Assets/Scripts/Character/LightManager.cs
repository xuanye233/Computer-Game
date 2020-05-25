using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public Light[] lights;
    //public Transform curPlayer2;
    public GameObject curPlayer;
    public float maxIntesnity;
    public float totalLight;

    // Start is called before the first frame update
    void Start()
    {
        //lights = GameObject.FindGameObjectsWithTag("PointLight");
        //curPlayer2 = transform.Find("Player(Clone)");
        curPlayer = GameObject.Find("Player(Clone)");
        maxIntesnity = 0.01f;
        UpdateLightIntensity();        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLightIntensity();
    }

    void UpdateLightIntensity()
    {
        float updateResult = 0;
        for (int i = 0; i < lights.Length; i++)
        {
            if (lights[i].range > 0)
            {
                float dis;
                dis = (lights[i].transform.position - curPlayer.transform.position).sqrMagnitude;
                updateResult += lights[i].intensity / dis;
            }

        }
        if (updateResult > maxIntesnity)
        {
            updateResult = 1.0f;
        }
        else
        {
            updateResult /= maxIntesnity;
        }
        totalLight = updateResult;
    }
}
