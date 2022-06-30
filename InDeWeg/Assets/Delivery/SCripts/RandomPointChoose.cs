using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPointChoose : MonoBehaviour
{
    public Transform[] points;
    public GameObject deliverPoint;
    public GameObject pointer;
<<<<<<< Updated upstream
    public GameObject parkSpot;
=======

    public GameObject clone;

    public bool parked;
   
>>>>>>> Stashed changes

    //public GameObject ;
    public void Start()
    {
        PickPoints();
        
    }

    public void Update()
    {
        if (parked == true&&Input.GetButtonDown("Jump"))
        {
            Destroy(clone);
        }
     
    }

    public void PickPoints()
    {
        int indexNumber = Random.Range(0, points.Length);
        Debug.Log(points[indexNumber].name);
<<<<<<< Updated upstream
        Instantiate(deliverPoint, points[indexNumber].position, deliverPoint.transform.rotation);

        
=======
        clone =Instantiate(deliverPoint, points[indexNumber].position, deliverPoint.transform.rotation);

       
>>>>>>> Stashed changes
        pointer.GetComponent<Pointer>().target = points[indexNumber].transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ParkPoint")
        {
            parked = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        parked = false;
    }

}
