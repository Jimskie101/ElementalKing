using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    

    private void Start()
    {
        
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SoundManager.PlaySound("Hit");
            collision.GetComponent<EnemyHealth>().enemyHealth--;
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            SoundManager.PlaySound("Hit");
            collision.GetComponent<BossHealth>().enemyHealth--;
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
