using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement : MonoBehaviour
{
    
    public int enemyCount;
    public GameObject star3;
    public GameObject subordinates;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = subordinates.transform.childCount;


        if (enemyCount == 0) 
        {
            star3.SetActive(true);
        }
    }
}
