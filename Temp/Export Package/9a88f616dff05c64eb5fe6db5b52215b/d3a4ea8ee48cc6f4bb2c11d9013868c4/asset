using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundFit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Resize();
    }

    void Update()
    {
        
    }

    // Update is called once per frame
    void Resize()
    {
        float width = GetComponent<Image>().sprite.rect.width;
        float height = GetComponent<Image>().sprite.rect.height;
        Vector3 scale = transform.localScale;
        float ratio=1;
        if (((float)Screen.height / Screen.width) > (height / width))
            ratio = (float)Screen.height / Screen.width * width / height;
        else
            ratio = (float)Screen.width / Screen.height * height / width;
        transform.localScale = scale * ratio;
    }
}
