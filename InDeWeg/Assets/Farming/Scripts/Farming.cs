using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farming : MonoBehaviour
{
    public RaycastHit hit;

    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = cam.transform.forward;

        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(transform.position, direction, out hit, 3f)&& hit.transform.tag == "FarmTile")
            {
                hit.transform.gameObject.GetComponent<ReplaceObject>().Replace(0);
                hit.transform.gameObject.GetComponent<ReplaceObject>().replaceO = true;
                print("raak");
            }
        }
    }
}
