using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCropGrowthStages : MonoBehaviour
{
    public GameObject nextGrowthStage;

    public float growthTime;

    public GameObject clonePlant;

    public string growthstage;

    // Start is called before the first frame update
    void Start()
    {


        StartCoroutine(Growing());
    }
    // Update is called once per frame
    public IEnumerator Growing()
    {
        yield return new WaitForSeconds(growthTime);

        growthstage = "FinalStage";

        clonePlant = Instantiate(nextGrowthStage, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

