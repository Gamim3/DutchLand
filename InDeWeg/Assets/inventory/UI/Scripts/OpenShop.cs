using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShopAndInv : MonoBehaviour
{
    public RaycastHit hit;
    public GameObject shopCanvas;
    public bool isShowing;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 0.8f))
        {
            if (hit.transform.gameObject.tag == ("Shop"))
            {
                if (Input.GetButtonDown("Use"))
                {
                    isShowing = !isShowing;
                    shopCanvas.SetActive(isShowing);
                }
            }
        }

    }
}
