using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatRider : MonoBehaviour
{
    public Rigidbody rigidbody;
    public GameObject boatModel;
    public float forwardSpeed;
    public float sideSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float forwardThrust = 0;
        if (Input.GetKey(KeyCode.W))
        {
            forwardThrust = forwardSpeed;        
        }
        if (Input.GetKey(KeyCode.S))
        {
            forwardThrust = -forwardSpeed;
        }
        rigidbody.AddForce(gameObject.transform.forward * forwardThrust);

        float sideThrust = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            sideThrust = -sideSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            sideThrust = sideSpeed;
        }

        rigidbody.AddRelativeTorque(Vector3.up * sideThrust);   //

        boatModel.transform.position  = transform.position;
        boatModel.transform.rotation = transform.rotation;
    }
}
