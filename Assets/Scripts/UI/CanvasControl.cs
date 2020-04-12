﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour
{
    [SerializeField]
    GameObject bagPanel;

    [SerializeField]
    Text noFoodText;
    [SerializeField]
    Text noTrapText;
    [SerializeField]
    Text noFireStoneText;
    [SerializeField]
    GameObject bagButton;
    private void Awake()
    {
        noFoodText.gameObject.SetActive(false);
        noTrapText.gameObject.SetActive(false);
        noFireStoneText.gameObject.SetActive(false);
        //其他道具的text还没加
        bagPanel.SetActive(false);
    }

    public void bagClick()
    {
        bagButton.SetActive(false);
        bagPanel.SetActive(true);
    }

    public void backClick()
    {
        bagPanel.SetActive(false);
        bagButton.SetActive(true);
    }

}
