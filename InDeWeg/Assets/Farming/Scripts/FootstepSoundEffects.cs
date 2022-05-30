using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSoundEffects : MonoBehaviour
{
    public bool footsteps;

    public float stepSpeed = 0.5f;
    public AudioSource footstepAudioSource = default;
    public AudioClip[] woodClips;
    public AudioClip[] groundClips;
    public AudioClip[] grassClips;
    public AudioClip[] farmTileClips;

    public float footstepTimer;

    public RaycastHit hit;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (footsteps == true)
        {
            HandleFootsteps();
        }
    }
    public void HandleFootsteps()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 3f) && hit.transform.tag == "FarmTile")
        {
            footstepAudioSource.PlayOneShot(farmTileClips[Random.Range(0, farmTileClips.Length - 1)]);
        }
        else if (Physics.Raycast(transform.position, Vector3.down, out hit, 3f) && hit.transform.tag == "GroundWalkSound")
        {
            footstepAudioSource.PlayOneShot(groundClips[Random.Range(0, groundClips.Length - 1)]);
        }
        else if (Physics.Raycast(transform.position, Vector3.down, out hit, 3f) && hit.transform.tag == "GrassWalkSound")
        {
            footstepAudioSource.PlayOneShot(grassClips[Random.Range(0, grassClips.Length - 1)]);
        }
        else if (Physics.Raycast(transform.position, Vector3.down, out hit, 3f) && hit.transform.tag == "WoodWalkSound")
        {
            footstepAudioSource.PlayOneShot(woodClips[Random.Range(0, woodClips.Length - 1)]);
        }
    }
}
