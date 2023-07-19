using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{
    public float speed;
    public bool moveRight;
    public float positionX;
    public float startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        positionX = transform.position.x;


        if (moveRight == true)
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            

            if (startPos + 2 <= positionX)
            {
                moveRight = false;
                transform.Rotate(0f, 180f, 0f);

            }

        }
        else 
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            
            if (startPos - 2 >= positionX)
            {
                moveRight = true;
                transform.Rotate(0f, 180f, 0f);
            }

        }
    }
}
