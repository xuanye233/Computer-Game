using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSound : MonoBehaviour
{
    public AudioSource sound;
    int isplay = 0;
    // Start is called before the first frame update
    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<ParticleSystem>().isPlaying&&isplay==0)
        {
            sound.Play();
            isplay = 1;
        }
    }
}
