using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    [SerializeField] private float countDown = 2f;
    [SerializeField] private float timeBetweenWaves = 5f;

    
    void Update()
    {
        countDown -= Time.deltaTime;

        if (countDown <= 0f)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            countDown = timeBetweenWaves;
        }
    }

}
