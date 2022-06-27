using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deliveroo : MonoBehaviour
{
    public GameObject player;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ParkPoint")
        {
            print ("test");
            Destroy(other.gameObject);
        }
        Destroy(other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        
    }

}
