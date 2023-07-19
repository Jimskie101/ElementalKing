using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int enemyHealth;
    public GameObject endPortal;
    public Animator animator;
    public string weakness;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {



            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            animator.SetBool("Dead", true);
            endPortal.SetActive(true);
            Destroy(gameObject, 1.7f);
        }
    }
}
