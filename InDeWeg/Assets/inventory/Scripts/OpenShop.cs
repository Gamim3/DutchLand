using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    public GameObject ShopManager;

    public GameObject playerCam;

    public RaycastHit hit;

    public bool switching;

    public GameObject coinUi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = playerCam.transform.forward;
        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(transform.position, direction, out hit, 3f) && hit.transform.tag == "Shop")
            {
                if (switching == false)
                {
                    ShopManager.SetActive(true);
                    coinUi.SetActive(false);

                    Cursor.lockState = CursorLockMode.None;
                    playerCam.GetComponent<Cams>().inMenu = true;

                    switching = true;
                    return;
                }
            }
        }
    }
    public void CloseMenu()
    {
        ShopManager.SetActive(false);
        coinUi.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;
        playerCam.GetComponent<Cams>().inMenu = false;

        switching = false;
    }
}
