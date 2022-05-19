using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watering : MonoBehaviour
{
    public RaycastHit hit;

    public GameObject cam;

    public bool working;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = cam.transform.forward;

        if (Input.GetButtonDown("Fire1") && working == false)
        {
            if (Physics.Raycast(transform.position, direction, out hit, 3f) && hit.transform.tag == "FarmTile")
            {
                working = true;

                StartCoroutine(Working());
            }
        }
    }
    public IEnumerator Working()
    {
        yield return new WaitForSeconds(0.8f);

        hit.transform.gameObject.GetComponent<ReplaceObject>().Replace("WateringCan");

        working = false;
    }
}