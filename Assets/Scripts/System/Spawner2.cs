using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    //public GameObject parent;
    [Tooltip("How many units to spawn in at once")]
    [SerializeField] private int numberToSpawn;
    [Tooltip("How many units will come out in total")]
    [SerializeField] private int limit;
    [Tooltip("How fast units come out")]
    [SerializeField] private float rate;
    [Tooltip("How many units until rate change.")]
    [SerializeField] private int rateChange;
    [Tooltip("What the rate you want it to be when you hit rate change")]
    [SerializeField] private float rateUp;
    private int spawnCount;
    public Transform[] spawnPoints;

    float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = rate;
    }

    // Update is called once per frame
    void Update()
    {
        

            SpawnEnemy();
            spawnTimer -= Time.deltaTime;
            
            
        
    }

    void SpawnEnemy()
    {
      
            if (spawnTimer <= 0f)
            {
            for (int i = 0; i < numberToSpawn; i++)
                {
                if (spawnCount == rateChange)
                {
                    rate = rateUp;
                    spawnCount++;
                    

                }
                else if (spawnCount <= limit)
                {
                    int randomEnemy;
                    randomEnemy = (int)Random.Range(0, objectsToSpawn.Length);
                    int randomIndex = Random.Range(0, spawnPoints.Length);
                    Transform spawnPoint = spawnPoints[randomIndex];
                    Instantiate(objectsToSpawn[randomEnemy], spawnPoint.position, spawnPoint.rotation);
                    spawnCount++;

                }
            }
            
            spawnTimer = rate;
            }

        

    }
    
}
