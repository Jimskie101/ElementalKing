using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private LayerMask groundLayerMask;
    public float speed = 15;
    public float jumpHeight = 5;
    //public bool isGrounded = false;
    public bool facingRight = true;
    public Animator animator;
    public Rigidbody2D rb2d;
    public Vector3 pos;
    public BoxCollider2D boxCollider2d;
    AudioSource audioSrc;
    public float velocity;
    float x;

    private void Start()
    {
        groundLayerMask = LayerMask.GetMask("Ground");
        audioSrc = GetComponent<AudioSource>();
    }


    public bool isGrounded()
    {

        //GROUND CHECKING
        float extraHeightText = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, extraHeightText, groundLayerMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }

        Debug.DrawRay(boxCollider2d.bounds.center, Vector2.down * (boxCollider2d.bounds.extents.y + extraHeightText), rayColor);
       
        if (gameObject.GetComponent<Rigidbody2D>().velocity.y != 0)
        {
            return false;
        }


        return raycastHit.collider != null;
    }



    private void FixedUpdate()
    {
        isGrounded();
    }




    // Update is called once per frame
    void Update()
    {
        pos = transform.position;

        velocity = rb2d.velocity.x;







        if (gameObject.GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            animator.speed = 1.5f;
        }


        Jump();
        Flip();
        x = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(x));
        //SOUND CUE
        if (Mathf.Abs(x) > 0 && isGrounded())
        {
            if (audioSrc.isPlaying == false)
            { audioSrc.Play(); }
        }
        else { audioSrc.Stop(); }

        //float y = Input.GetAxis("Vertical");


        transform.Translate(x * speed * Time.deltaTime, 0, 0, 0);
        //transform.Translate(0, y * 10 * Time.deltaTime, 0, 0);
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            SoundManager.PlaySound("Jump");
            animator.speed = 0f;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);

        }
    }

    public void Flip()
    {
        if (x < 0 && facingRight == true)
        {

            transform.Rotate(0f, 180f, 0f);
            facingRight = false;
        }

        if (x > 0 && facingRight == false)
        {

            transform.Rotate(0f, 180f, 0f);
            facingRight = true;
        }
    }

    public IEnumerator Knockback(float knockDur, float knockbackPwr, float x, float y)
    {

        float timer = 0;

        while (knockDur > timer)
        {

            timer += Time.deltaTime;

            rb2d.AddForce(new Vector3(x, y * knockbackPwr, transform.position.z));

        }

        yield return 0;

    }
}
