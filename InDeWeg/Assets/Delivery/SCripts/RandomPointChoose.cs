using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPointChoose : MonoBehaviour
{
    public Transform[] points;
    public GameObject deliverPoint;
    public GameObject pointer;

    public GameObject parkSpot;

    public GameObject clone;

    public bool parked;

    public GameObject player;
    public int indexNumber;
    //public GameObject ;
    public void Start()
    {
        //PickPoints();
    }

    public void Update()
    {
        if (parked == true && Input.GetButtonDown("Jump"))
        {
            Destroy(clone);

            player.GetComponent<RequestManager>().GiveMoney(indexNumber);
        }
     
    }

    public void PickPoints()
    {
        int indexNumber = Random.Range(0, points.Length);
        Debug.Log(points[indexNumber].name);
        Instantiate(deliverPoint, points[indexNumber].position, deliverPoint.transform.rotation);

        clone =Instantiate(deliverPoint, points[indexNumber].position, deliverPoint.transform.rotation);

        pointer.GetComponent<Pointer>().target = points[indexNumber].transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ParkPlace")
        {
            parked = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ParkPlace")
        {
            parked = false;
        }
    }

}
