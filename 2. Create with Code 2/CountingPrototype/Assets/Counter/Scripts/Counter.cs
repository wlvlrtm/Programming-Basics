using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;

    private int Count = 0;


    private void Start()
    {
        Count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        Count += 1;
        CounterText.text = "Count : " + Count;

        Destroy(other.gameObject);

        Vector3 randomPos = new Vector3(UnityEngine.Random.Range(0, -4), 0, UnityEngine.Random.Range(-8, 8));

        gameObject.transform.position = randomPos;
    }



}
