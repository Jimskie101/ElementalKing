using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public int DPH;
    public Animator animator;
    private Movement player;
    public float dir;
    public Patrolling patrolling;
    public GameObject achievement;
    public string weakness;
    public float curTime = 0;
    public float nextDamage = 2;


    // Update is called once per frame

    private void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();


    }

    private void OnCollisionStay2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {
            if (curTime <= 0)
            {
                Debug.Log("Damage");

                /*if (player.pos.x <= patrolling.positionX)
                {
                    dir = -300f;
                    Debug.Log("left");
                }
                if (player.pos.x > patrolling.positionX)
                {
                    dir = 300f;
                    Debug.Log("right");
                }*/



                if (collision.gameObject.GetComponent<Hearts>().shield == false)
                {
                    SoundManager.PlaySound("Hurt");
                    collision.gameObject.GetComponent<Hearts>().health = collision.gameObject.GetComponent<Hearts>().health - DPH;
                    //StartCoroutine(player.Knockback(0.02f, 0.5f, dir, player.pos.y));
                }
            

            curTime = nextDamage;
        } 
    }
        else
        {

            curTime -= Time.deltaTime;
        }

        
    }


    void Update()
    {
        
    }
    
}
