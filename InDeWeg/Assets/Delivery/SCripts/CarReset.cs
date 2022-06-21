using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarReset : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] Transform spawnPoint;

    [SerializeField] float spawnValue;

    public void Update()
    {
        if (player.transform.position.y < -spawnValue)
        {
            RespawnPoint();
        }
        
    }

    public void RespawnPoint()
    {
        transform.position = spawnPoint.position;
    }

}
