using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBullet : MonoBehaviour
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
            if (collision.gameObject.GetComponent<Enemy>().weakness == "Water")
            {
                collision.GetComponent<EnemyHealth>().enemyHealth -= 2;
            }
            else
            {
                collision.GetComponent<EnemyHealth>().enemyHealth -= 1;
            }

            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            SoundManager.PlaySound("Hit");
            if (collision.gameObject.GetComponent<BossHealth>().weakness == "Water")
            {
                collision.GetComponent<BossHealth>().enemyHealth -= 3;
            }
            else
            {
                collision.GetComponent<BossHealth>().enemyHealth -= 1;
            }
        }

        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
