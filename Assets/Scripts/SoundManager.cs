using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip jumpSound, coinSound, hurtSound, hitSound, deadSound, winSound, tissueSound, juiceSound;
    static AudioSource audioSrc;
    public GameObject player;

   


    private void Start()
    {
        juiceSound = Resources.Load<AudioClip>("Juice");
        tissueSound = Resources.Load<AudioClip>("Tissue");
        winSound = Resources.Load<AudioClip>("Win");
        deadSound = Resources.Load<AudioClip>("Dead");
        jumpSound = Resources.Load<AudioClip>("Jump");
        coinSound = Resources.Load<AudioClip>("Coins");
        hurtSound = Resources.Load<AudioClip>("Hurt");
        hitSound = Resources.Load<AudioClip>("Hit");
        audioSrc = GetComponent<AudioSource>();

    }

   



    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Jump": audioSrc.PlayOneShot(jumpSound); break ;
            case "Coins": audioSrc.PlayOneShot(coinSound); break;
            case "Hurt": audioSrc.PlayOneShot(hurtSound); break;
            case "Hit": audioSrc.PlayOneShot(hitSound); break;
            case "Dead": audioSrc.PlayOneShot(deadSound); break;
            case "Win": audioSrc.PlayOneShot(winSound); break;
            case "Tissue": audioSrc.PlayOneShot(tissueSound); break;
            case "Juice": audioSrc.PlayOneShot(juiceSound); break;

        }
    }
}
