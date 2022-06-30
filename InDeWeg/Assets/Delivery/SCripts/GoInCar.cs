using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoInCar : MonoBehaviour
{
    public GameObject carCam;
    public GameObject playerCam;
    public GameObject miniMap;
    public GameObject carGo;
    public GameObject playerGo;

    public RaycastHit hit;

    public bool parkSpaceFarm;

    public bool parkSpaceDelivery;

    public bool carRange;
   
    // Start is called before the first frame update
    void Start()
    {
        carCam.SetActive(false);
        miniMap.SetActive(false);

        carGo.GetComponent<GoInCar>().enabled = false;

       
        carGo.GetComponent<Car>().enabled = false;
       
        playerCam.SetActive(true);
        
        playerGo.GetComponent<Movers>().enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 direction = playerCam.transform.forward;

        if (Input.GetButtonDown("Jump") && carRange == true)
        {
            carCam.SetActive(true);
            miniMap.SetActive(true);
            carGo.GetComponent<Car>().enabled = true;

            playerCam.SetActive(false);
            playerGo.GetComponent<Movers>().enabled = false;

            carGo.GetComponent<GoInCar>().enabled = true;
        }
        if (Input.GetButtonDown("Jump") && parkSpaceFarm == true && carRange == false)
        {
            //if (carGo.GetComponent<Car>().speed = 0)
            carCam.SetActive(false);
            miniMap.SetActive(false);
            carGo.GetComponent<Car>().enabled = false;
            carGo.GetComponent<GoInCar>().enabled = false;

            playerCam.SetActive(true);
            playerGo.GetComponent<Movers>().enabled = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ParkSpace")
        {
            parkSpaceDelivery = true;
        }
        if (other.gameObject.tag == "FarmSpace")
        {
            parkSpaceFarm = true;
        }
        if (other.gameObject.tag == "Busje")
        {
            carRange = true;
        }
    }
private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ParkSpace")
        {
            parkSpaceDelivery = false;
        }
        if (other.gameObject.tag == "FarmSpace")
        {
            parkSpaceFarm = false;
        }
        if (other.gameObject.tag == "Busje")
        {
            carRange = false;
        }
    }
}
