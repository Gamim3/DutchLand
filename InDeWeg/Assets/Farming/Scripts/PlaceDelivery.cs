using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceDelivery : MonoBehaviour
{
    public GameObject outline1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Place1()
    {
        Instantiate(outline1, transform.position, Quaternion.identity);
    }
}
