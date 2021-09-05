using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private float speed = 70.0f;

    private float horizontal;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up * horizontal * speed * Time.deltaTime);
    }
 }
