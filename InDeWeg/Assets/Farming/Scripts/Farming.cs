using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farming : MonoBehaviour
{
    public RaycastHit hit;

    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (Physics.Raycast(transform.position, direction, out hit, 3f)&& hit.transform.tag == "FarmTile")
            {

            }
        }
    }
}
