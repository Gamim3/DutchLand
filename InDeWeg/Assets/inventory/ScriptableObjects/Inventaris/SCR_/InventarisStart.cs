using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarisStart : MonoBehaviour
{
    public GameObject menu;
    private bool isShowing;
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(isShowing = false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isShowing = !isShowing;
            menu.SetActive(isShowing);
        }
    }
}
