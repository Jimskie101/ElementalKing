using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    public int Health;
    public int Hearts;
    private GameObject player;
   

    private void Awake()
    {
        
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        
    }
    void OnLevelWasLoaded()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Health = 1;
            Hearts = 2;
        }
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            LifeReset();
        }
    }

    public void Copy()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Hearts = player.GetComponent<Hearts>().numOfHearts;
        Health = player.GetComponent<Hearts>().health;
        
    }

    public void LifeReset()
    {
        Health = 3;
        Hearts = 3;
    }
}
