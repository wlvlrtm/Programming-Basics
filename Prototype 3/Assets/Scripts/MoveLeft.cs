using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private PlayerController pc;
    private float speed = 20;

    private void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (!pc.isDeath)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);

            if (transform.position.x < -15)
            {
                Destroy(gameObject);
            }
        }
    }
}