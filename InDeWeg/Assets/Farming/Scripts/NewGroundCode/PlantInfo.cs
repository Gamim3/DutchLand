using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantInfo : MonoBehaviour
{
    public int[] growthTimePerState;
    public GameObject[] states;
    public float growTime;
    public int curState;

    public void Grow()
    {
        growTime += Time.deltaTime;

        if(growTime > growthTimePerState[curState])
        {

            // if (SO  curState < array.length -1
            // if (SO  curState == array.length -1 { give crop



            if (curState > states.Length)
            {
                // de max state, nu moet het hele plantje dood?
                 
            }
            else
            {
                // Instantiate het nieuwe model hier vanuit de "states"array, en kill de vorige.
                Instantiate(states[curState], transform.position, Quaternion.identity);
                growTime = 0;
            }

            curState++;

        }
    }
}
