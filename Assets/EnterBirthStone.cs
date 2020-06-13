using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBirthStone : MonoBehaviour
{

    [SerializeField]
    EDU_process eDU_Process;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("player enters BirthStone");
            eDU_Process.useOriginStoneEvent();
            player.transform.position = new Vector3(0.2f, 6.843f, -38.3f);
        }
    }
}
