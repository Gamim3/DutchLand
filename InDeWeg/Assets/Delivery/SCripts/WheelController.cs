using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    public Transform[] wheelsToRotate;
    public float rotationSpeed;
    public Transform[] wheelsToTurn;
    public float turnSpeed;
   
    // Update is called once per frame
    void Update()
    {
        
        float verticalAxis = Input.GetAxisRaw("Vertical");
        float horizontalAxis = Input.GetAxisRaw("Horizontal");

        foreach (Transform wheel in wheelsToRotate)
        {
            wheel.Rotate(new Vector3(Time.deltaTime * verticalAxis * rotationSpeed, 0f, 0f));
        }
        foreach(Transform wheel in wheelsToTurn)
        {
            wheel.Rotate(new Vector3(0, Time.deltaTime * horizontalAxis * turnSpeed, 0));
        }
    }
}
