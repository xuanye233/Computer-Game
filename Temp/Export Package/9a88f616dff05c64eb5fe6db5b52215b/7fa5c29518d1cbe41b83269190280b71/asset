using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EDU_walkSound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource sound1;
    public AudioSource sound2;
    int isWalking;
    int isJumping;
    public AudioClip jump;
    public AudioClip walk;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        sound1 = gameObject.GetComponents<AudioSource>()[0];
        sound2 = gameObject.GetComponents<AudioSource>()[1];
        isWalking = 0;
        isJumping = 0;
        player = GameObject.Find("Player(Clone)");
        jump = Resources.Load<AudioClip>("music/Jump");
        walk = Resources.Load<AudioClip>("music/Walk");
        sound1.clip = walk;
    }

    // Update is called once per frame
    void turnToWalk()
    {
        sound1.clip = walk;
        sound1.Stop();
        isJumping = 0;
        Debug.Log("walk");
    }

    public void StartMove()
    {
        sound1.Play();
        isWalking = 1;
    }

    public void StopMove()
    {
        sound1.Stop();
        isWalking = 0;
        //Debug.Log("stop");
    }

    public void QuickMove()
    {
        sound1.pitch = 1.2f;
        sound1.volume = 0.8f;
    }

    public void SlowMove()
    {
        sound1.pitch = 0.74f;
        sound1.volume = 0.05f;
    }

    public void NormalMove()
    {
        sound1.pitch = 1.0f;
        sound1.volume = 0.6f;
    }

    public void Jumping()
    {
        isJumping = 1;
        sound1.volume = 0.6f;
        if (sound1.isPlaying)
        {
            isWalking = 0;
            sound1.Stop();
            sound1.clip = jump;
            sound1.Play();
            Invoke("turnToWalk", 0.8f);
            Debug.Log("jump1");
        }
        else
        {
            sound1.clip = jump;
            sound1.Play();
            Invoke("turnToWalk", 0.8f);
            Debug.Log("jump2");
        }
    }

    void Update()
    {
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && !sound1.isPlaying)
        {
            StartMove();
        }

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && isJumping == 0)
        {
            StopMove();
        }

        if (Input.GetKey(KeyCode.LeftShift) && isWalking == 1)
        {
            QuickMove();
        }

        if (Input.GetKey(KeyCode.C) && isWalking == 1)
        {
            SlowMove();
        }

        if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.C))
        {
            NormalMove();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isJumping == 0)
        {
            Jumping();
        }

    }


}
