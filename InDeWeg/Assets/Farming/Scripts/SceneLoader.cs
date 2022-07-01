using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SceneLoadeerVictory()
    {
        SceneManager.LoadScene("Victory");
    }

    public void SceneLoadeerLose()
    {
        SceneManager.LoadScene("Game Over");
    }
    public void SceneLoaderFarm()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

