using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpinner : MonoBehaviour
{
    private float speed = 70;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
