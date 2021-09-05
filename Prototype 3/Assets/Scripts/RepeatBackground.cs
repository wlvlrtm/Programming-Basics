using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    public int speed = 20;
    public PlayerController pc;
    public Vector3 startPos;

    private float repeatPoint;


    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        startPos = transform.position;
        repeatPoint = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pc.isDeath)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);

            if (transform.position.x < startPos.x - repeatPoint)
            {
                transform.position = startPos;
            }
        }
    }
}