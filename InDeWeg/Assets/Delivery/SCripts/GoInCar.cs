using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoInCar : MonoBehaviour
{
    public GameObject carCam;
    public GameObject playerCam;
    public GameObject miniMap;

    public RaycastHit hit;

    public bool parkSpaceFarm;
   
    // Start is called before the first frame update
    void Start()
    {
        carCam.SetActive(false);
        miniMap.SetActive(false);
        if (GetComponent<Car>())
        {
            GetComponent<Car>().enabled = false;
        }

        playerCam.SetActive(true);
        if (GetComponent<Movers>())
        {
            GetComponent<Movers>().enabled = true;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (parkSpaceFarm == true)
        {
            if (Input.GetButtonDown("GetInCar"))
            {
                carCam.SetActive(true);
                miniMap.SetActive(true);
                if (GetComponent<Car>())
                {
                    GetComponent<Car>().enabled = true;
                }

                playerCam.SetActive(false);
                if (GetComponent<Movers>())
                {
                    GetComponent<Movers>().enabled = false;
                }
            }

            else if (Input.GetButtonDown("GetOutCar"))
            {
                carCam.SetActive(false);
                miniMap.SetActive(false);
                if (GetComponent<Car>())
                {
                    GetComponent<Car>().enabled = false;
                }

                playerCam.SetActive(true);
                if (GetComponent<Movers>())
                {
                    GetComponent<Movers>().enabled = true;
                }

            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        parkSpaceFarm = true;
    }

    private void OnTriggerExit(Collider other)
    {
        parkSpaceFarm = false;
    }

}
