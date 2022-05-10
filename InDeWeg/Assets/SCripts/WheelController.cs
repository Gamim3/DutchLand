using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    public GameObject[] wheelsToRotate;
    public float rotationSpeed;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalAxis = Input.GetAxisRaw("Vertical");
        float horizontalAxis = Input.GetAxisRaw("Horizontal");

        foreach(var wheel in wheelsToRotate)
        {
            wheel.transform.Rotate(Time.deltaTime * verticalAxis * rotationSpeed, 0f, 0f, Space.Self);
        }

        if (horizontalAxis > 0)
        {
            // Turning Right
            anim.SetBool("GoingLeft",false);
            anim.SetBool("GoingRight", true);

        }
        else if (horizontalAxis < 0)
        {
            // Turning Left
            anim.SetBool("GoingLeft", true);
            anim.SetBool("GoingRight", false);

        }
        else
        {
            // Must Be Going Straight
            anim.SetBool("GoingLeft", false);
            anim.SetBool("GoingRight", false);

        }
        
        
    }
}
