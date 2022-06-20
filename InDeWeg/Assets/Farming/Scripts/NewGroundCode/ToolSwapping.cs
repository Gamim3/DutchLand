using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSwapping : MonoBehaviour
{
    public string toolState;

    public GameObject cam;

    public bool working;

    public RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        toolstates = Toolstates.Hoe;
    }
    public enum Toolstates
    {
        UnderFlow,
        Hoe,
        Water,
        Shovel,
        Scythe,
        OverFlow

    }
    public Toolstates toolstates;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            toolstates--;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            toolstates++;
        }

        switch (toolstates)
        {
            case Toolstates.OverFlow:
                toolstates = Toolstates.Hoe;
                break;
            case Toolstates.UnderFlow:
                toolstates = Toolstates.Scythe;
                break;
        }
        Vector3 direction = cam.transform.forward;

        if (Input.GetButtonDown("Fire1") && working == false && Physics.Raycast(transform.position, direction, out hit, 3f) && hit.transform.tag == "FarmTile")
        {
            Working();

        }
    }
    public void Working()
    {
        switch (toolstates)
        {
            case Toolstates.Hoe:
                hit.transform.gameObject.GetComponent<Ground>().WorkTheGround(Ground.Toolstages.Hoe);
                //dothis
                break;
            case Toolstates.Water:
                hit.transform.gameObject.GetComponent<Ground>().WorkTheGround(Ground.Toolstages.Water);
                //dothis
                break;
            case Toolstates.Shovel:
                hit.transform.gameObject.GetComponent<Ground>().WorkTheGround(Ground.Toolstages.Shovel);
                //dothis
                break;
            case Toolstates.Scythe:
                hit.transform.gameObject.GetComponent<Ground>().WorkTheGround(Ground.Toolstages.Scythe);
                //dothis
                break;
        }
    }
}