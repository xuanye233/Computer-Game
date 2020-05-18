using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip click;

    // Start is called before the first frame update
    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();
        click = Resources.Load<AudioClip>("music/click");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        sound.clip = click;
        sound.Play();
    }
}
