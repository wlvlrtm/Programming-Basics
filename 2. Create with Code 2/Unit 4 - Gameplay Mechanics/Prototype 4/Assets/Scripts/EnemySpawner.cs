using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private int enemyCount;

    private PlayerController player;
    private Vector3 randomPos;
    private int wave;


    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    private void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        
        if (enemyCount == 0 && !player.isDeath)
        {
            wave += 1;
            EnemySpawn(wave);
        }
    }


    void EnemySpawn(int wave)
    {
        for (int i = 0; i < wave; i++)
        {
            randomPos = new Vector3(Random.Range(-9, 9), 0, Random.Range(-9, 9));
            Instantiate(enemy, randomPos, enemy.transform.rotation);
        }        
    }
}
