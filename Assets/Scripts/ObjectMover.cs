using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public Sprite Activated;
    public GameObject targetObject;
    public Vector3 targetLocation;
    private SpriteRenderer sprite;
    public bool working = false;
    public Sprite Deactivated;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (working == false) 
        {
            sprite.sprite = Deactivated;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FireBullet")) 
        {
            working = true;
            sprite.sprite = Activated;
            Debug.Log("Done");
            targetObject.transform.position = targetLocation;
        }
    }

}
