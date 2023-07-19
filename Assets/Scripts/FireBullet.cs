using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
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
            if (collision.gameObject.GetComponent<Enemy>().weakness == "Fire")
            {
                collision.GetComponent<EnemyHealth>().enemyHealth = collision.GetComponent<EnemyHealth>().enemyHealth - 3;
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
            if (collision.gameObject.GetComponent<BossHealth>().weakness == "Fire")
            {
                collision.GetComponent<BossHealth>().enemyHealth -= 3;
            }
            else
            {
                collision.GetComponent<BossHealth>().enemyHealth -= 1;
            }
            Destroy(gameObject);
        }
        Destroy(gameObject);

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
