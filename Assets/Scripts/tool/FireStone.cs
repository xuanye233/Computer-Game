using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStone: MonoBehaviour
{
    CharacterItems characterItems;
    ToolInteraction toolInteraction;
    Transform fireStoneTransform;
    private void Start()
    {
        characterItems = GameObject.Find("Player(Clone)").GetComponent<CharacterItems>();
        toolInteraction = GameObject.Find("Canvas/ToolList").GetComponent<ToolInteraction>();
        fireStoneTransform = GameObject.Find("Canvas/ToolList/FireStone/FireStoneImage").GetComponent<Transform>();
    }

    public void onClicked()
    {
        
            //Debug.Log("fireStoneevent");
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 20.0f))
            {
                if (hit.transform.GetChild(0))
                {
                    if (hit.transform.GetChild(0).GetComponent<Light>())
                    {
                        //Debug.Log("yes");
                        hit.transform.GetChild(0).GetComponent<Light>().range = 7;
                        hit.transform.GetChild(1).gameObject.SetActive(true);
                    }
                }

            //Debug.Log(hit.transform.GetChild(0).name);
             toolInteraction.isFireStoneClick = false;
             fireStoneTransform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
             characterItems.changeFireStone(-1);
             }
    }
}
