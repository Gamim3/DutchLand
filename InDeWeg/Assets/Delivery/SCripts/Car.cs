using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    public Transform centerOfMass;

    public WheelCollider wheelColliderLeftFront;
    public WheelCollider wheelColliderRightFront;
    public WheelCollider wheelColliderLeftBack;
    public WheelCollider wheelColliderRightBack;

    public Transform wheelLeftFront;
    public Transform wheelRightfront;
    public Transform wheelLeftBack;
    public Transform wheelRightBack;

    public float motorTorque = 100f;
    public float maxSteer = 20f;
    private Rigidbody _rigidbody;

    public bool isBrake = false;
    public float brakeTorgue = 5000f;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = centerOfMass.localPosition;
    }

    void FixedUpdate()
    {
        wheelColliderLeftBack.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        wheelColliderRightBack.motorTorque = Input.GetAxis("Vertical") * motorTorque;

        wheelColliderLeftFront.steerAngle = Input.GetAxis("Horizontal") * maxSteer;
        wheelColliderRightFront.steerAngle = Input.GetAxis("Horizontal") * maxSteer;

        HandBrake();


    }

    void Update()
    {
        var pos = Vector3.zero;
        var rot = Quaternion.identity;

        wheelColliderLeftFront.GetWorldPose(out pos, out rot);
        wheelLeftFront.position = pos;
        wheelLeftFront.rotation = rot;

        wheelColliderRightFront.GetWorldPose(out pos, out rot);
        wheelRightfront.position = pos;
        wheelRightfront.rotation = rot * Quaternion.Euler(0, 0, 0);

        wheelColliderLeftBack.GetWorldPose(out pos, out rot);
        wheelLeftBack.position = pos;
        wheelLeftBack.rotation = rot;

        wheelColliderRightBack.GetWorldPose(out pos, out rot);
        wheelRightBack.position = pos;
        wheelRightBack.rotation = rot * Quaternion.Euler(0, 0, 0);

    }

    public void HandBrake()
    {
        if (Input.GetButton("Rem"))
        {
            isBrake = true;
        }
        
        else
        {
            isBrake = false;
        }
        
        if (isBrake == true)
        {
            wheelColliderLeftFront.brakeTorque = brakeTorgue;
            wheelColliderRightFront.brakeTorque = brakeTorgue;
            wheelColliderLeftBack.motorTorque = 0f;
            wheelColliderRightBack.motorTorque = 0f;
        }

        else
        {
            wheelColliderLeftFront.brakeTorque = 0f;
            wheelColliderRightFront.brakeTorque = 0f;
        }
    }

}
