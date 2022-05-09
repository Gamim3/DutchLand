using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float moveInput;
    private float turnInput;
    private bool isCarGrounded;

    public float normalDrag;
    public float modifiedDrag;
    public float gravityCar;

    public float fwdSpeed;
    public float revSpeed;
    public float turnSpeed;
    public LayerMask groundLayer;

    public float alignToGroundTime;

    public Rigidbody sphereRB;
    public Rigidbody carRB;
    
    void Start()
    {
        // detach rigidbody from car
        sphereRB.transform.parent = null;
        carRB.transform.parent = null;
    }

    
    void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");

        // Nitrous
        if (Input.GetButton("Jump"))
        {
            fwdSpeed = 300;
        }
        else
        {
            fwdSpeed = 150;
        }

        // adjust speed for car
        moveInput *= moveInput > 0 ? fwdSpeed : revSpeed;

        // set cars position to sphere
        transform.position = sphereRB.transform.position;

        // set cars rotation
        float newRotation = turnInput * turnSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        transform.Rotate(0, newRotation, 0, Space.World);

        // raycast ground check
        RaycastHit hit;
        isCarGrounded = Physics.Raycast(transform.position, -transform.up, out hit, 1f, groundLayer);

        // rotate car to be parallel to ground
        Quaternion toRotateTo = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, toRotateTo, alignToGroundTime * Time.deltaTime);

        // change drag
        if (isCarGrounded)
        {
            sphereRB.drag = normalDrag;
        }
        else
        {
            sphereRB.drag = modifiedDrag;
        }
    }
    private void FixedUpdate()
    {
        if (isCarGrounded)
        {
            // move car
            sphereRB.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
        }
        else
        {
            // add extra gravity
            sphereRB.AddForce(transform.up * gravityCar);
        }
    }

}
