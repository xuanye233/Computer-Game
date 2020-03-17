using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightControlor : MonoBehaviour
{
    // Start is called before the first frame update
    public Light pointLight;

    void Start()
    {
        pointLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.P))
        {
            pointLight.range --;
        }
        if (Input.GetKey(KeyCode.O))
        {
            pointLight.range ++;
        }*/
    }
    public void getLightOn()
    {
        pointLight.range = 7;//点亮
    }
    public void getLightDown()
    {
        pointLight.range = 0;//熄灭
    }
}
 