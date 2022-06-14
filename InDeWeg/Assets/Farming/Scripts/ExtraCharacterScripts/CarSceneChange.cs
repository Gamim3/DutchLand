using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSceneChange : MonoBehaviour
{
    public RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 0.8f))
        {
            if (hit.transform.gameObject.tag == ("CarSceneChanger"))
            {
                if (Input.GetKeyDown("e"))
                {
                    Debug.Log("it Works");

                }

            }

        }
    }
}
