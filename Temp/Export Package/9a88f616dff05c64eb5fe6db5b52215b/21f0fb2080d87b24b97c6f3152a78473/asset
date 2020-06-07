using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class SetSound : MonoBehaviourPunCallbacks
{
    public AudioSource sound;
    public AudioClip set;
    // Start is called before the first frame update
    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();
        set= Resources.Load<AudioClip>("music/set");
        sound.clip = set;
        sound.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
