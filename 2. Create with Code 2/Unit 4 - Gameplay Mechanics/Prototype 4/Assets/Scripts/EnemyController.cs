using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{
    public float speed;
    
    private GameObject player;
    private Rigidbody rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rigidbody = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        try
        {
            rigidbody.AddForce((player.transform.position - transform.position).normalized * speed * Time.deltaTime, ForceMode.Impulse);
        }
        catch(Exception ex)
        {
            // Player Lost
        }

        // fall
        if (transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }
}
