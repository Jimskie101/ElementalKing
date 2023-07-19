using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Sprite Activated;
    public GameObject targetObject;
    private SpriteRenderer sprite;
    public Sprite Deactivated;
    public GameObject shield;
    private bool working = false;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WaterBullet") && working == false)
        {
            working = true;
            sprite.sprite = Activated;
            Debug.Log("Done");
            shield.SetActive(true);
            targetObject.GetComponent<Hearts>().shield = true;
            StartCoroutine(shieldRevert());
        }
    }

    IEnumerator shieldRevert()
    {
        yield return new WaitForSeconds(10f);
        targetObject.GetComponent<Hearts>().shield = false;
        shield.SetActive(false);
        StartCoroutine(revert());
    }
        
    IEnumerator revert()
    {
        yield return new WaitForSeconds(5f);
        
        
        working = false;
        sprite.sprite = Deactivated;
    }


}
