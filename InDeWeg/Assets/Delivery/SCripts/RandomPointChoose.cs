using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPointChoose : MonoBehaviour
{
    public Transform[] points;
    public GameObject deliverPoint;
    public GameObject miniMapIcon;
    public GameObject pointer;
    public GameObject parkSpot;
    public GameObject parkSphere;

    public void Start()
    {
        PickPoints();
        
    }

    public void PickPoints()
    {
        int indexNumber = Random.Range(0, points.Length);
        Debug.Log(points[indexNumber].name);
        Instantiate(deliverPoint, points[indexNumber].position, deliverPoint.transform.rotation);
        Instantiate(miniMapIcon, points[indexNumber].position,Quaternion.identity);

        pointer.GetComponent<Pointer>().target = points[indexNumber].transform;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (Input.GetButtonDown("Jump"))
        {
            
        }
    }

}
