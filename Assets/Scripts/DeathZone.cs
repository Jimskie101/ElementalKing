using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private GameObject life;
    
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            life = GameObject.FindGameObjectWithTag("Life");
            SoundManager.PlaySound("Dead");
            life.GetComponent<Life>().LifeReset();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Ground")) { }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
