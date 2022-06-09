using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow1Stage1 : MonoBehaviour
{
    public PlantenObject Plant1Stage1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Plant1Stage1.plant, transform.position, Quaternion.identity);
        }
    }
    void PlaceGrowthStage1()
    {

    }
}
