using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireControlor : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.P))
        {
            var main = ps.main;
            main.startLifetime = 0;
        }
        if (Input.GetKey(KeyCode.O))
        {
            var main = ps.main;
            main.startLifetime = 2;
        }*/
    }
    public void getFireOn()
    {
        var main = ps.main;
        main.startLifetime = 2;//点燃
    }
    public void getFireDown()
    {
        var main = ps.main;
        main.startLifetime = 0;//熄灭
    }
}
