using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSwapping : MonoBehaviour
{

    public GameObject cam;

    public bool working;

    public RaycastHit hit;

    public GameObject[] tools;

    public Animation anim;

    public int waterInCan;
    // Start is called before the first frame update
    void Start()
    {
        toolstates = Toolstates.Hoe;

        anim = gameObject.GetComponent<Animation>();
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
            SwapItem();

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
            SwapItem();
        }
        Vector3 direction = cam.transform.forward;

        if (Input.GetButtonDown("Fire1") && working == false && Physics.Raycast(transform.position, direction, out hit, 3f) && hit.transform.tag == "FarmTile")
        {
            Working();
        }
        if (Input.GetButtonDown("Fire1") && working == false && Physics.Raycast(transform.position, direction, out hit, 3f) && hit.transform.tag == "Well")
        {
            if (waterInCan == 0)
            {
                switch (toolstates)
                {
                    case Toolstates.Water:
                        waterInCan = 15;
                        // play animation of well
                        anim.Play();
                        break;
                }
            }
        }
    }

    public void SwapItem()
    {
        foreach (GameObject tool in tools)
        {
            tool.SetActive(false);
        }
        tools[(int)toolstates].SetActive(true);
        anim = tools[(int)toolstates].GetComponent<Animation>();

    }
    public void Working()
    {
        switch (toolstates)
        {
            case Toolstates.Hoe:
                hit.transform.gameObject.GetComponent<Ground>().WorkTheGround(Ground.Toolstages.Hoe);
                anim.Play();
                break;
            case Toolstates.Water:
                if (waterInCan > 0)
                {
                    waterInCan--;
                    hit.transform.gameObject.GetComponent<Ground>().WorkTheGround(Ground.Toolstages.Water);
                    anim.Play();
                }
                break;
            case Toolstates.Shovel:

                int seedSlot = GetComponent<InventoryManager>().slotIndex;

                if (GetComponent<InventoryManager>().inventorySlots[seedSlot].itemS != null)
                {
                    hit.transform.gameObject.GetComponent<PlantGrowthManager>().item = GetComponent<InventoryManager>().inventorySlots[seedSlot].itemS;

                    hit.transform.gameObject.GetComponent<Ground>().WorkTheGround(Ground.Toolstages.Shovel);

                    GetComponent<InventoryManager>().RemoveItem(1);
                }
                anim.Play();
                break;
            case Toolstates.Scythe:
                hit.transform.gameObject.GetComponent<Ground>().WorkTheGround(Ground.Toolstages.Scythe);
                anim.Play();
                break;
        }
    }

    public void SetAllAnimStatesToFalse()
    {
       
    }
}
