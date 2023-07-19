using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Vector3 location;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.transform.position = location;
            //new Vector3(-510.4f, 367.82f, 0);
    }
}
