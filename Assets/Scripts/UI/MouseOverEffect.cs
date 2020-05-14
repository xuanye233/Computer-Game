using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOverEffect : MonoBehaviour
{
    private Color DefaultColor;
    public void PointerEnter()
    {
        float G = (float)(208.0 / 255.0);
        float B = (float)(32.0 / 255.0);
        Color color = new Color(1, G, B);
        DefaultColor = this.GetComponent<Image>().color;
        this.GetComponent<Image>().color = color;
    }

    public void PointerExit()
    {
        this.GetComponent<Image>().color = DefaultColor;
    }
    public void PointerUp()
    {
        this.GetComponent<Image>().color = DefaultColor;
    }
}
