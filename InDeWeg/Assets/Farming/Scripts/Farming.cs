using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farming : MonoBehaviour
{
    public RaycastHit hit;

    public GameObject cam3;

    public Vector3 direction;

    public LayerMask mask;
    void Start()
    {
        
    }
    void Update()
    {
        // maybe GetButton
        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(cam3.transform.position, Vector3.forward, out hit, 10.0f) && hit.transform.gameObject.tag == "FarmingTile")
            {

            }
        }
    }
}
