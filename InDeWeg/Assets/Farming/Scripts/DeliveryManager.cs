using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public GameObject[] deliveryPlace;
    public int arrayNumberPlace;
    public Transform deliveryPlaceTrans;
    public GameObject outline;
    // Start is called before the first frame update
    void Start()
    {
        arrayNumberPlace = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            arrayNumberPlace = Random.Range(0, 9);
        }
        
        if (arrayNumberPlace == 0)
        {
            deliveryPlaceTrans = deliveryPlace[0].transform;
            Instantiate(outline, deliveryPlaceTrans.position, Quaternion.identity);
            arrayNumberPlace = 10;
        }
        if (arrayNumberPlace == 1)
        {
            deliveryPlaceTrans = deliveryPlace[1].transform;
            Instantiate(outline, deliveryPlaceTrans.position, Quaternion.identity);
            arrayNumberPlace = 10;
        }
        if (arrayNumberPlace == 2)
        {
            deliveryPlaceTrans = deliveryPlace[2].transform;
            Instantiate(outline, deliveryPlaceTrans.position, Quaternion.identity);
            arrayNumberPlace = 10;
        }
        if (arrayNumberPlace == 3)
        {
            deliveryPlaceTrans = deliveryPlace[3].transform;
            Instantiate(outline, deliveryPlaceTrans.position, Quaternion.identity);
            arrayNumberPlace = 10;
        }
        if (arrayNumberPlace == 4)
        {
            deliveryPlaceTrans = deliveryPlace[4].transform;
            Instantiate(outline, deliveryPlaceTrans.position, Quaternion.identity);
            arrayNumberPlace = 10;
        }
        if (arrayNumberPlace == 5)
        {
            deliveryPlaceTrans = deliveryPlace[5].transform;
            Instantiate(outline, deliveryPlaceTrans.position, Quaternion.identity);
            arrayNumberPlace = 10;
        }
        if (arrayNumberPlace == 6)
        {
            deliveryPlaceTrans = deliveryPlace[6].transform;
            Instantiate(outline, deliveryPlaceTrans.position, Quaternion.identity);
            arrayNumberPlace = 10;
        }
        if (arrayNumberPlace == 7)
        {
            deliveryPlaceTrans = deliveryPlace[7].transform;
            Instantiate(outline, deliveryPlaceTrans.position, Quaternion.identity);
            arrayNumberPlace = 10;
        }
        if (arrayNumberPlace == 8)
        {
            deliveryPlaceTrans = deliveryPlace[8].transform;
            Instantiate(outline, deliveryPlaceTrans.position, Quaternion.identity);
            arrayNumberPlace = 10;
        }
        if (arrayNumberPlace == 9)
        {
            deliveryPlaceTrans = deliveryPlace[9].transform;
            Instantiate(outline, deliveryPlaceTrans.position, Quaternion.identity);
            arrayNumberPlace = 10;
        }
    }
}
