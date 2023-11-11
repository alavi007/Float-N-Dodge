using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;

    private PlayerController playerControllerScript;
    private float downSpawnRangeY = 4;
    private float upSpawnRangeY = 14;
    private float spawnPosX = 22;

    private float startDelay = 2;
    private float spawnInterval = 3;


    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomObstacle", startDelay, spawnInterval);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
                
    }

    void SpawnRandomObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);

            Vector3 spawnPos = new Vector3(spawnPosX, Random.Range(downSpawnRangeY, upSpawnRangeY), 0);

            Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
        }
        
    }
}
