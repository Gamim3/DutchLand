using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoInCar : MonoBehaviour
{
    public GameObject carCam;
    public GameObject playerCam;
   
    // Start is called before the first frame update
    void Start()
    {
        carCam.SetActive(false);
       

        playerCam.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            carCam.SetActive(true);
           

            playerCam.SetActive(false);
            

        }

        if (Input.GetButtonDown("Use"))
        {
            carCam.SetActive(false);
            

            playerCam.SetActive(true);
           

        }
        
    }
}
