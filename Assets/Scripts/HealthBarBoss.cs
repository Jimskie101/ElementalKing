using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarBoss : MonoBehaviour
{
    public GameObject Boss;
    float bossHealth;
    float healthUnit;
    float barSize;

    private void Start()
    {
        bossHealth = Boss.GetComponent<BossHealth>().enemyHealth;
        healthUnit = 0.95f / bossHealth;
        
        
    }

    private void Update()
    {
        

        bossHealth = Boss.GetComponent<BossHealth>().enemyHealth;
        barSize = healthUnit * bossHealth;
        if (barSize <= 0) { barSize = 0;}
        gameObject.transform.localScale = new Vector3(barSize, 0.6f, 1);
        
    }
}
