using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSwap : MonoBehaviour
{
    public int state;

    public RaycastHit hit;

    public GameObject cam;

    public bool working;

    public GameObject seedMenu;
    public bool isShowing;

    public int seedSlot;

    public int groundToolState;

    public string growthStageTool;

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
                //working = true;
                growthStageTool = hit.transform.gameObject.GetComponent<ReplaceObject>().growthStage;

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

            groundToolState = hit.transform.gameObject.GetComponent<ReplaceObject>().groundstates;

            working = false;
        }
        if (state == 2)
        {
            hit.transform.gameObject.GetComponent<ReplaceObject>().Replace("WateringCan");

            groundToolState = hit.transform.gameObject.GetComponent<ReplaceObject>().groundstates;

            working = false;
        }
        if (state == 3 && groundToolState == 3)
        {
            working = true;
            seedSlot = GetComponent<InventoryManager>().slotIndex;

            if (GetComponent<InventoryManager>().inventorySlots[seedSlot].item == null)
            {
                working = false;
            }

            if (GetComponent<InventoryManager>().inventorySlots[seedSlot].item != null && GetComponent<InventoryManager>().inventorySlots[seedSlot].item.itemTag == "seeds")
            {
                Instantiate (GetComponent<InventoryManager>().inventorySlots[seedSlot].item.seed, hit.transform.position, Quaternion.identity);

                GetComponent<InventoryManager>().RemoveItem(1);

                working = false;

            }



            working = false;
        }
        if (state == 4)
        {
            hit.transform.gameObject.GetComponent<ReplaceObject>().Replace("Scythe");

            groundToolState = hit.transform.gameObject.GetComponent<ReplaceObject>().groundstates;

            working = false;
        }
        //GetComponent<Movers>().speed = 1.0f;
    }
}
