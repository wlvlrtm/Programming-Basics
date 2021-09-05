using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] Obstacles;

    private PlayerController pc;
    private float startDelay = 2;
    private float repeatRate = 2;
    private int index;
    

    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("ObstacleRandomSpawn", startDelay, repeatRate);
    }


    void ObstacleRandomSpawn()
    {
        if (!pc.isDeath)
        {
            index = Random.Range(0, Obstacles.Length);
            Instantiate(Obstacles[index], this.transform.position, Obstacles[index].transform.rotation);
        }
    }
}