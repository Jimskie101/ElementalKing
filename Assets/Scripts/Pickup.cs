using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public Text scoreText;
    public int score;
    Hearts hearts;
    public int health;
    public int numOfHearts;
    public GameObject star2;
    public int coinCount;

    // Start is called before the first frame update
    void Start()
    {
        hearts = GetComponent<Hearts>();
        
    }

    // Update is called once per frame
    void Update()
    {
        health = hearts.health;
        numOfHearts = hearts.numOfHearts;

        

        if (score >= coinCount)
        {
            star2.SetActive(true);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.gameObject.CompareTag("Coins"))
        {
            SoundManager.PlaySound("Coins");
            Destroy(other.gameObject);
            score++;
            scoreText.text = score.ToString();
        }

        if (other.gameObject.CompareTag("Tissue"))
        {
            if (health < numOfHearts)
            {
                SoundManager.PlaySound("Tissue");
                hearts.health += 1;
                Destroy(other.gameObject);
            }
        }

        if (other.gameObject.CompareTag("Juice"))
        {
            SoundManager.PlaySound("Juice");
            hearts.numOfHearts += 1;
                hearts.health += 1;
                Destroy(other.gameObject);
            
        }


    }
}
