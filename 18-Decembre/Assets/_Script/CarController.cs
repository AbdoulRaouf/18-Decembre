using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private Rigidbody SphereRb;
    [SerializeField] private float forwardSpeed;   
    [SerializeField] private float reverseSpeed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float airDrag;
    [SerializeField] private float groudDrag;
    [SerializeField] private LayerMask groundLayer;
    public float movementInput;
    public float turnInput;
    private bool isGrounded;

    void Start()
    {
        SphereRb.transform.parent = null;
    }

    void Update()
    {
        movementInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");
        //input*=forwardSpeed;

        if (movementInput > 0)
        {
            movementInput *= forwardSpeed;
        }
        else
        {
            movementInput*=reverseSpeed;
        }



        transform.position = SphereRb.transform.position;

        //truning
        float newRotation=turnInput * turnSpeed*(Time.deltaTime*.5f)*Input.GetAxisRaw("Vertical");


        transform.Rotate(0, newRotation, 0, Space.World);
        
        RaycastHit hit;

        isGrounded = Physics.Raycast(transform.position, -transform.up, out hit,.5f,groundLayer);   

        transform.rotation= Quaternion.FromToRotation(transform.up, hit.normal)*transform.rotation;

        if (isGrounded)
        {
            SphereRb.drag=groudDrag;
        }
        else
        {
            SphereRb.drag=airDrag;
        }
    }

    private void FixedUpdate()
    {
        if (isGrounded)
        {
            SphereRb.AddForce(transform.forward * movementInput, ForceMode.Acceleration);
        }
        else
        {
            SphereRb.AddForce(transform.up * -30f);
        }

    }
}
