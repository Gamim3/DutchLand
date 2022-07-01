using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public bool noMoney;

    public GameObject shopmanager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (shopmanager.GetComponent<ShopManager>().coins == 0)
        {
            noMoney = true;
        }

        if (noMoney == true)
        {
            SceneLoadeerLose();
        }
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

