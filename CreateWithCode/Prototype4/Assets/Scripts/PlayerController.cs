using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Private Rigidbody playerRb;
    Public float speed = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponenet<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(Vector3.forward * speed *  forwardInput);
    }
}
