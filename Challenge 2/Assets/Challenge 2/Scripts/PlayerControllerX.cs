using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private float timer = 2.0f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (timer >= 2.0f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                timer = 0;
            }
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
