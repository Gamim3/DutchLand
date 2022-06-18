using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceObject : MonoBehaviour
{
    public GameObject finalCrop;

    public GameObject[] groundTile;

    public GameObject gTiledClone;
    public GameObject pPlantedClone;

    public string growthStage;

    public Transform origin;

    public int groundstates;//enum

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        groundstates = 0;

        growthStage = player.GetComponent<ToolSwap>().growthStageTool;

        gTiledClone = Instantiate(groundTile[1], transform.position, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        groundstates = player.GetComponent<ToolSwap>().groundToolState;
    }
    public void Replace(string Toolstate)
    {
        // tilled ground
        if (Toolstate == "Hoe" && groundstates == 0)
        {
            groundstates = 1;

            Destroy(gTiledClone);

            gTiledClone = Instantiate(groundTile[0], transform.position, Quaternion.identity);
        }
        // waterd ground
        if (Toolstate == "WateringCan" && groundstates == 0)
        {
            groundstates = 2;

            Destroy(gTiledClone);

            gTiledClone = Instantiate(groundTile[2], transform.position, Quaternion.identity);
        }
        // waterd tilled ground Water can last
        if (Toolstate == "WateringCan" && groundstates == 1)
        {
            groundstates = 3;

            Destroy(gTiledClone);

            gTiledClone = Instantiate(groundTile[3], transform.position, Quaternion.identity);
        }
        // waterd tilled ground Hoe last
        if (Toolstate == "Hoe" && groundstates == 2)
        {
            groundstates = 3;

            Destroy(gTiledClone);

            gTiledClone = Instantiate(groundTile[3], transform.position, Quaternion.identity);
        }
        if (Toolstate == "Scythe" && growthStage == "FinalStage")
        {
            

            //Destroy(pPlantedClone);
            Destroy(gTiledClone);

            Instantiate(finalCrop);

            gTiledClone = Instantiate(groundTile[0], transform.position, Quaternion.identity);

            growthStage = "Begining";
            groundstates = 0;
        }
    }
}