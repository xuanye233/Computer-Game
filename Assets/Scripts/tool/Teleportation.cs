using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    // 互换位置
    Vector3 myPosition;
    Vector3 othersPosition;
    void Start()
    {

    }

    // Update is called once per frame
    void onClicked()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 5.0f)) //作用距离为5.0f
        {
            if (hit.transform)
            {
                if (hit.transform.GetComponent<CharacterStatus>())
                {
                    othersPosition = hit.transform.position;
                    myPosition = transform.position;
                    hit.transform.transform.position = myPosition;
                    transform.position = othersPosition;
                }
            }
        }
    }
}
