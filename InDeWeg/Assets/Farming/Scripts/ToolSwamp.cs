using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSwamp : MonoBehaviour
{
    public int state;

    public RaycastHit hit;

    public GameObject cam;

    public bool working;

    // Start is called before the first frame update
    void Start()
    {
        state = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (working == false)
        {
            GetComponent<Movers>().speed = 1.0f;
        }
        else
        {
            GetComponent<Movers>().speed = 0.0f;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            state += 1;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            state -= 1;
        }
        if (state == 5)
        {
            state = 1;
        }
        if (state == 0)
        {
            state = 4;
        }
        ToolWorking();
    }
    void ToolWorking()
    {
        Vector3 direction = cam.transform.forward;

        if (Input.GetButtonDown("Fire1") && working == false)
        {
            if (Physics.Raycast(transform.position, direction, out hit, 3f) && hit.transform.tag == "FarmTile")
            {
                // maybe make speed of the player lower when working
                //GetComponent<Movers>().speed = 0.5f;

                working = true;

                StartCoroutine(Working());
            }
        }
    }
    public IEnumerator Working()
    {
        yield return new WaitForSeconds(0.8f);

        if (state == 1)
        {
            hit.transform.gameObject.GetComponent<ReplaceObject>().Replace("Hoe");

            working = false;
        }
        if (state == 2)
        {
            hit.transform.gameObject.GetComponent<ReplaceObject>().Replace("WateringCan");

            working = false;
        }
        if (state == 3)
        {
            hit.transform.gameObject.GetComponent<ReplaceObject>().Replace("Shovel");
            working = false;
        }
        if (state == 4)
        {
            hit.transform.gameObject.GetComponent<ReplaceObject>().Replace("Scythe");
            working = false;
        }
        //GetComponent<Movers>().speed = 1.0f;
    }
}
