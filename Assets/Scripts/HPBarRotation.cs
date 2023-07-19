using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarRotation : MonoBehaviour
{
    public GameObject Enemy;
    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0f, Enemy.transform.rotation.y, 0f);
    }
}
