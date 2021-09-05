using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject powerUp;

    private Vector3 randomPos;
    private int itemCount;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ItemSpawn", 1, 3);
    }

    void ItemSpawn()
    {
        randomPos = new Vector3(Random.Range(-9, 9), 0, Random.Range(-9, 9));
        Instantiate(powerUp, randomPos, powerUp.transform.rotation);
    }

}
