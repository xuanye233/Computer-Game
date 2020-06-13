using System.Collections;
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

    static private GameObject success_ui;
    static private GameObject failure_ui;

    private void Awake()
    {
        //noFoodText.gameObject.SetActive(false);
        //noTrapText.gameObject.SetActive(false);
        //noFireStoneText.gameObject.SetActive(false);
        //其他道具的text还没加
        //bagPanel.SetActive(false);
    }

    private void Start()
    {
        success_ui = GameObject.Find("Canvas/SuccessUI");
        failure_ui = GameObject.Find("Canvas/FailureUI");
        success_ui.SetActive(false);
        failure_ui.SetActive(false);
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

    static public void showSuccess()
    {
        Debug.Log("showsuccess");

        //使successUI适应屏幕
        Transform scaleUI = success_ui.transform;
        float widthRate = UnityEngine.Screen.width / 963.0f;
        float heightRate = UnityEngine.Screen.height / 541.0f;
        float positionX = scaleUI.GetComponent<RectTransform>().anchoredPosition.x * widthRate;
        float positionY = scaleUI.GetComponent<RectTransform>().anchoredPosition.y * heightRate;
        scaleUI.localScale = new Vector3(widthRate, heightRate, 1);
        scaleUI.GetComponent<RectTransform>().anchoredPosition = new Vector2(positionX, positionY);

        Debug.Log("width = " + UnityEngine.Screen.width);
        Debug.Log("height = " + UnityEngine.Screen.height);
        Debug.Log("localscale: "+scaleUI.localScale);
        Debug.Log("anchoredposition: "+new Vector2(positionX, positionY));

        success_ui.SetActive(true);
    }

}
