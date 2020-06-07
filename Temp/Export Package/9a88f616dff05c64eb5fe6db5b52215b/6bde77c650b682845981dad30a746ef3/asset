using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonControl : MonoBehaviour
{
    [SerializeField]
    private List<Button> buttons;
    [SerializeField]
    private List<GameObject> panels;
    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Button teachingButton;
    [SerializeField]
    private Button guideButton;
    [SerializeField]
    private Button settingButton;
    [SerializeField]
    private Button quitButton;
    [SerializeField]
    private GameObject playPanel;
    [SerializeField]
    private GameObject teachingPanel;
    [SerializeField]
    private GameObject guidePanel;
    [SerializeField]
    private GameObject settingPanel;

    [SerializeField]
    private GameObject mainPanel;

    [SerializeField]
    private RawImage blackImage;

    public void Awake()
    {
        buttons = new List<Button>();
        panels = new List<GameObject>();
        //playButton = GameObject.Find("Canvas/LeftBtns/TabBtn1").GetComponent<Button>();
        //guideButton = GameObject.Find("Canvas/LeftBtns/TabBtn2").GetComponent<Button>();
        //settingButton = GameObject.Find("Canvas/LeftBtns/TabBtn3").GetComponent<Button>();
        //settingButton = GameObject.Find("Canvas/LeftBtns/TabBtn3").GetComponent<Button>();
        buttons.Add(playButton);
        buttons.Add(teachingButton);
        buttons.Add(guideButton);
        buttons.Add(settingButton);
        buttons.Add(quitButton);

        panels.Add(playPanel);
        panels.Add(teachingPanel);
        panels.Add(guidePanel);
        panels.Add(settingPanel);

        blackImage.CrossFadeAlpha(0, 1f, false);
        blackImage.gameObject.SetActive(false);

        //panels

        for (int i = 0; i < panels.Count; i++)
        {
            panels[i].SetActive(false);
        }
    }

    public void playClick()
    {
        openFade(0);
    }

    public void teachingClick()
    {
        openFade(1);
    }

    public void guideClick()
    {
        openFade(2);
    }

    public void settingClick()
    {
        Debug.Log("111");
        openFade(3);
    }

    public void quitClick()
    {
        Application.Quit();
        Debug.Log("111");
    }

    public void openFade(int index)
    {
        Debug.Log("222");
        blackImage.gameObject.SetActive(true);
        //panel.CrossFadeAlpha(1, 1f, false);
        blackImage.CrossFadeAlpha(1, 1f, false);
        for (int i = 0; i < panels.Count; i++)
        {
            panels[i].SetActive(false);
        }
        mainPanel.SetActive(false);
        panels[index].SetActive(true);
        blackImage.CrossFadeAlpha(0, 1f, false);
        StartCoroutine(Wait());
    }

    public void backToMain()
    {
        blackImage.gameObject.SetActive(true);
        //panel.CrossFadeAlpha(1, 1f, false);
        blackImage.CrossFadeAlpha(1, 1f, false);
        for (int i = 0; i < panels.Count; i++)
        {
            panels[i].SetActive(false);
        }
        mainPanel.SetActive(true);
        //panels[index].SetActive(true);
        blackImage.CrossFadeAlpha(0, 1f, false);
        //blackImage.gameObject.SetActive(false);
        StartCoroutine(Wait());
    }
    IEnumerator Wait() //fade function
    {
        yield return new WaitForSeconds(1);
        blackImage.gameObject.SetActive(false);
    }
}
