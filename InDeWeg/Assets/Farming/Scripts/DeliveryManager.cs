using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public GameObject[] deliveryPlace;

    public int numberPlace;

    public GameObject outlineC;
    public GameObject outlineS;
    public GameObject outlineR;

    public bool sceneSwitch;

    // Start is called before the first frame update
    void Start()
    {
        numberPlace = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneSwitch == true)
        {
            numberPlace = Random.Range(0, 2);

            Instantiate(outlineC, deliveryPlace[numberPlace].transform.position, Quaternion.identity);

            numberPlace = Random.Range(3, 6);

            Instantiate(outlineS, deliveryPlace[numberPlace].transform.position, Quaternion.identity);

            numberPlace = Random.Range(7, 9);

            Instantiate(outlineR, deliveryPlace[numberPlace].transform.position, Quaternion.identity);

            sceneSwitch = false;
        }

    }
}
