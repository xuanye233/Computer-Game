using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject mainCamera;
    GameObject mapCamera;
    public Tool tool;
    public int blood = 50;

    public class Tool
    {
        public int food;
        public int trap;
        public int fireStone;
        public int key;
        
        public Tool()
        {
            food = 5;
            trap = 5;
            fireStone = 0;
            key = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("MainCamera");
        mapCamera = GameObject.Find("MapCamera");
        tool = new Tool();
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMove();
    }

    public void CharacterMove()//move the character and cemara
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Transform>().Translate(new Vector3(0, 0, -1));
            mainCamera.transform.Translate(new Vector3(0, 0, 1));
            mapCamera.transform.Translate(new Vector3(0, 1, 0));

            //Debug.Log("W");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<Transform>().Translate(new Vector3(0, 0, 1));
            mainCamera.transform.Translate(new Vector3(0, 0, -1));
            mapCamera.transform.Translate(new Vector3(0, -1, 0));
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<Transform>().Translate(new Vector3(1, 0, 0));
            mainCamera.transform.Translate(new Vector3(-1, 0, 0));
            mapCamera.transform.Translate(new Vector3(-1, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<Transform>().Translate(new Vector3(-1, 0, 0));
            mainCamera.transform.Translate(new Vector3(1, 0, 0));
            mapCamera.transform.Translate(new Vector3(1, 0, 0));
        }
    }
}
