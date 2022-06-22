using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPointChoose : MonoBehaviour
{
    public Transform[] points;
    public GameObject deliverPoint;

    public void Start()
    {
        PickPoints();
    }

    public void PickPoints()
    {
        int indexNumber = Random.Range(0, points.Length);
        Debug.Log(points[indexNumber].name);
        Instantiate(deliverPoint, points[indexNumber].position, deliverPoint.transform.rotation);
    }


}
