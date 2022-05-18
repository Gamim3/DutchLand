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
                // maybe make speed of the player lower when working
                //GetComponent<Movers>().speed = 0.5f;
                StartCoroutine(Working());
            }
        }
    }
    public IEnumerator Working()
    {
        yield return new WaitForSeconds(0.8f);
        hit.transform.gameObject.GetComponent<ReplaceObject>().Replace("Hoe");
        //GetComponent<Movers>().speed = 1.0f;
    }
}
