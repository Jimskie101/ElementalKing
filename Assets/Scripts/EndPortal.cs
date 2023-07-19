using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPortal : MonoBehaviour
{
    public GameObject screenManager;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        SoundManager.PlaySound("Win");
        screenManager.GetComponent<ScreenManager>().finished = true;
    }



}
