using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public PlantInfo plantOnThisGround;
    public GameObject[] groundStates;
    public int curGroundState;

    public bool SeedsPlanted;

    public bool allowGrowth;
    public float waterLevel;

    public GameObject cloneGround;

    public float fullWaterLevel = 30f;
    public void Start()
    {
        cloneGround = Instantiate(groundStates[0], transform.position, Quaternion.identity);

        toolstages = Toolstages.UnderFlow;
    }
    public enum Toolstages
    {
        UnderFlow,
        Hoe,
        Water,
        Shovel,
        Scythe
    }
    public Toolstages toolstages;
    public void Update()
    {
        
        if (SeedsPlanted)
        {
            // GroundState == prept state;
            waterLevel -= Time.deltaTime;

            if(waterLevel < 0)
            {
                waterLevel = 0;
                allowGrowth = false;

                curGroundState = 5;

                Destroy(cloneGround);
                cloneGround = Instantiate(groundStates[1], transform.position, Quaternion.identity);
                SeedsPlanted = false;
                // Groundstate = ... de uitgedroogde.
            }
            else
            {
                // Groundstate = ... De bewaterde.
                allowGrowth = true;
                GrowPlant();
            }
            if (waterLevel  < fullWaterLevel / 2)
            {
                curGroundState = 1;
            }
        }
        else
        {
            // GroundState == unprept state;
        }
    }

    void GrowPlant()
    {
        GetComponent<PlantInfo>().Grow();
        //plantOnThisGround.Grow();

        if (plantOnThisGround.curState == plantOnThisGround.states.Length)
        {
            //final stage plant
        }
        
    }

    public void AddPlantToThisGround(PlantInfo plantToAdd)
    {
        plantOnThisGround = plantToAdd;
    }
    public void WorkTheGround(Toolstages toolstages)
    {
        switch (toolstages)
        {
            case Toolstages.Hoe:
                if (curGroundState == 0)
                {
                    Destroy(cloneGround);
                    cloneGround = Instantiate(groundStates[1], transform.position, Quaternion.identity);

                    curGroundState = 1;
                }
                break;
            case Toolstages.Water:
                if (curGroundState == 1 || curGroundState == 5)
                {
                    Destroy(cloneGround);
                    cloneGround = Instantiate(groundStates[2], transform.position, Quaternion.identity);

                    waterLevel = fullWaterLevel;
                    curGroundState = 2;
                }
                break;
            case Toolstages.Shovel:
                if (curGroundState == 2)
                {
                    SeedsPlanted = true;
                    curGroundState = 3;
                }
                break;
            case Toolstages.Scythe:
                if (curGroundState == 5)
                {
                    Destroy(cloneGround);

                    cloneGround = Instantiate(groundStates[0], transform.position, Quaternion.identity);

                    curGroundState = 0;
                }
                break;

        }
    }
}
