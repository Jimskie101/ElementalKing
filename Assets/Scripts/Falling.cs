using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<Hearts>().shield == false)
            {
                SoundManager.PlaySound("Hurt");
                collision.GetComponent<Hearts>().health -= 1;
                Destroy(this.gameObject);
            }
        }
    }
}
