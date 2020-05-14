using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ESC : MonoBehaviour
{
    [SerializeField]
    private GameObject EscPanel;
    bool isEsc;

    void Start()
    {
        EscPanel.SetActive(false);
        isEsc = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isEsc)
        {
            EscPanel.SetActive(true);
        }
    }
}
