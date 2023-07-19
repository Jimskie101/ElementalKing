using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2Bullet : MonoBehaviour
{
    GameObject target;
    public float speed = 12;
    Rigidbody2D bulletRb;

    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRb.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 7);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<Hearts>().shield == false)
            {
                collision.GetComponent<Hearts>().health -= 2;
                Destroy(this.gameObject);
            }
        }
       
    }
}
