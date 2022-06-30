using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSwapping : MonoBehaviour
{

    public GameObject cam;

    public bool working;

    public RaycastHit hit;

    public GameObject[] tools;

    public Animation[] anim;
    // Start is called before the first frame update
    void Start()
    {
        toolstates = Toolstates.Hoe;
    }
    public enum Toolstates
    {
        Hoe,
        Water,
        Shovel,
        Scythe

    }
    public Toolstates toolstates;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if ((int)toolstates == 0)
            {
                toolstates = (Toolstates)System.Enum.GetValues(typeof(Toolstates)).Length - 1;
            } else
            {
                toolstates--;
            }

        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if ((int)toolstates == System.Enum.GetValues(typeof(Toolstates)).Length - 1)
            {
                toolstates = (Toolstates)0;
            }
            else
            {
                toolstates++;
            }
        }

        Vector3 direction = cam.transform.forward;

        if (Input.GetButtonDown("Fire1") && working == false && Physics.Raycast(transform.position, direction, out hit, 3f) && hit.transform.tag == "FarmTile")
        {
            Working();

        }

        foreach (GameObject tool in tools)
        {
            tool.SetActive(false);
        }
        tools[(int)toolstates].SetActive(true);

    }
    public void Working()
    {
        switch (toolstates)
        {
            case Toolstates.Hoe:
                hit.transform.gameObject.GetComponent<Ground>().WorkTheGround(Ground.Toolstages.Hoe);
                break;
            case Toolstates.Water:
                hit.transform.gameObject.GetComponent<Ground>().WorkTheGround(Ground.Toolstages.Water);
                break;
            case Toolstates.Shovel:

                int seedSlot = GetComponent<InventoryManager>().slotIndex;

                if (GetComponent<InventoryManager>().inventorySlots[seedSlot].itemS != null)
                {
                    hit.transform.gameObject.GetComponent<PlantGrowthManager>().item = GetComponent<InventoryManager>().inventorySlots[seedSlot].itemS;

                    hit.transform.gameObject.GetComponent<Ground>().WorkTheGround(Ground.Toolstages.Shovel);

                    GetComponent<InventoryManager>().RemoveItem(1);
                }
                break;
            case Toolstates.Scythe:
                hit.transform.gameObject.GetComponent<Ground>().WorkTheGround(Ground.Toolstages.Scythe);
                break;
        }
    }
}
