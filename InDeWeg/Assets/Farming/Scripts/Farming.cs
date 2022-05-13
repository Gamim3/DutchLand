using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farming : MonoBehaviour
{
    public Transform cam;
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePos = Input.mousePosition;

            print("schiet");
            if (Physics.Raycast(cam.position, mousePos, 100f))
            {
                print("raak");
            }
        }
    }
}
