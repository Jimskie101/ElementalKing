using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public ObjectMover script;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        script.working = false;
    }
}
