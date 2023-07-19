using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointPosition : MonoBehaviour
{
    public GameObject element;
    public int elementNo;
    // Start is called before the first frame update
    void Start()
    {
        elementNo = element.GetComponent<Weapon>().bullet;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
