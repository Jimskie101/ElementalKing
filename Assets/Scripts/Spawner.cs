using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fireball;
    public float respawnInterval = 1.0f;

    

    void Start()
    {

        StartCoroutine(ballWave());
    }

    IEnumerator ballWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnInterval);
            Spawning();
        }
    }


    // Update is called once per frame
    void Update()
    {

    }



    public void Spawning()
    {
        GameObject c = Instantiate(fireball) as GameObject;
        c.transform.position = new Vector2(Random.Range(-426.2f, -414.4f), 462.8f);
    }
}
