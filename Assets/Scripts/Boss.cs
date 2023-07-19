using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private int enemyHealth;
    public int DPH;
    public Animator animator;
    public GameObject target;
    public Transform StrikePoint;
    public float lineOfSight;
    public float shootingRange;
    private bool coolingdown = false;
    public LayerMask enemyLayers;
    float distanceFromTarget;
    float MoveSpeed = 2;
    bool flipped = false;
    public BossHealth bossHealth;

    // Update is called once per frame

    private void Start()
    {
     

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            //collision.gameObject.GetComponent<Hearts>().health = collision.gameObject.GetComponent<Hearts>().health - DPH;
          
    }


    void Update()

    {

        enemyHealth = bossHealth.enemyHealth;

        if (enemyHealth <= 0)
        {
            GetComponent<Boss>().enabled = false;
        }

        if (gameObject.GetComponent<Rigidbody2D>().velocity.x != 0)
        {
            animator.SetBool("Walking", true);
        }
        if (gameObject.GetComponent<Rigidbody2D>().velocity.x == 0)
        {
            animator.SetBool("Walking", false);
        }

        if (target != null)
        {

            distanceFromTarget = Vector2.Distance(target.transform.position, transform.position);

            if (distanceFromTarget < lineOfSight && distanceFromTarget > shootingRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, MoveSpeed * Time.deltaTime);


            }
            else if (distanceFromTarget <= shootingRange && coolingdown == false)
            {

                attack();
                animator.SetTrigger("Attacking");
            }


            if (target.transform.position.x > transform.position.x && flipped == false)
            {
                //face right
                transform.Rotate(0f, 180f, 0f);
                flipped = true;
            }
            else if (target.transform.position.x < transform.position.x && flipped == true)
            {
                //face left
                transform.Rotate(0f, 180f, 0f);
                flipped = false;
            }
        }



       



    }

    private void attack() 
    {
        coolingdown = true;
        StartCoroutine(damage());
        
    }

    private IEnumerator damage()
    {
        yield return new WaitForSeconds(0.5f);
        if (distanceFromTarget <= shootingRange)
        {
            if (target.gameObject.GetComponent<Hearts>().shield == false)
            {
                SoundManager.PlaySound("Hurt");
                target.GetComponent<Hearts>().health = target.GetComponent<Hearts>().health - DPH;
                Debug.Log("SApul");
            }
        }
        StartCoroutine(cooldown());


        
    }


    private IEnumerator cooldown() 
    {
        yield return new WaitForSeconds(2);
        coolingdown = false;
        
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x + 2f, transform.position.y - 1.7f, transform.position.z), lineOfSight);
        Gizmos.DrawWireSphere(new Vector3(transform.position.x + 2f, transform.position.y - 1.7f, transform.position.z), shootingRange);

    }



}
