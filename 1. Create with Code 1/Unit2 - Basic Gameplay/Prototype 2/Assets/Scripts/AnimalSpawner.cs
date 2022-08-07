using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public GameObject[] animals;

    int spawnRangeX = 20;
    int spawnPosZ = 20;

    GameOverChecker checker;


    private void Awake()
    {
        checker = GameObject.Find("GameOverChecker").GetComponent<GameOverChecker>();
    }


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("AnimalRandomSpawn", 2, 1.5f);
    }

    private void Update()
    {
        if (checker.isOver)
        {
            CancelInvoke();
        }
    }

    void AnimalRandomSpawn()
    {
        int index = Random.Range(0, 3); // (0 ~ 3)
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);  // (-20 ~ 19, 0, 20)
        
        animals[index].transform.localEulerAngles = new Vector3(0, 180, 0);
        
        Instantiate(animals[index], spawnPos, animals[index].transform.rotation);
    }
}
