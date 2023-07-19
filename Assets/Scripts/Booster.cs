using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public Sprite Activated;
    public GameObject targetObject;
    private SpriteRenderer sprite;
    public Sprite Deactivated;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TeleBullet"))
        {
            sprite.sprite = Activated;
            Debug.Log("Done");
            targetObject.GetComponent<Movement>().jumpHeight = 27;
            StartCoroutine(revert());
        }
    }

    IEnumerator revert()
    {
        yield return new WaitForSeconds(2);
        targetObject.GetComponent<Movement>().jumpHeight = 10;
        sprite.sprite = Deactivated;
    }


}
