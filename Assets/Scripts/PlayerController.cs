using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20.0f;
    private float turnspeed = 25.0f;
    private Rigidbody rb;
    private float horizontalInput;
    private float verticalInput;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //transform.Translate(0,0,1);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        // transform.Translate(Vector3.right * Time.deltaTime * turnspeed * horizontalInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnspeed * horizontalInput);
       
    }
}
