using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarSubor : MonoBehaviour
{
    public GameObject Enemy;
    float enemyHealth;
    float healthUnit;
    float barSize;

    private void Start()
    {
        enemyHealth = Enemy.GetComponent<EnemyHealth>().enemyHealth;
        healthUnit = 0.95f / enemyHealth;


    }

    private void Update()
    {


        enemyHealth = Enemy.GetComponent<EnemyHealth>().enemyHealth;
        barSize = healthUnit * enemyHealth;
        if (barSize <= 0) { barSize = 0; }
        gameObject.transform.localScale = new Vector3(barSize, 0.6f, 1);

    }
}
