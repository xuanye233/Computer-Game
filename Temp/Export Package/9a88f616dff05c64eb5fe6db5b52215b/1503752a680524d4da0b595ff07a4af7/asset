using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCtrl : MonoBehaviour
{
    [SerializeField]
    private RawImage blackImage;
    // Start is called before the first frame update
    void Awake()
    {

    }

    public void QuitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void BlackFade()
    {
        blackImage.gameObject.SetActive(true);
        blackImage.CrossFadeAlpha(1, 1f, false);
        blackImage.CrossFadeAlpha(0, 1f, false);
        StartCoroutine(BlackWait());
    }
    IEnumerator BlackWait() //fade function
    {
        yield return new WaitForSeconds(1);
        blackImage.gameObject.SetActive(false);
    }
}
