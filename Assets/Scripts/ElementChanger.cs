using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementChanger : MonoBehaviour
{
    public Sprite element1;
    public Sprite element2;
    public Sprite element3;
    public Sprite element4;

    public Animator animator;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        keys();
        animator.SetInteger("Element", gameObject.GetComponent<Weapon>().bullet);
    }

    public void keys()
    {
        if (Input.GetButtonDown("1"))
        {
            spriteRenderer.sprite = element1;
            gameObject.GetComponent<Weapon>().bullet = 1;
        }

        if (Input.GetButtonDown("2"))
        {
            spriteRenderer.sprite = element2;
            gameObject.GetComponent<Weapon>().bullet = 2;
        }

        if (Input.GetButtonDown("3"))
        {
            spriteRenderer.sprite = element3;
            gameObject.GetComponent<Weapon>().bullet = 3;
        }

        if (Input.GetButtonDown("4"))
        {
            spriteRenderer.sprite = element4;
            gameObject.GetComponent<Weapon>().bullet = 4;
        }

    }
}
