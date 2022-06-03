using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growing : MonoBehaviour
{
    public ZadenObject typeZaad;
    public GameObject[] clone;

    // Start is called before the first frame update
    void Start()
    {
        growthStages = GrowthStages.none;
    }

    public enum GrowthStages
    {
        seeds,
        mini,
        small,
        normal,
        big,
        dead,
        none
    }
    public GrowthStages growthStages;

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGrowing()
    {
        switch (growthStages)
        {
            case GrowthStages.none:
                //do this;
                StartCoroutine(Growth());
                break;
            case GrowthStages.dead:
                // do this;
                break;
        }
    }
    public IEnumerator Growth()
    {
        clone[0] = Instantiate(typeZaad.growthStage[0], transform.position, Quaternion.identity);
        Destroy(clone[0], typeZaad.growthTime[0]);

        yield return new WaitForSeconds(typeZaad.growthTime[0]);

        clone[1] = Instantiate(typeZaad.growthStage[1], transform.position, Quaternion.identity);
        Destroy(clone[1], typeZaad.growthTime[1]);

        yield return new WaitForSeconds(typeZaad.growthTime[1]);

        clone[2] = Instantiate(typeZaad.growthStage[2], transform.position, Quaternion.identity);
        Destroy(clone[2], typeZaad.growthTime[2]);

        yield return new WaitForSeconds(typeZaad.growthTime[2]);

        clone[3] = Instantiate(typeZaad.growthStage[3], transform.position, Quaternion.identity);
        Destroy(clone[3], typeZaad.growthTime[3]);

        yield return new WaitForSeconds(typeZaad.growthTime[3]);

        clone[4] = Instantiate(typeZaad.growthStage[4], transform.position, Quaternion.identity);
        Destroy(clone[4], typeZaad.growthTime[4]);

        yield return new WaitForSeconds(typeZaad.growthTime[4]);

        clone[5] = Instantiate(typeZaad.growthStage[5], transform.position, Quaternion.identity);
    }
}
