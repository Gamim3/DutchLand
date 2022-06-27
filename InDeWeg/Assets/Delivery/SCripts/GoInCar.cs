using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoInCar : MonoBehaviour
{
    public GameObject car;
    public GameObject player;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            car.SetActive(true);
            player.SetActive(false);
        
        }

        if (Input.GetButtonDown("Use"))
        {
            player.SetActive(true);
            car.SetActive(false);
            

        }
        
    }
}
