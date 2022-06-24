using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    void Update()
    {
        transform.LookAt(target);
        Vector3 curRot = transform.localEulerAngles;
        curRot.x = 0;
        transform.localEulerAngles = curRot;

        
    }
}
