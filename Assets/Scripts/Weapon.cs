using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Animator animator;

    public Transform firePoint;
    public int bullet = 1;
    public GameObject bulletPrefab1;
    public GameObject bulletPrefab2;
    public GameObject bulletPrefab3;
    public GameObject bulletPrefab4;
    private bool cooldown;


    // Start is called before the first frame update
    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.KeypadPlus)) && cooldown == false)
        {
            animator.SetBool("Shooting", true);
            StartCoroutine(Shoot());
        }
        if (Input.GetButtonUp("Fire1") || Input.GetKeyUp(KeyCode.KeypadPlus))
        {
            animator.SetBool("Shooting", false);
        }
    }

    IEnumerator Shoot()
    {
        cooldown = true;
        yield return new WaitForSeconds(0.2f);

        switch (bullet)
        {
            case 1: Instantiate(bulletPrefab1, firePoint.position, firePoint.rotation); break;
            case 2: Instantiate(bulletPrefab2, firePoint.position, firePoint.rotation); break;
            case 3: Instantiate(bulletPrefab3, firePoint.position, firePoint.rotation); break;
            case 4: Instantiate(bulletPrefab4, firePoint.position, firePoint.rotation); break;
        }
        //cooldown = true;
        StartCoroutine(Cooling());

        // Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    IEnumerator Cooling()
    {
        yield return new WaitForSeconds(0.5f);
        cooldown = false;
        
    }
    

}
