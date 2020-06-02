using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EDU_process : MonoBehaviour
{
    [SerializeField]
    Text welcomeText;
    [SerializeField]
    Text moveText;
    [SerializeField]
    Text rotateText;
    [SerializeField]
    Text pickUpText;
    [SerializeField]
    Text useFoodText;
    [SerializeField]
    Text useFireStoneText;
    [SerializeField]
    Text clickTorchText;
    [SerializeField]
    Text endText;

    [SerializeField]
    GameObject foodArrow;
    [SerializeField]
    GameObject torchArrow;
    [SerializeField]
    GameObject fireStoneArrow;
    [SerializeField]
    GameObject foodUIArrow;



    bool isa;
    bool isw;
    bool iss;
    bool isd;
    bool isjump;

    bool displayRotate;
    int process;

    private void Start()
    {
        //welcomeText.CrossFadeAlpha(1, 1f, false);
        StartCoroutine(welcomeWait());
        isa = false;
        iss = false;
        isw = false;
        isd = false;
        isjump = false;
        displayRotate = false;
        process = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            isa = true;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            isw = true;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            iss = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            isd = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            isjump = true;
        }

        if (isa && isw && iss && isd && isjump)
        {
            process = 1;
        }

        if(process == 1 && !displayRotate)
        {
            StartCoroutine(moveWait());
            displayRotate = true;
        }

    }

    public void eatEvent()
    {
        StartCoroutine(EatWait());
    }

    public void eat2Event()
    {
        StartCoroutine(Eat2Wait());
    }

    public void fireStoneEvent()
    {
        StartCoroutine(fireStoneWait());
    }

    public void clickTorchEvent()
    {
        StartCoroutine(clickTorchWait());
    }

    public IEnumerator welcomeWait() //fade function
    {
        //yield return new WaitForSeconds(5);
        welcomeText.CrossFadeAlpha(0, 1f, false);
        welcomeText.gameObject.SetActive(true);
        welcomeText.CrossFadeAlpha(1, 1f, false);
        yield return new WaitForSeconds(3);
        welcomeText.CrossFadeAlpha(0, 1f, false);
        yield return new WaitForSeconds(1);
        moveText.CrossFadeAlpha(0, 1f, false);
        moveText.gameObject.SetActive(true);
        moveText.CrossFadeAlpha(1, 1f, false);
    }

    public IEnumerator moveWait() //fade function
    {
        moveText.CrossFadeAlpha(0, 1f, false);
        yield return new WaitForSeconds(1);
        rotateText.CrossFadeAlpha(0, 1f, false);
        rotateText.gameObject.SetActive(true);
        rotateText.CrossFadeAlpha(1, 1f, false);
        yield return new WaitForSeconds(3);
        rotateText.CrossFadeAlpha(0, 1f, false);
        yield return new WaitForSeconds(1);
        //显示捡食物
        pickUpText.CrossFadeAlpha(0, 1f, false);
        pickUpText.gameObject.SetActive(true);
        pickUpText.CrossFadeAlpha(1, 1f, false);
        foodArrow.SetActive(true);
    }

    public IEnumerator EatWait() //fade function
    {
        Debug.Log("gaocuole");
        //pickUpText.CrossFadeAlpha(1, 1f, false);
        foodArrow.SetActive(false);
        pickUpText.CrossFadeAlpha(0, 1f, false);
        
        yield return new WaitForSeconds(1);
        useFoodText.CrossFadeAlpha(0, 1f, false);
        useFoodText.gameObject.SetActive(true);
        useFoodText.CrossFadeAlpha(1, 1f, false);
        foodUIArrow.SetActive(true);
    }

    public IEnumerator Eat2Wait() //fade function
    {
        Debug.Log("zhendecuole");
        foodUIArrow.SetActive(false);
        useFoodText.CrossFadeAlpha(0, 1f, false);
        yield return new WaitForSeconds(1);
        useFireStoneText.CrossFadeAlpha(0, 1f, false);
        useFireStoneText.gameObject.SetActive(true);
        useFireStoneText.CrossFadeAlpha(1, 1f, false);
        fireStoneArrow.SetActive(true);
    }

    public IEnumerator fireStoneWait() //fade function
    {
        fireStoneArrow.SetActive(false);
        useFireStoneText.CrossFadeAlpha(0, 1f, false);
        yield return new WaitForSeconds(1);
        //显示点击火把文字和箭头
        clickTorchText.CrossFadeAlpha(0, 1f, false);
        clickTorchText.gameObject.SetActive(true);
        clickTorchText.CrossFadeAlpha(1, 1f, false);
        torchArrow.SetActive(true);
    }

    public IEnumerator clickTorchWait() //fade function
    {
        torchArrow.SetActive(false);
        clickTorchText.CrossFadeAlpha(0, 1f, false);
        yield return new WaitForSeconds(1);
        endText.CrossFadeAlpha(0, 1f, false);
        endText.gameObject.SetActive(true);
        endText.CrossFadeAlpha(1, 1f, false);
    }
}
